yahoo-fantasy-football-tools
============================

Yahoo Fantasy Footballs Tools is a web application to assist with managing Yahoo! Fantasy Football leagues and teams using the [Yahoo Fantasy Sports API](http://developer.yahoo.com/fantasysports/guide/).

Local Setup
============================

To run the YahooFantasyFootballTools ASP.NET MVC application and the Fantasizer unit test suite, you need to add two system environment variables:
* YahooConsumerKey
* YahooConsumerSecret

Set the values to your Yahoo application's API credentials (see [Registering your app](http://developer.yahoo.com/fantasysports/guide/GettingStarted.html#GettingStarted-register)).

AppHarbor Setup
===========================

To run the YahooFantasyFootballTools ASP.NET MVC application on AppHarbor, you need to set a few configuration variables:

* Set configuration varaibles for the same key/secret credentials as described in local setup.
* Create a configuration variable with key "YahooCallbackUriType" and value "Host".  Otherwise you will see an error after logging into Yahoo.

See AppHarbor's documentation on [managing environments](http://support.appharbor.com/kb/getting-started/managing-environments).
