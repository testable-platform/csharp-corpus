# OpenTelemetry .NET

Synthetic, clean-by-design C# project for **OpenTelemetry .NET**.

Package: OpenTelemetry / OpenTelemetry.Exporter.Console (NuGet)

Domain: signal tower diagnostic pings (SignalTowerDiagnostics)

**Not installed here**: see Notes for why, and what was checked instead.

## What a passing result looks like

A real `TracerProvider` wired to an in-memory exporter would confirm SignalTowerDiagnostics emits spans with the expected attributes.

## Command

```bash
dotnet run
```

## Notes

Every OpenTelemetry .NET package (`OpenTelemetry`, `OpenTelemetry.Exporter.Console`, etc.) ships only on NuGet, which this sandbox's egress proxy refuses; there is no apt package and no dependency-free way to construct a real SDK `TracerProvider` without the SDK assembly itself. Unlike diff-cover's coverage report (a plain file format this corpus can produce honestly on its own), there is no substitute source for the actual OpenTelemetry .NET library.

## Per-family results

Boundary families this tool was exploded into, and what each one's own real invocation found (not asserted -- see `_generator/verify_live.py`):

| Family | Toolchain | Compiles | Result |
|---|---|---|---|
| `netfx45` | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | yes | NOT_INSTALLED |
| `netfx46` | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | yes | NOT_INSTALLED |
| `netcoreapp30` | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime, rollForward LatestMajor) | yes | NOT_INSTALLED |
| `net9` | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime, rollForward LatestMajor) | yes | NOT_INSTALLED |
| `net10` | net10.0 (dotnet-sdk-10.0, native) | yes | NOT_INSTALLED |

Per-family notes:

**netfx45**: Genuinely unreachable in this sandbox -- same reason as the single-version baseline, unaffected by target framework (see this file's own 'Notes' section above).

**netfx46**: Genuinely unreachable in this sandbox -- same reason as the single-version baseline, unaffected by target framework (see this file's own 'Notes' section above).

**netcoreapp30**: Genuinely unreachable in this sandbox -- same reason as the single-version baseline, unaffected by target framework (see this file's own 'Notes' section above).

**net9**: Genuinely unreachable in this sandbox -- same reason as the single-version baseline, unaffected by target framework (see this file's own 'Notes' section above).

**net10**: Genuinely unreachable in this sandbox -- same reason as the single-version baseline, unaffected by target framework (see this file's own 'Notes' section above).
