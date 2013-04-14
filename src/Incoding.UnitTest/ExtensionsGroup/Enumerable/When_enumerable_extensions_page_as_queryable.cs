﻿namespace Incoding.UnitTest.ExtensionsGroup
{
    #region << Using >>

    using System.Collections.Generic;
    using System.Linq;
    using Incoding.Extensions;
    using Machine.Specifications;using Incoding.MSpecContrib;

    #endregion

    [Subject(typeof(EnumerableExtensions))]
    public class When_enumerable_extensions_page_as_queryable
    {
        #region Estabilish value

        static List<int> collection;

        static IQueryable<int> result;

        #endregion

        Establish establish = () => { collection = Pleasure.ToList(1, 5, 6, 2, 4, 7); };

        Because of = () => { result = collection.AsQueryable().Page(2, 3); };

        It should_be_verify = () => result.ShouldEqualWeakEach(new[] { 2, 4, 7 });
    }
}