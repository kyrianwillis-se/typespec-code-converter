//import "../enums/programAssetType.enum.tsp";

model ProgramAsset {
    programAssetId: int32;
    programId: int32;
    @maxLength(200)
    key: string;
    @maxLength(5000)
    value: string;
    //AssetType: Enums.ProgramAssetType;
}
