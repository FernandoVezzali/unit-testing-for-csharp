using Microsoft.AspNetCore.Builder;
using Microsoft.Data.Sqlite;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using MiniValidation;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("TodoDb") ?? "Data Source=todos.db;Cache=Shared";
builder.Services.AddScoped(_ => new SqliteConnection(connectionString));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await EnsureDb(app.Services, app.Logger);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.MapSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!")
   .WithName("Hello");

app.MapGet("/todos", async (SqliteConnection db) =>
    await db.QueryAsync<Todo>("SELECT * FROM Todos"))
   .WithName("GetAllTodos");

app.MapPost("/todos", async (Todo todo, SqliteConnection db) =>
{
    if (!MiniValidator.TryValidate(todo, out var errors))
        return Results.ValidationProblem(errors);

    var newTodo = await db.QuerySingleAsync<Todo>(
        "INSERT INTO Todos(Title, IsComplete) Values(@Title, @IsComplete) RETURNING * ", todo);

    return Results.Created($"/todos/{newTodo.Id}", newTodo);
})
    .WithName("CreateTodo")
    .ProducesValidationProblem()
    .Produces<Todo>(StatusCodes.Status201Created);

app.MapDelete("/todos/delete-all", async (SqliteConnection db) => Results.Ok(await db.ExecuteAsync("DELETE FROM Todos")))
    .WithName("DeleteAll")
    .Produces<int>(StatusCodes.Status200OK);

app.Run();

async Task EnsureDb(IServiceProvider services, ILogger logger)
{
    logger.LogInformation("Ensuring database exists at connection string '{connectionString}'", connectionString);

    using var db = services.CreateScope().ServiceProvider.GetRequiredService<SqliteConnection>();
    var sql = $@"CREATE TABLE IF NOT EXISTS Todos (
                  {nameof(Todo.Id)} INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                  {nameof(Todo.Title)} TEXT NOT NULL,
                  {nameof(Todo.IsComplete)} INTEGER DEFAULT 0 NOT NULL CHECK({nameof(Todo.IsComplete)} IN (0, 1))
                 );";
    await db.ExecuteAsync(sql);
}

public partial class Program { }