using System.Collections.Generic;
using System.Linq;
using TaskManagerAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var tasks = new List<TaskItem>();

app.MapGet("/tasks", () => tasks);

app.MapPost("/tasks", (TaskItem task) =>
{
    task.Id = tasks.Count + 1;
    tasks.Add(task);
    return Results.Ok(task);
});

app.MapPut("/tasks/{id}", (int id, TaskItem updatedTask) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);

    if (task == null)
        return Results.NotFound();

    task.Title = updatedTask.Title;
    task.IsDone = updatedTask.IsDone;

    return Results.Ok(task);
});

app.MapDelete("/tasks/{id}", (int id) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);

    if (task == null)
        return Results.NotFound();

    tasks.Remove(task);
    return Results.Ok();
});

app.Run();