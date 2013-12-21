namespace Incoding.MvcContrib
{
    #region << Using >>

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Incoding.Extensions;
    using Incoding.Maybe;
    using Newtonsoft.Json.Linq;

    #endregion

    public abstract class IncControlBase
    {
        #region Fields

        protected readonly RouteValueDictionary attributes = new RouteValueDictionary();

        #endregion

        #region Properties

        /// <summary>
        ///     <see cref="HtmlAttribute.TabIndex" />
        /// </summary>
        public int TabIndex { set { this.attributes.Set(HtmlAttribute.TabIndex.ToStringLower(), value); } }

        public Action<IIncodingMetaLanguageCallbackBodyDsl> OnEvent { get; set; }

        public Action<IIncodingMetaLanguageCallbackBodyDsl> OnInit { get; set; }

        public Action<IIncodingMetaLanguageCallbackBodyDsl> OnChange { get; set; }

        #endregion

        #region Api Methods

        public abstract MvcHtmlString ToHtmlString();

        /// <summary>
        ///     <see cref="HtmlAttribute.AutoComplete" />
        /// </summary>
        public void DisableAutoComplete()
        {
            SetAttr(HtmlAttribute.AutoComplete, "off");
        }

        /// <summary>
        ///     <see cref="HtmlAttribute.AutoComplete" />
        /// </summary>
        public void SetAttr(HtmlAttribute attr, object value)
        {
            SetAttr(attr.ToStringLower(), value.With(r => r.ToString()));
        }

        /// <summary>
        ///     <see cref="HtmlAttribute.AutoComplete" />
        /// </summary>
        public void SetAttr(string attr, object value)
        {
            this.attributes.Set(attr.ToLower(), value.With(r => r.ToString()));
        }

        public void Attr(object attr)
        {
            var allAttr = AnonymousHelper.ToDictionary(attr);

            const string dataIncodingKey = "incoding";

            if (allAttr.ContainsKey(dataIncodingKey))
            {
                var meta = new List<object>();
                if (this.attributes.ContainsKey(dataIncodingKey))
                {
                    meta = (this.attributes[dataIncodingKey].ToString().DeserializeFromJson<object>() as JContainer)
                            .Cast<object>()
                            .ToList();
                }

                var newMeta = (allAttr[dataIncodingKey].ToString().DeserializeFromJson<object>() as JContainer).Cast<object>().ToList();
                meta.AddRange(newMeta);

                allAttr.Set(dataIncodingKey, meta.ToJsonString());
            }

            this.attributes.Merge(allAttr);
        }

        public void AddClass(string @class)
        {
            const string key = "class";
            if (this.attributes.ContainsKey(key))
                this.attributes[key] += " " + @class;
            else
                this.attributes.Add(key, @class);
        }

        #endregion

        protected RouteValueDictionary GetAttributes()
        {
            bool isIml = OnInit != null ||
                         OnChange != null ||
                         OnEvent != null;

            if (isIml)
            {
                this.attributes.Merge(new IncodingMetaLanguageDsl(JqueryBind.InitIncoding)
                                              .Do()
                                              .Direct()
                                              .OnSuccess(dsl =>
                                                             {
                                                                 OnInit.Do(action => action(dsl));
                                                                 OnEvent.Do(action => action(dsl));
                                                             })
                                              .When(JqueryBind.Change)
                                              .Do()
                                              .Direct()
                                              .OnSuccess(dsl =>
                                                             {
                                                                 OnChange.Do(action => action(dsl));
                                                                 OnEvent.Do(action => action(dsl));
                                                             })
                                              .AsHtmlAttributes());
            }

            return this.attributes;
        }
    }
}