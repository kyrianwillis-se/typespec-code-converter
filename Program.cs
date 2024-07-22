using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TypeSpecCodeConverter.Services;
using TypeSpecCodeConverter.Configuration;

class Program
{   
    static async Task Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        var fileService = host.Services.GetRequiredService<IFileService>();
        var transformationService = host.Services.GetRequiredService<ITransformationService>();

        //get any typespec files in the commit
        var tspFiles = args.Where(a => a.EndsWith(".tsp", StringComparison.CurrentCultureIgnoreCase)).ToList();
        if (!tspFiles.Any())
        {
            Console.WriteLine("No tsp files to process");
            return;
        }
        Console.WriteLine($"{tspFiles.Count()} Files Changed");

        var allApplicationFiles = fileService.GetAllFiles();//get list of all files in this application
        Console.WriteLine($"{allApplicationFiles.Count()} Total Files");


        var typespecContent = fileService.ConcatenateFiles(tspFiles);//get the content of the typespec files
        Console.WriteLine("Typespec Content Retrieved");

        var fileChangeSet = await transformationService.GetChangedFiles(typespecContent, allApplicationFiles);//get list of application files that need to be added or updated
        Console.WriteLine($"New Files:\n{string.Join("\n", fileChangeSet.NewFiles)}\n");
        Console.WriteLine($"Updated Files:\n{string.Join("\n", fileChangeSet.UpdatedFiles)}");


        if(fileChangeSet.HaveChangedFiles)
        {
            var transformationResults = await transformationService.TransformFileToCSharpAsync(fileChangeSet, tspFiles);//get the updated content of the files
            fileService.SaveGeneratedFiles(transformationResults);
            Console.WriteLine("Files generated");
        }
        else
        { 
            Console.WriteLine("No files generated");
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, config) =>
            {
                config.SetBasePath(AppContext.BaseDirectory)
                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                services.Configure<ApplicationConfig>(context.Configuration.GetSection("AppSettings"));

                services.AddHttpClient();

                services.AddSingleton<IGptApiService, GptApiService>();
                services.AddSingleton<IFileService, FileService>();
                services.AddSingleton<ITransformationService, TransformationService>();
            });
}
