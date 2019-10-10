using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EP.CursoMvc.UI.Mvc.Controllers
{
    [RoutePrefix("")]
    [Route("{action=index}")]
    public class TesteController : Controller
    {
        //21mp-proc.-octa-core-16gb/p/2139427/te/motx/
        // GET: Teste
        [Route("{produtodesc:maxlength(200)}/p/{produtoid:int}/te/motx")]
        public ActionResult Index(string produtodesc, int produtoid)
        {
            return View();
        }
    }
}