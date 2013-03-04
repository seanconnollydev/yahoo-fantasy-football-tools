﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YahooFantasySportsClient.Domain;

namespace YahooFantasySportsClient
{
    public class YahooFantasySportsService
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private OAuthClient _oAuthClient;
        private AuthorizedUser _currentUser;

        public YahooFantasySportsService(string consumerKey, string consumerSecret, IUserTokenStore userTokenStore)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _oAuthClient = new OAuthClient(userTokenStore, consumerKey, consumerSecret);
        }

        public AuthorizedUser CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    _currentUser = new AuthorizedUser(_oAuthClient);
                }

                return _currentUser;
            }
        }

        public void BeginAuthorization(Uri callback)
        {
            _oAuthClient.BeginAuth(callback);
        }

        public void CompleteAuthorization()
        {
            _oAuthClient.CompleteAuth();
        }
    }
}