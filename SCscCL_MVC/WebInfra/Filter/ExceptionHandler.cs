using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Web;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
//1/.处理已知的需要处理的Exception情况；
//2/.通用异常处理，可以根据不同异常的请求方法分类处理；
//2/.1/.根据Exception的controller、action、ExceptionStackTrace做日志记录；当然也可以存入关系型数据库当中，这也是一个好办法。
//2/.2/.根据RequestMethod做处理；
//2/.2/.1/.检索RequestBody的值；
//检索请求数据发现异常；
namespace SCscCL_MVC.WebInfra.Filter
{
	//【Learn-Ref】https://dotnettutorials.net/lesson/exception-filter-in-asp-net-core-mvc/#google_vignette
	// Custom handling of unhandled exceptions.
	public class ExceptionHandler : Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter
	{
		public async void OnException(ExceptionContext context)
		{
			//1/. Handle known exceptions that need to be handled;
			if (context.Exception is UnauthorizedAccessException)
			{
				context.Result = new Microsoft.AspNetCore.Mvc.ObjectResult("Access denied.")
				{
					StatusCode = 403,
				};
				context.ExceptionHandled = true;
			}
			//else if ()
			//{

			//}
			string querystring = string.Empty;
			HttpRequest request = context.HttpContext.Request;

			if (request.QueryString.HasValue && request.QueryString.Value.Length > 0)
			{
				querystring = HttpUtility.UrlDecode(request.QueryString.Value, Encoding.UTF8);
			}
			//2/. Generic exception handling, which can be classified according to the request method of different exceptions;
			if (context.ExceptionHandled == false)
			{
				//2/.1/. Record logs based on Exception controller, action, and ExceptionStackTrace.Of course, it can also be stored in a relational database, which is also a good idea.
				var controllerName = context.RouteData.Values["controller"];
				var actionName = context.RouteData.Values["action"];
				string message = $"\nTime: {DateTime.Now}, Controller: {controllerName}, Action: {actionName}, ExceptionMessage: {context.Exception.Message},ExceptionStackTrace: {context.Exception.StackTrace}";
				string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Log", "Log.txt");
				File.AppendAllText(filePath, message);

				if (request.QueryString.HasValue && request.QueryString.Value.Length > 0)
				{
					querystring = HttpUtility.UrlDecode(request.QueryString.Value, Encoding.UTF8);
				}
				//2/.2/. Make a request based on the RequestMethod.
				if (context.HttpContext.Request.Method == "GET")
				{

				}
				else if (context.HttpContext.Request.Method == "POST")
				{
					//2/.2/.1/. Retrieves the value of the RequestBody;
					if (request.ContentLength.HasValue && request.ContentLength > 0)
					{
						try
						{
							using (var ms = new MemoryStream())
							{
								request.EnableBuffering();
								request.Body.Seek(0, 0);
								await request.Body.CopyToAsync(ms);
								var b = ms.ToArray();
								querystring = Encoding.UTF8.GetString(b);
								request.Body.Position = 0;
							}
						}
						catch (Exception ex)
						{
							if (ex.Message.Contains("Unexpected end of request content"))
							{
								querystring = $"Search request data found abnormal;：{ex.Message}";
								context.Result = new ContentResult
								{
									Content = System.Text.Json.JsonSerializer.Serialize(new { Code = -1, data = false, msg = "Search request data found abnormal, Please try again." }),
									StatusCode = StatusCodes.Status200OK,
									ContentType = "text/html;charset=utf-8"
								};
							}
						}
					}
				}
				else
				{


				}
			}
		}

		/// <summary>
		/// Asynchronous occurrence exception
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public Task OnExceptionAsync(ExceptionContext context)
		{
			OnException(context);
			return Task.CompletedTask;
		}

	}
}
