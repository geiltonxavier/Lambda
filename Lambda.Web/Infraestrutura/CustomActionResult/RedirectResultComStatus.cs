using System.Web.Mvc;

namespace Lambda.Web.Infraestrutura.CustomActionResult
{
    public class RedirectResultComStatus : ActionResult
    {
        private string url;

        private int status;

        public RedirectResultComStatus(string urlParam, int statusParam)
        {
            url = urlParam;
            status = statusParam;
        }


        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.StatusCode = status;
            response.RedirectLocation = url;
            response.End();
        }
    }
}