import "../enums/companyRole.enum.tsp";

model CompanyProgramRole {
    ProgramRoleId: int32;
    CompanyId: int32;
    SponsorId?: int32;//this is only required if this object is for a Supplier
    ProgramId: int32;
    Role: Enums.CompanytRole;
}
