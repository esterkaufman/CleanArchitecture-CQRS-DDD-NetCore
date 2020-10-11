using System;
using System.Reflection;
using System.Transactions;

namespace Moj.Keshet.Domain.Utils.TransactionScope
{
    public class TransactionScopeProvider
    {
        private static TransactionOptions _defaultOptions;

        static TransactionScopeProvider()
        {
            var timeout = 240; // (int)GlobalParameters.Get(GlobalParameters.Global.TransactionTimeout);

            _defaultOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = new TimeSpan(0, 0, timeout)
            };
        }

        public static System.Transactions.TransactionScope Default
        {
            get
            {
                return new System.Transactions.TransactionScope(TransactionScopeOption.Required, _defaultOptions);
            }
        }

        public static System.Transactions.TransactionScope DefaultNew
        {
            get
            {
                return new System.Transactions.TransactionScope(TransactionScopeOption.RequiresNew, _defaultOptions);
            }
        }

        public static System.Transactions.TransactionScope DefaultSuppress
        {
            get
            {
                return new System.Transactions.TransactionScope(TransactionScopeOption.Suppress, _defaultOptions);
            }
        }

        public static System.Transactions.TransactionScope Long
        {
            get
            {
                return new System.Transactions.TransactionScope(TransactionScopeOption.Required, new TransactionOptions
                {
                    IsolationLevel = _defaultOptions.IsolationLevel,
                    Timeout = new TimeSpan(0, 0, (int)_defaultOptions.Timeout.TotalSeconds * 10),
                });
            }
        }

        public static System.Transactions.TransactionScope ExtraLong
        {
            get
            {
                return new System.Transactions.TransactionScope(TransactionScopeOption.Required, new TransactionOptions
                {
                    IsolationLevel = _defaultOptions.IsolationLevel,
                    Timeout = new TimeSpan(0, 0, (int)_defaultOptions.Timeout.TotalSeconds * 10),
                });
            }
        }

        /// <summary>
        /// TransactionScope is limitted by machine.config to 10 minutes.
        /// When using longer transaction timeouts, make sure to call this method 
        /// once to define anew the process level limit.
        /// </summary>
        public static void OverrideTimeoutCeiling()
        {
            var timeout = new TimeSpan(0, 0, (int)_defaultOptions.Timeout.TotalSeconds * 60);
            SetTransactionManagerField("_cachedMaxTimeout", true);
            SetTransactionManagerField("_maximumTimeout", timeout);
        }

        //public static void GetTransactionManagerField(string fieldName)
        //{
        //    var val = typeof(TransactionManager)
        //        .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static)
        //        .GetValue(null);
        //    System.Diagnostics.Debug.WriteLine($"transaction manager timeout = {val}");
        //}

        private static void SetTransactionManagerField(string fieldName, object value)
        {
            typeof(TransactionManager)
                .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Static)
                .SetValue(null, value);
        }
    }
}
