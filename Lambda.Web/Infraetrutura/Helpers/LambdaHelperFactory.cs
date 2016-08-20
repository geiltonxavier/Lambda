using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lambda.Web.Infraetrutura.Helpers
{
    public static class LambdaHelperFactory
    {
        public static LambdaHelpers Lambda(this HtmlHelper helper)
        {
           return new LambdaHelpers(helper);
        }
    }
}