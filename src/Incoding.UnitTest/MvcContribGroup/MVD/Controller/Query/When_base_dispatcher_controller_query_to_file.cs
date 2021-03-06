﻿namespace Incoding.UnitTest.MvcContribGroup
{
    #region << Using >>

    using Incoding.CQRS;
    using Incoding.MSpecContrib;
    using Incoding.MvcContrib.MVD;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(DispatcherControllerBase))]
    public class When_base_dispatcher_controller_query_to_file : Context_dispatcher_controller
    {
        Establish establish = () =>
                              {
                                  var query = Pleasure.Generator.Invent<FakeFileByNameQuery>();
                                  dispatcher.StubQuery(Pleasure.Generator.Invent<CreateByTypeQuery>(dsl => dsl.Tuning(r => r.ControllerContext, controller.ControllerContext)
                                                                                                              .Tuning(r => r.ModelState, controller.ModelState)
                                                                                                              .Empty(r => r.IsModel)
                                                                                                              .Empty(r => r.IsGroup)
                                                                                                              .Tuning(r => r.Type, typeof(FakeFileByNameQuery).Name)), (object)query);
                                  content = Pleasure.Generator.Bytes();
                                  contentType = Pleasure.Generator.String();
                                  fileName = Pleasure.Generator.String();

                                  dispatcher.StubQuery(Pleasure.Generator.Invent<MVDExecute>(dsl => dsl.Tuning(r => r.Instance, new CommandComposite(query))), (object)content);
                                  dispatcher.StubQuery(Pleasure.Generator.Invent<GetMvdParameterQuery>(dsl => dsl.Tuning(r => r.Params, controller.HttpContext.Request.Params)), new GetMvdParameterQuery.Response()
                                                                                                                                                                                 {
                                                                                                                                                                                         Type = typeof(FakeFileByNameQuery).Name,
                                                                                                                                                                                         ContentType = contentType,
                                                                                                                                                                                         FileDownloadName = fileName
                                                                                                                                                                                 });
                                  responseBase.Setup(r => r.AddHeader("X-Download-Options", "Open"));
                              };

        Because of = () => { result = controller.QueryToFile(); };

        It should_be_result = () => result.ShouldBeFileContent(content,
                                                               contentType: contentType,
                                                               fileDownloadName: fileName);

        #region Establish value

        static byte[] content;

        static string contentType;

        static string fileName;

        #endregion
    }
}