# SkillTrack Database

This folder holds database artifacts that live outside EF Core's migration history:

- ERD diagrams (added once the core entities are modeled in Step 3)
- Raw SQL scripts (e.g. one-off maintenance scripts, view definitions)
- Notes on schema decisions

EF Core Code-First migrations themselves live inside
`backend/SkillTrack.Infrastructure/Migrations` and are the actual source of truth for
the schema — this folder is documentation and supporting scripts, not the primary way
the schema is managed.

## seed-data/

Seed data (skill categories, sample skills, a demo learning path, etc.) used by both
local development setup and automated tests. Format (JSON vs. SQL) will be decided
when the seeding step is built, since it needs to match how `Infrastructure/Seeding`
loads it.
