# SkillTrack Backend

ASP.NET Core Web API (.NET 10) using a layered / clean architecture.

## Projects

| Project | Depends on | Responsibility |
|---|---|---|
| `SkillTrack.Domain` | *(nothing)* | Entities, enums, base types — the core business model |
| `SkillTrack.Application` | Domain | DTOs, service interfaces, repository interfaces, business logic, validation |
| `SkillTrack.Infrastructure` | Application, Domain | EF Core `DbContext`, repository implementations, DB configuration, identity/JWT |
| `SkillTrack.API` | Application, Infrastructure | Controllers, middleware, DI wiring, Swagger, HTTP concerns |

Dependency direction: `API → Application → Infrastructure`, with `Domain` referenced
by everything but depending on nothing. `Application` never references `Infrastructure`
directly — it only knows about interfaces (`IGenericRepository<T>`, `IUnitOfWork`, and
entity-specific repository/service interfaces as they're added), which `Infrastructure`
implements. This keeps business logic testable and decoupled from EF Core/SQL Server.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local instance, Docker container, or Azure SQL) — update the connection
  string in `SkillTrack.API/appsettings.json` / `appsettings.Development.json`

## Running locally

```bash
cd backend
dotnet restore
dotnet build

# once EF Core migrations exist (added in Step 3):
# dotnet ef database update --project SkillTrack.Infrastructure --startup-project SkillTrack.API

dotnet run --project SkillTrack.API
```

Then open `http://localhost:5000/swagger` (or the HTTPS URL) — you should see Swagger
UI with a single `GET /api/Health` endpoint. That endpoint exists purely to confirm the
solution wiring (project references, DI, controllers) works before we build real
features on top of it.

## What's here vs. what's coming

This is the **Step 2 skeleton**: four projects, correctly wired, building and running,
with the folder structure already in place for the layers we haven't filled in yet
(`Entities`, `DTOs`, `Interfaces/Services`, `Services`, `Persistence/Configurations`, etc).
No real domain entities, auth, or endpoints exist yet — those come in the following
steps, one module at a time, exactly as laid out in the project plan.
