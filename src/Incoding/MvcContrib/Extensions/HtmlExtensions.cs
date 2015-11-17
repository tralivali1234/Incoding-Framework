namespace Incoding.MvcContrib
{
    #region << Using >>

    using System;
    using System.Linq.Expressions;
    using System.Web.Mvc;
    using Incoding.Extensions;
    using Incoding.MvcContrib.MVD;

    #endregion

    public static class HtmlExtensions
    {
        [ThreadStatic]
        internal static HtmlHelper HtmlHelper;
        
        [ThreadStatic]
        internal static IUrlDispatcher UrlDispatcher;



        #region Factory constructors

        public static IncodingHtmlHelperFor<TModel, TProperty> For<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            return new IncodingHtmlHelperFor<TModel, TProperty>(htmlHelper, property);
        }

        public static IncodingHtmlHelperForGroup<TModel, TProperty> ForGroup<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> property)
        {
            return new IncodingHtmlHelperForGroup<TModel, TProperty>(htmlHelper, property);
        }

        public static IncodingHtmlHelper Incoding<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new IncodingHtmlHelper(htmlHelper);
        }

        public static SelectorHelper<TModel> Selector<TModel>(this HtmlHelper<TModel> htmlHelper)
        {
            return new SelectorHelper<TModel>();
        }

        public static IIncodingMetaLanguageBindingDsl When(this HtmlHelper htmlHelper, JqueryBind bind)
        {
            return htmlHelper.When(bind.ToJqueryString());
        }

        public static IIncodingMetaLanguageBindingDsl When(this HtmlHelper htmlHelper, string bind)
        {
            HtmlHelper = htmlHelper;
            UrlDispatcher = new UrlDispatcher(new UrlHelper(htmlHelper.ViewContext.RequestContext));
            return new IncodingMetaLanguageDsl(bind);
        }


        #endregion
    }
}