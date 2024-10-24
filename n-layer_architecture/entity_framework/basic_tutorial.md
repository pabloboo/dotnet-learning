Notes on this [tutorial](https://www.youtube.com/watch?v=ZX7_12fwQLU&ab_channel=ProgrammingwithMosh).

You can also check the official [documentation](https://learn.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/)

# What is Entity Framework

With a persistance framework you can load your objects from or save them to a database.

Entity Framework is a persistance framework that helps a lot with coding the connection. By using it you no longer have to write store procedures, manage database connections, manual mapping, etc.

# Different workflows

The workflows to build a domain model using entity framework (EF) are: database first, code first and model first.

Database first: we start with the database. We design our tables and then EF generates the domain classes based on the database. This is the traditional approach.

Code first: we start with the code. We create our domain classes and then EF generates the database tables. This is a newer approach.

Model first: we create an UML diagram and then EF generates domain classes and database. This approach will not be explained because the UML designer isn't very good.

# Database-first workflow in action

In SQL Server Management Studio create a new table inside DatabaseFirstDemo database.

Every time we make a change to our database we need to generate a change script so we can store them in the repository and run them on any database to bring it to the newer version. To do that on SQL Server Management Studio press the save change script icon and name the file "0001 - Create Posts table.sql" (sequence number - description).

Go to Visual Studio, create a new project and import the database.

First use package manager console to install Entity Framework. On VS go to Tools->NuGet Package Manager->Package Manager Console. In the console write "install-package EntityFramework" and press enter.

Go to solution explorer -> Right click the project -> add -> new item -> ADO.NET Entity Data Model (this will represent the mapping between the database tables and our domain classes) -> give it a name like "BlogModel" if the project is about blogs. -> Select "EF Designer from database" -> New connection... -> Microsoft SQL Server -> Server name: .\SQLEXPRESS, Select database "DatabaseFirstDemo" -> Press "Text connection" and check that it works. -> Press OK -> Press next -> Check all tables -> Press finish -> A file with an extension .edmx should be created.

Go to solution explorer -> Expand BlogModel.edmx -> check the generated code.

Code to create a new Post:
```c#
var context = new DatabaseFirstDemoEntities();
var post = new Post()
{
    Body = "Body",
    DatePublished = DateTime.Now,
    Title = "Title",
    PostID = 1
};
context.Posts.Add(post);
context.saveChanges(); // This is needed to persist changes.
```

After running that code go to SQL Server Management Studio and select the first 100 rows of the Post table to check if the post was added.

# Code first workflow in action.

In VS create a new project -> Install Entity framework like the previous chapter -> Create a new class called Post:

```c#
public class Post
{
    public int Id { get; set; }
    public DateTime DatePublished { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
}
```

Now create a DB context (an abstraction to the database to load or save data):

```c#
public class BlogDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
}
```

Specify the connection string to the database: go to App.config and at the end of the file paste:

```c#
<connectionStrings>
    <add name="BlogDbContext" connectionString="data source=.\SQLEXPRESS; initial catalog=CodeFirstDemo; integrated security=SSPI" providerName="System.Data.SqlClient">
</connectionStrings>
```

Where initial catalog is the database name and integrated security means that we are using windows authentication.

Go to package manager console -> enable code first migrations inserting the command "enable-migrations".

The previous steps are only made once. When we want to make changes we change our code and we create a migration by going to the package manager console and inserting the command "add-migration 'CreatePost'" where 'CreatePost' is the description of what you changed. Check that a new folder called "Migrations" was created. This is the same process as the change script in the first approach but more automated.

The next step is to run it. When we run it EF looks at our database, takes the current version and then figures out what migrations need to run on the database to bring it up to date.

To run the migration go to Package Manager Console and insert the command "Update-Database" -> Check that the command executed correctly -> Go to SQL Server Management Studio -> Refresh the databases -> Check that the tables were created correctly.

# Database-First or Code-First

Anything you want to do you can do it with both approaches, so at the end it all comes down to personal preference.

Code first advantages: full versioning of database, productivity (it is faster to write code than to click in a UI). Even if you have a existing database you can reverse engineer it and use a code first approach.