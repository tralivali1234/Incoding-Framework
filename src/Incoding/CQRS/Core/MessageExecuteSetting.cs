﻿namespace Incoding.CQRS
{
    #region << Using >>

    using System.Data;
    using Incoding.Extensions;

    #endregion

    public class MessageExecuteSetting
    {
        #region Constructors

        public MessageExecuteSetting() { }

        internal MessageExecuteSetting(MessageExecuteSettingAttribute attribute)
        {
            DataBaseInstance = attribute.DataBaseInstance;
            Connection = attribute.Connection;
            IsolationLevel = attribute.IsolationLevel;
        }

        internal MessageExecuteSetting(MessageExecuteSetting executeSetting)
        {
            DataBaseInstance = executeSetting.DataBaseInstance;
            Connection = executeSetting.Connection;
            IsolationLevel = executeSetting.IsolationLevel;
        }

        #endregion

        #region Properties

        public string DataBaseInstance { get; set; }

        public string Connection { get; set; }

        public IsolationLevel? IsolationLevel { get; set; }

        #endregion

        #region Equals

        public override int GetHashCode()
        {
            unchecked
            {
                return ((DataBaseInstance != null ? DataBaseInstance.GetHashCode() : 0) * 397) ^
                       (Connection != null ? Connection.GetHashCode() : 0) ^
                       (IsolationLevel.HasValue ? IsolationLevel.GetHashCode() : 0);
            }
        }

        public override bool Equals(object obj)
        {
            return this.IsReferenceEquals(obj) && Equals(obj as MessageExecuteSetting);
        }

        protected bool Equals(MessageExecuteSetting other)
        {
            if (other == null)
                return false;

            return string.Equals(DataBaseInstance, other.DataBaseInstance) &&
                   string.Equals(Connection, other.Connection) &&
                   IsolationLevel.Equals(other.IsolationLevel);
        }

        #endregion
    }
}