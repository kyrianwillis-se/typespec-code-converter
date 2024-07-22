import "./companyProgramRole.tsp";
import "./externalCompanyId.tsp";

model Company {
    CompanyId: int32;

    @maxLength(100)
    Name: string;
    
    @maxLength(200)
    Logo: string;

    @doc("An identifier from an outside source that validates this as a recognized organization, this value is distinct")
    @maxLength(50)
    ExternalId: string;

    ...ExternalCompanyId;
    Roles: CompanyProgramRole[]; 
}
