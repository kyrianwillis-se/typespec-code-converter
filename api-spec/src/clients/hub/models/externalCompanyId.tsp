
model ExternalCompanyId{
    @doc("ExternalCompanyId is a unique identifier that originates from an outside application and identifies a recognized company")
    @maxLength(50)
    ExternalCompanyId : string;
}
