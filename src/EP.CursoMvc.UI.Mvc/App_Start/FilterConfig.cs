﻿using System.Web;
using System.Web.Mvc;
using EP.CursoMvc.Infra.CrossCutting.MvcFilters;

namespace EP.CursoMvc.UI.Mvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalErrorHandler());
        }
    }
}
