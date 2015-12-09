﻿namespace Incoding.SiteTest
{
    #region << Using >>

    using System.Threading;
    using Incoding.Block;
    using Incoding.CQRS;
    using Incoding.Extensions;

    #endregion

    [OptionOfDelay(Async = true)]
    public class AddProductCommand : CommandBase
    {
        #region Properties

        public string Name { get; set; }

        #endregion

        protected override void Execute()
        {
            Repository.Save(new Product { Name = "Async" });
            Thread.Sleep(1.Seconds());
        }
    }
}