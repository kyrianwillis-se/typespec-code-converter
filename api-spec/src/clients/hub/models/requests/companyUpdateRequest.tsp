import "../../enums/companyRole.enum.tsp";
import "../externalCompanyId.tsp";

model companyUpdateRequest {  
    CompanyId: int32;
    StatusId: int32;

    ...ExternalCompanyId;
}
