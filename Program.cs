using TaskManagerAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var tasks = new List<TaskItem>();

// GET all tasks
app.MapGet("/tasks", () => tasks);

// POST a new task
app.MapPost("/tasks", (TaskItem task) =>
{
    task.Id = tasks.Count + 1;
    tasks.Add(task);
    return Results.Created($"/tasks/{task.Id}", task);
});

// PUT (Update) a task
app.MapPut("/tasks/{id}", (int id, TaskItem updatedTask) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);

    if (task == null)
        return Results.NotFound();

    task.Title = updatedTask.Title;
    task.IsDone = updatedTask.IsDone;

    return Results.Ok(task);
});

// DELETE a task
app.MapDelete("/tasks/{id}", (int id) =>
{
    var task = tasks.FirstOrDefault(t => t.Id == id);

    if (task == null)
        return Results.NotFound();

    tasks.Remove(task);
    return Results.NoContent();
});

app.Run();