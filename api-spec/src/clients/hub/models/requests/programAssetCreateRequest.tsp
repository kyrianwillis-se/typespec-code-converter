import "./companyProgramRole.tsp";
import "./programTarget.tsp";

model ProgramAssetCreateRequest {  
    programId: int32;
    @maxLength(200)
    key: string;
    @maxLength(5000)
    value: string;
    AssetType: Enums.ProgramAssetType;
}
