﻿namespace Incoding.SiteTest.Controllers
{
    #region << Using >>

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Incoding.CQRS;
    using Incoding.Extensions;
    using Incoding.MvcContrib;
    using Incoding.SiteTest.VM;

    #endregion

    public class JasmineController : IncControllerBase
    {
        #region Http action

        [HttpGet]
        public ActionResult GetValue(string value)
        {
            return IncJson(value);
        }

        [HttpGet]
        public ActionResult Index(string jqueryVersion)
        {
            var allExecutable = new List<string>();

            allExecutable.AddRange(typeof(ExecutableBase).Assembly
                                                         .GetLoadableTypes()
                                                         .Where(r => r.Name.StartsWith("Executable"))
                                                         .Where(r => r.IsClass && !r.IsAbstract)
                                                         .Select(r => r.Name));

            var vm = new JasmineIndexContainer
                     {
                             AllSupportedMeta = allExecutable
                                     .Select(r => r.Replace("Incoding", string.Empty))
                                     .ToArray(),
                             AllSupportedConditional = Enum.GetNames(typeof(ConditionalOfType)),
                             JqueryVersion = string.IsNullOrWhiteSpace(jqueryVersion) ? "1.8.0" : jqueryVersion,
                             IncSpecialBinds = new List<string>
                                               {
                                                       JqueryBind.Incoding.ToString(),
                                                       JqueryBind.InitIncoding.ToString(),
                                                       JqueryBind.IncAjaxBefore.ToString(),
                                                       JqueryBind.IncAjaxComplete.ToString(),
                                                       JqueryBind.IncAjaxError.ToString(),
                                                       JqueryBind.IncAjaxSuccess.ToString(),
                                                       JqueryBind.IncInsert.ToString()
                                               }
                     };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Perfromance(string jqueryVersion)
        {
            var vm = new JasmineIndexContainer
                     {
                             JqueryVersion = string.IsNullOrWhiteSpace(jqueryVersion) ? "1.8.0" : jqueryVersion,
                     };

            return View(vm);
        }

        #endregion
    }
}