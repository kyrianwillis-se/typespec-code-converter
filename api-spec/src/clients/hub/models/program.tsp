import "./company.tsp";
import "./programAsset.tsp";
import "./programTarget.tsp";

model Program {
    programId: int32;
    @maxLength(100)
    name: string;
    @maxLength(5000)
    description: string;
    isPublic: boolean; //can this program be joined without an invitation
    referToZeigoActivate: boolean; //can users be referred to Zeigo
    isActive: boolean;
    isDraft: boolean; //is this a draft of the program
    hasDraft: boolean; //does this program have a draft version available
    versionId: int32; //version of this program's copy and assests
    programTargets: ProgramTarget[];
    @doc("Information used on the front end, can describe text, images, video, faq")
    assets: ProgramAsset[];
    sponsors: Company[];
}
