using Microsoft.AspNetCore.Mvc;

namespace SCscCL_MVC.Controllers
{
	public class WebInfraTestController : Controller
	{
		public IActionResult ThrowException()
		{
			//simulate an exception
			throw new UnauthorizedAccessException("Access Denied.");
		}


	}
}
