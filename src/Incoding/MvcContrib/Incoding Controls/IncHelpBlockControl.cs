﻿namespace Incoding.MvcContrib
{
    #region << Using >>

    using System.Web.Mvc;
    using Incoding.Extensions;

    #endregion

    public class IncHelpBlockControl : IncControlBase
    {
        #region Properties

        public string Message { get; set; }

        #endregion

        public override MvcHtmlString Render()
        {
            if (string.IsNullOrWhiteSpace(Message))
                return MvcHtmlString.Empty;

            var p = new TagBuilder(HtmlTag.P.ToStringLower());
            p.AddCssClass("help-block");
            p.SetInnerText(Message);
            return new MvcHtmlString(p.ToString());
        }
    }
}