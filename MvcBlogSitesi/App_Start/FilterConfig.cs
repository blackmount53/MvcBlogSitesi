using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogSitesi.App_Start
{
    public class FilterConfig 
    {
        public static void RegisterGlobalFilter(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahHandleErrorLoggerFilter());
            filters.Add(new HandleErrorAttribute());
        }

        public class ElmahHandleErrorLoggerFilter: System.Web.Mvc.IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                if (filterContext.ExceptionHandled)
                {
                    ErrorSignal.FromCurrentContext().Raise(filterContext.Exception);
                }
            }
        }

        
    }
}