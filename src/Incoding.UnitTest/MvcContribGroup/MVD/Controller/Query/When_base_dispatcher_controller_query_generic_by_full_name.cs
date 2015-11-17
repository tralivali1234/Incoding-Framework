﻿namespace Incoding.UnitTest.MvcContribGroup
{
    #region << Using >>

    using System.Web;
    using Incoding.Extensions;
    using Incoding.MSpecContrib;
    using Incoding.MvcContrib.MVD;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(DispatcherControllerBase))]
    public class When_base_dispatcher_controller_query_generic_by_full_name : Context_dispatcher_controller
    {
        #region Establish value

        static string queryResult;

        #endregion

        Establish establish = () =>
                              {
                                  Establish(types: new[] { typeof(ShareGenericQuery<>) });
                                  queryResult = Pleasure.Generator.String();
                                  dispatcher.StubQuery(new ShareGenericQuery<string>(), queryResult);
                              };

        Because of = () => { result = controller.Query("{0}|{1}".F(typeof(ShareGenericQuery<>).FullName, HttpUtility.UrlEncode(typeof(string).FullName)), false); };

        It should_be_result = () => result.ShouldBeIncodingSuccess<string>(s => s.ShouldEqual(queryResult));
    }
}