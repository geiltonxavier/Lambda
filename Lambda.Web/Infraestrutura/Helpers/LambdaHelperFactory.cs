using System.Web.Mvc;

namespace Lambda.Web.Infraestrutura.Helpers
{
    public static class LambdaHelperFactory
    {
        public static LambdaHelpers Lambda(this HtmlHelper helper)
        {
           return new LambdaHelpers(helper);
        }
    }
}