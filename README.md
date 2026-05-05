# Task Manager API (C# / .NET)

A simple REST API built with ASP.NET Core to manage tasks.

---

##  Features
- Get all tasks
- Create a new task
- Update task status
- Delete a task

---

##  Technologies
- C#
- .NET / ASP.NET Core
- Swagger (API testing)

---

##  How to Run
1. Clone the repository
2. Open in Visual Studio
3. Run the project (F5)
4. Open Swagger:
5. https://localhost:7145/swagger
   
---

## 📡 API Endpoints

| Method | Endpoint        | Description        |
|--------|---------------|--------------------|
| GET    | /tasks        | Get all tasks      |
| POST   | /tasks        | Create new task    |
| PUT    | /tasks/{id}   | Update a task      |
| DELETE | /tasks/{id}   | Delete a task      |

---

##  Example JSON

### Create Task
```json
{
  "title": "Learn C#",
  "isDone": false
}
