import "../programAsset.tsp";
import "../programTarget.tsp";

model ProgramCreateRequest {  
    @maxLength(100)
    name: string;
    @maxLength(5000)
    description: string;
    isPublic: boolean;
    referToZeigo: boolean;
    publish:boolean;//if true this version will be set as the live version, otherwise this will be saved a draft
    programTargets: ProgramTarget[];
    programAssets: ProgramAsset[];
}
