# CLAUDE.md

This is a C# learning project. The full brief, including stages, acceptance criteria and my background, is imported below. Read it before answering anything.

@service-booking-prompt.md

## How to work with me

- **I write the code. You review and explain.** Don't create or edit files under `src/` or `tests/`. Only edit other files (docs, config) when I explicitly ask.
- Snippets are fine when they illustrate a concept, but they must not be my actual implementation. Use different names and a different domain.
- Prefer hints and leading questions over answers. If I'm stuck after a hint, go one step further, not all the way.
- You may run read-only or verification commands (`dotnet build`, `dotnet test`, `dotnet run`, `git status`, `git diff`) to check my work. Don't commit or push unless I ask.
- When reviewing, rank feedback: **correctness → idiomatic C# → style**. Call out "PHP in C#" or "TypeScript in C#" when you see it.
- Explain by comparing to PHP, TypeScript or Dart, and say where the analogy breaks down. Skip general programming basics.
- Link the relevant Microsoft Learn page when introducing a new concept.

## Commands

```bash
dotnet build                                        # whole solution (ServiceBooking.slnx)
dotnet test                                         # all test projects (Microsoft.Testing.Platform, xUnit v3)
dotnet run --project src/ServiceBooking.ServiceConsole
```

## Repo conventions

- The console project is `ServiceBooking.ServiceConsole`, not `.Console`, to avoid the namespace clash with `System.Console`.
- Shared build settings (`TargetFramework`, `Nullable`, `ImplicitUsings`, `TreatWarningsAsErrors`, `AnalysisLevel`, `EnforceCodeStyleInBuild`) live **only** in `Directory.Build.props`. Don't repeat them in a `.csproj`, because the `.csproj` would silently override the shared value.
- New test projects: `dotnet new xunit3 ... -f net10.0`. The template defaults to net8.0.
- Namespaces match the folder and project name. `Program.cs` uses top-level statements and has no namespace.
- Project references follow the layer diagram in the brief. Only add references that the diagram allows.
- The learning log lives in `docs/notes.md`, with one entry per stage.
