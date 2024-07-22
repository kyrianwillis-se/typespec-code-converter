import "../enums/userRole.enum.tsp";
import "../enums/companyRole.enum.tsp";

model Invitation {
    invitationId?: int32;
    @maxLength(100)
    firstName: string;
    @maxLength(100)
    lastName: string;
    @maxLength(200)
    emailAddress: string;
    userRole: Enums.UserRole; 
    programId: int32; //which program this invitation is for
    companyId: int32; //which company this user will be associated with 
}
