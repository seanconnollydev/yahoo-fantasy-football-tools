using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Linq;

namespace YahooFantasyFootballTools
{
    /// <summary>
    /// Stores OAuth token and secret storage for use across discrete web requests.
    /// </summary>
    public class SessionStateTokensAndSecretsStore : IDictionary<string, string>
    {
        private readonly HttpSessionState _sessionState;
        private SessionStateTokensAndSecretsStore(HttpSessionState sessionState)
        {
            _sessionState = sessionState;
        }

        private static SessionStateTokensAndSecretsStore _current;
        internal static SessionStateTokensAndSecretsStore Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new SessionStateTokensAndSecretsStore(HttpContext.Current.Session);
                }

                return _current;
            }
        }

        public void Add(string key, string value)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            throw new NotImplementedException();
        }

        public ICollection<string> Keys
        {
            get { return _sessionState.Keys.Cast<string>().ToList(); }
        }

        public bool Remove(string key)
        {
            if (_sessionState[key] != null)
            {
                _sessionState.Remove(key);
                return true;
            }

            return false;
        }

        public bool TryGetValue(string key, out string value)
        {
            throw new NotImplementedException();
        }

        public ICollection<string> Values
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string key]
        {
            get
            {
                return (string)_sessionState[key];
            }
            set
            {
                _sessionState[key] = value;
            }
        }

        public void Add(KeyValuePair<string, string> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}