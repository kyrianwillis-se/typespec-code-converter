import "../models/user.tsp";
import "../models/requests/userUpdateRequest.tsp";
import "../../../common/apiError.tsp";
import "../../../common/success.tsp";
using TypeSpec.Http;

namespace Zeigo.Admin.Hub;

@route("/clients/hub/users")
namespace Users{
    @doc("return all users by program and/or company id")
    @route("/")
    @get op search( @query programId?: int32, @query companyId?: int32): User[];

    @doc("Return a user by id")
    @route("/{userId}")
    @get op getById(@path userId: int32): 
        Success<User> | ApiError<404>;
    
    @doc("Update a user, valid statuses for update are Active and Inactive")
    @route("/{userId}")
    @put op update(@path userId: int32, @body userUpdateRequest: UserUpdateRequest): {
        @statusCode statusCode: 204;
    } | ApiError<400> | ApiError<404> | ApiError<409>;    
}