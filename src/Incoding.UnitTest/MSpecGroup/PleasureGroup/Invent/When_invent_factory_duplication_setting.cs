namespace Incoding.UnitTest.MSpecGroup
{
    #region << Using >>

    using System;
    using Machine.Specifications;using Incoding.MSpecContrib;

    #endregion

    [Subject(typeof(InventFactory<>))]
    public class When_invent_factory_duplication_setting : Context_invent_factory
    {
        #region Estabilish value

        static InventFactory<FakeGenerateObject> inventFactory;

        #endregion

        Establish establish = () => { inventFactory = new InventFactory<FakeGenerateObject>(); };

        It should_be_throw_exception_if_property_duplicate_in_ignore = () => Catch
                                                                                     .Exception(() => inventFactory
                                                                                                              .IgnoreBecauseAuto(r => r.StrValue)
                                                                                                              .Ignore(r => r.StrValue, "Test"))
                                                                                     .ShouldBeOfType<ArgumentException>();

        It should_be_throw_exception_if_property_duplicate_in_tuning = () => Catch
                                                                                     .Exception(() => inventFactory
                                                                                                              .Tuning(r => r.StrValue, "Test")
                                                                                                              .Tuning(r => r.StrValue, "Test"))
                                                                                     .ShouldBeOfType<ArgumentException>();

        It should_be_throw_exception_if_property_duplicate_in_empty = () => Catch
                                                                                    .Exception(() => inventFactory
                                                                                                             .Empty<string>(r => r.StrValue)
                                                                                                             .Empty<string>(r => r.StrValue))
                                                                                    .ShouldBeOfType<ArgumentException>();

        It should_be_throw_exception_if_property_duplicate_in_generate_to = () => Catch
                                                                                          .Exception(() => inventFactory
                                                                                                                   .GenerateTo<FakeGenerateObject>(r => r.Fake)
                                                                                                                   .GenerateTo<FakeGenerateObject>(r => r.Fake))
                                                                                          .ShouldBeOfType<ArgumentException>();
    }
}