import "../models/company.tsp";
import "../models/requests/companyCreateRequest.tsp";
import "../models/requests/companyUpdateRequest.tsp";
import "../../../common/apiError.tsp";
import "../../../common/success.tsp";
using TypeSpec.Http;

namespace Zeigo.Admin.Hub;

@route("/clients/hub/companies")
namespace Companies{
    @doc("Returns companies for a program")
    @get op search(@query programId: int32): Company[];

    @doc("Return a company by id")
    @route("/{companyId}")
    @get op getById(@path companyId: int32): 
        Success<Company> | ApiError<404>;
    
    @doc("Create a new company")
    @route("/")
    @post op createNew(@header contentType: "multipart/form-data", companyCreateRequest: CompanyCreateRequest, logo: bytes): {
        @statusCode statusCode: 204;
    } | ApiError<400> | ApiError<409>;

    @doc("Update a company")
    @route("/{companyId}")
    @put op update(@path companyId: int32, @body company: companyUpdateRequest): {
        @statusCode statusCode: 204;
    } | ApiError<400> | ApiError<404> | ApiError<409>;

    @doc("Update a company logo")
    @route("/{companyId}/logo")
    @put op updateLogo(@header contentType: "multipart/form-data", @path companyId: int32, logo: bytes): {
        @statusCode statusCode: 204;
    } | ApiError<400> | ApiError<404> | ApiError<409>;
}