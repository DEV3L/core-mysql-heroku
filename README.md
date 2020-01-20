# core-mysql-heroku
.Net Core 3 web API with Swagger using MySQL database and Dapper

# Requirements

* .Net Core 3
* MySQL
* Visual Studio (for Mac)

# References

* [.Net Core 3 - Part 1 - Swagger](https://dev.to/lucianopereira86/net-core-3-part-1-swagger-2bkf)
* [.Net Core 3 - Part 2 - MySQL](https://dev.to/lucianopereira86/net-core-web-api-part-2-mysql-3bje)
* [.Net Core 3 - Part 3 - Heroku](https://dev.to/lucianopereira86/net-core-web-api-part-3-heroku-284j)
* [Get started with Swashbuckle and ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio)

# Local Development

1. `git clone git@github.com:DEV3L/core-mysql-heroku.git`
2. Open Project in Visual Studio
3. Connect to MySQL using MySQL Workbench
4. Create a database schema
5. Execute `01_build.sql`
6. Update the MySQL ConnectionStrings to use host, database name, user, and password 
7. Build and run the solution
8. In browser nevigate to `https://localhost:5001/swagger`

# Deployment

1. Create an application in Heroku, referenced as $APP_NAME
2. From the terminal, navigate to the top level project directory
3. `docker build -t $APP_NAME .`
4. `heroku login`
5. `heroku container:login`
6. `docker tag $APP_NAME registry.heroku.com/$APP_NAME/web`
7. `heroku container:push web -a $APP_NAME`
8. `heroku container:release web -a $APP_NAME`

# Future Development

* Setup database migrations
* Add docker compose with MySQL and application
* Hook up to CI/CD
* Add environment based configuration
* Add Example Unit Tests

# Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-twitter-learning-journal`
3. Commit your changes: `git commit -am 'Add something'`
4. Push to the branch: `git push origin my-twitter-learning-journal`
5. Submit a pull request :D
