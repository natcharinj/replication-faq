# replication-faq
A FAQ on SQL Server Replication

# Build Webpack projects
- CD to root of the project
- Restore all Node packages with:
```sh
$ yarn install
```
- Build and watch changes in the theme project with:
```sh
$ yarn workspace replication-faq-theme run watch
```
- Then reload your website by pressing F5.


# Azure storage account 
- Add `OrchardCore__OrchardCore_Media_Azure__ConnectionString` to App Service configuration


**Note** a default Linux app service or a custom Linux container, any nested JSON key structure in the app setting name like ApplicationInsights:InstrumentationKey needs to be configured in App Service as ApplicationInsights__InstrumentationKey for the key name. 
In other words, any : should be replaced by __ (double underscore).


