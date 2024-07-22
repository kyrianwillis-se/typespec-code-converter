import "../companyProgramRole.tsp";
import "../externalCompanyId.tsp";

model CompanyCreateRequest {  
    ...ExternalCompanyId;

    Roles: CompanyProgramRole[]; 
}
