namespace Incoding.MvcContrib
{
    #region << Using >>

    using System;
    using System.Linq.Expressions;

    #endregion

    public interface IExecutableSetting
    {
        [Obsolete("Use If with expression")]
        IExecutableSetting If(Action<IConditionalBuilder> configuration);

        IExecutableSetting If(Expression<Func<bool>> expression);

        IExecutableSetting TimeOut(double millisecond);

        IExecutableSetting TimeOut(TimeSpan time);

        IExecutableSetting Interval(double millisecond, out string intervalId);

        IExecutableSetting Interval(TimeSpan time, out string intervalId);
    }
}