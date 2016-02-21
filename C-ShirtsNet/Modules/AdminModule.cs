using Nancy;
using CShirts.Web.Models;

namespace CShirts.Web.Modules
{
	public class AdminModule : NancyModule
	{
		public AdminModule(CreationTimeService webApplicationService) : base("/admin")
		{
			Get["/"] = parameters => {
				/*var model = new CShirts.Web.Views.Admin {
					CreationDate = webApplicationService.GetCreationDate(),
					TotalRequests = webApplicationService.TimesRequested()
				};*/
				var model = "";

				return View["Index", model];
			};
		}
	}
}