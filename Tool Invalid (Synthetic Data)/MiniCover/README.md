# MiniCover

Inverse-corpus counterpart to the sibling CSharp-Tools-Clean's **MiniCover**
folder. Stays **NOT_INSTALLED** here too -- the blocker is infrastructure
(NuGet), not anything about this corpus being Clean or Invalid, so there is
nothing to invert.

Package: MiniCover 3.10.0 (NuGet global tool)

Domain: citrus grove irrigation zones (GroveIrrigationZones)

**Not installed here**: see Notes for why, and what was checked instead.

## What a result would look like

MiniCover's IL-instrumented coverage run would report real statement
coverage for GroveIrrigationZones. Not measurable here: see Notes.

## Command

```bash
minicover instrument && dotnet test && minicover report
```

## Notes

`dotnet tool install -g minicover` requires NuGet, which this sandbox's
egress proxy refuses. Per the project's own build-contract doc (read from
MiniCover's own `.csproj`), it additionally declares SDK 8.0/9.0/10.0
only -- the one tool setting a floor across the whole corpus -- but that
floor is moot here since the package cannot be obtained at all. Identical
to the sibling Clean corpus's own finding.

## Per-family results

| Family | Toolchain | Compiles | Result |
|---|---|---|---|
| `netfx45` | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | yes | NOT_INSTALLED |
| `netfx46` | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | yes | NOT_INSTALLED |
| `netcoreapp30` | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime) | yes | NOT_INSTALLED |
| `net9` | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime) | yes | NOT_INSTALLED |
| `net10` | net10.0 (dotnet-sdk-10.0, native) | yes | NOT_INSTALLED |
