# SkillTrack

**Learning & Skill Progress Tracking Platform**

SkillTrack is a full-stack application for structured learning: users follow learning paths made of modules and lessons, take quizzes, submit assignments, track goals, and get measurable progress and skill analytics — instead of a single "% complete" bar.

This project is being built incrementally as a portfolio-quality, professional full-stack application, with a strong focus on clean architecture, proper database design, and real authentication/authorization.

## Repository Structure

```text
SkillTrack/
├── backend/                    ASP.NET Core Web API solution (.NET 10)
│   ├── SkillTrack.API          Controllers, middleware, HTTP/auth configuration
│   ├── SkillTrack.Application  DTOs, interfaces, services, business logic
│   ├── SkillTrack.Domain       Entities, enums, core domain models
│   └── SkillTrack.Infrastructure
│                                EF Core, DbContext, repositories, seeding
│
├── frontend/                   Angular application (TypeScript)
│
├── database/                   Raw SQL, ERD, migration notes
│   └── seed-data/              Seed data for skills, categories, sample content
│
└── docs/                       Architecture diagrams, API docs, planning notes

Tech Stack
Backend: C#, ASP.NET Core Web API, .NET 10, Entity Framework Core, SQL Server, LINQ, JWT Authentication
Frontend: Angular, TypeScript, Reactive Forms, Router, HttpClient, Interceptors, Route Guards
Architecture: Layered/Clean Architecture, Repository Pattern, Service Layer, with the Domain kept independent from infrastructure concerns
Architecture

The project follows a layered architecture with clear separation of responsibilitieS
                    ┌──────────────────────┐
                    │    SkillTrack.API    │
                    │ Controllers / HTTP   │
                    └──────────┬───────────┘
                               │
                               ▼
                    ┌──────────────────────┐
                    │ SkillTrack.Application│
                    │ DTOs / Services /     │
                    │ Interfaces / Logic    │
                    └──────────┬───────────┘
                               │
                               ▼
                    ┌──────────────────────┐
                    │  SkillTrack.Domain   │
                    │ Entities / Enums /   │
                    │ Core Business Rules  │
                    └──────────────────────┘
                               ▲
                               │
                    ┌──────────┴───────────┐
                    │ SkillTrack.Infrastructure
                    │ EF Core / DbContext  │
                    │ Repositories / Seed  │
                    └──────────────────────┘

 The Domain layer remains independent from infrastructure and database-specific concerns.

 Main Features

The platform will include:

User registration and login
JWT-based authentication and authorization
Role-based access control
Skills and skill categories
Learning paths
Modules and lessons
Learning resources
Lesson progress tracking
Quizzes and quiz attempts
Quiz scoring and results
Assignments and submissions
Assignment grading and feedback
Learning goals
Achievements
Learning streaks
User dashboard
Skill progress and analytics
Admin dashboard
Search, filtering, and pagination

Additional features such as AI-powered recommendations, certificates, notifications, leaderboards, and a mobile application may be added in future iterations.

Status

🚧 Under active, step-by-step development.

The project is being developed incrementally, with each major feature being implemented, tested, and integrated before moving to the next stage.

See docs/ for progress notes and technical documentation as they are added.

Getting Started

Setup instructions for running the backend and frontend will be added as each part of the project becomes available.

Backend

The backend will be built using:

.NET 10
ASP.NET Core Web API
Entity Framework Core
SQL Server
Frontend

The frontend will be built using:

Angular
TypeScript
Reactive Forms
Angular Router
HttpClient
Route Guards
HTTP Interceptors
Project Goals

The main goal of SkillTrack is to build a realistic, professional full-stack application while strengthening practical development skills in:

C#
ASP.NET Core
REST APIs
Entity Framework Core
SQL Server
LINQ
Database design
Authentication and authorization
JWT
Angular
TypeScript
Git and GitHub
Clean architecture
Testing
API integration
Error handling and validation