using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeSpecCodeConverter.Services
{
    public interface IGptApiService
    {
        Task<string> CallGpt4Api(string content);
    }
}
