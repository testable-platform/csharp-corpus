# Coverlet

Synthetic, clean-by-design C# project for **Coverlet**.

Package: coverlet.collector / coverlet.msbuild (NuGet)

Domain: aviary breeding clutch record (AviaryBreedingRecord)

**Not installed here**: see Notes for why, and what was checked instead.

## What a passing result looks like

Coverlet's cross-platform coverage collector would report full statement and branch coverage from a real `dotnet test` run against AviaryBreedingRecord.

## Command

```bash
dotnet test --collect:"XPlat Code Coverage"
```

## Notes

Coverlet's collector and its VSTest data-collector plumbing are NuGet-only; `api.nuget.org` is blocked here (same measured 403 as every other NuGet-only tool in this corpus). No test framework (xUnit/NUnit/MSTest) is installable either -- all three are NuGet packages too, and Ubuntu's apt-packaged NUnit (2.6.3, Mono-era CIL assemblies) predates SDK-style .csproj entirely and cannot host a net8.0 test project. The source still compiles clean.

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
