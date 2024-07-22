///TypeSpec Imports
import "@typespec/http";
import "@typespec/versioning";

///Zeigo Admin 
import "./clients/hub/enums/versions.enum.tsp";
import "./clients/hub/services/program.service.tsp";
import "./clients/hub/services/company.service.tsp";
import "./clients/hub/services/user.service.tsp";
import "./clients/hub/services/invitation.service.tsp";

using TypeSpec.Http;
using TypeSpec.Versioning;

@service({
	title: "Zeigo Hub",
})
@server("https://hub.zeigo.com/api/", "Zeigo Hub API")
@versioned(Versions)
namespace Zeigo.Admin;

