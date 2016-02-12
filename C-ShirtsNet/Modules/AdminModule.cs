using Nancy;
using CShirtsNet.Models;

namespace CShirts.Modules.AdminModule
{
	public class AdminModule : NancyModule
	{
		public AdminModule(CreationTimeService webApplicationService) : base("/admin")
		{
			Get["/"] = parameters => {
				var model = new CShirtsNet.Views.Admin.Models.IndexModel {
					CreationDate = webApplicationService.GetCreationDate(),
					TotalRequests = webApplicationService.TimesRequested()
				};

				return View["Index", model];
			};
		}
	}
}