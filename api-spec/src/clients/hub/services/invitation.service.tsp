import "../models/invitation.tsp";
import "../../../common/apiError.tsp";
import "../../../common/success.tsp";
using TypeSpec.Http;

namespace Zeigo.Admin.Hub;

@route("/clients/hub/invitations")
namespace Invitations{
    @doc("Returns invitations")
    @get op returnAll(): Invitation[];

    @doc("Return and invitation by id")
    @route("/{invitationId}")
    @get op getById(@path invitationId: int32): 
        Success<Invitation> | ApiError<404>;
    
    @doc("Create a new invitation")
    @route("/")
    @post op createNew(@body invitation: Invitation): {
        @statusCode statusCode: 204;
    } | ApiError<400> | ApiError<409>;

    @doc("Delete an invitation")
    @route("/")
    @put op update(@body invitation: Invitation): {
        @statusCode statusCode: 204;
    } | ApiError<400> | ApiError<404> | ApiError<409>;
}