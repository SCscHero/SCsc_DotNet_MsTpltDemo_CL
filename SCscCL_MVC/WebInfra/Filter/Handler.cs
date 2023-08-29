using Microsoft.AspNetCore.Mvc.Filters;

namespace SCscCL_MVC.WebInfra.Filter
{
    public class Handler : Microsoft.AspNetCore.Mvc.Filters.ActionFilterAttribute
	{
        //1/5
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
        }
        //2/5:Controller当中的逻辑
        //3/5
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
        //4/5
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
        }
        //5/5
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
        }
    }
}
