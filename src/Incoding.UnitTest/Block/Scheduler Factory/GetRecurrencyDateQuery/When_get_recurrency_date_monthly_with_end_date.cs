namespace IncodingContrib.UnitTest
{
    #region << Using >>

    using System;
    using Incoding.MSpecContrib;
    using Machine.Specifications;

    #endregion

    [Subject(typeof(GetRecurrencyDateQuery))]
    public class When_get_recurrency_date_monthly_with_end_date
    {
        #region Fields

        Establish establish = () =>
                                  {
                                      GetRecurrencyDateQuery query = Pleasure.Generator.Invent<GetRecurrencyDateQuery>(dsl => dsl.Tuning(r => r.Type, RepeatType.Monthly)
                                                                                                                                 .Tuning(r => r.RepeatInterval, 1)
                                                                                                                                 .Tuning(r => r.StartDate, Convert.ToDateTime("05/15/2015 16:36"))
                                                                                                                                 .Tuning(r => r.EndDate, Convert.ToDateTime("08/20/2015 20:23"))
                                                                                                                                 .Tuning(r => r.NowDate, Convert.ToDateTime("07/19/2015 16:37")));
                                      mockNow = DateTime.Now;

                                      expected = new DateTime?(Convert.ToDateTime("08/15/2015 16:36"));

                                      mockQuery = MockQuery<GetRecurrencyDateQuery, DateTime?>
                                              .When(query)
                                              .StubQuery(new GetDateTimeNowQuery(), new GetDateTimeNowQuery.Response
                                                                                        {
                                                                                                Now = mockNow,
                                                                                                UtcNow = mockNow
                                                                                        });
                                  };

        Because of = () => mockQuery.Original.Execute();

        It should_be_result = () => mockQuery.ShouldBeIsResult(expected);

        #endregion

        #region Establish value

        static MockMessage<GetRecurrencyDateQuery, DateTime?> mockQuery;

        static DateTime? expected;

        static DateTime mockNow;

        #endregion
    }
}