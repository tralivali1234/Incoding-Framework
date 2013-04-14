﻿namespace Incoding.UnitTest.MSpecGroup
{
    using Incoding.Block.Caching;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    [Subject(typeof(CachingFactoryTestEx))]
    public class When_caching_factor_test_ex_should_be_get : Context_CachingFactoryTestEx
    {
        #region Fake classes

        class FakeInstance { }

        #endregion

        #region Estabilish value

        static FakeCache cacheKey;

        #endregion

        Establish establish = () =>
                                  {
                                      cacheKey = new FakeCache(Pleasure.Generator.String());
                                      CachingFactory.Instance.Stub();
                                  };

        Because of = () => CachingFactory.Instance.Get<FakeInstance>(cacheKey);

        It should_be_delete = () => CachingFactory.Instance.ShouldBeGet<FakeInstance, FakeCache>(cacheKey);
    }
}