using System.Collections.Generic;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var tasks = new List<TaskManagerAPI.TaskItem>();

app.MapGet("/tasks", () => tasks);

app.MapPost("/tasks", (TaskManagerAPI.TaskItem task) =>
{
    task.Id = tasks.Count + 1;
    tasks.Add(task);
    return task;
});

app.MapPut("/tasks/{id}", (int id, TaskManagerAPI.TaskItem updatedTask) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task == null)
    {
        return Results.NotFound();
    }

    task.IsDone = updatedTask.IsDone;
    return Results.Ok(task);
});

app.MapDelete("/tasks/{id}", (int id) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);
    if (task == null)
    {
        return Results.NotFound();
    }

    tasks.Remove(task);
    return Results.Ok();
});

app.Run();