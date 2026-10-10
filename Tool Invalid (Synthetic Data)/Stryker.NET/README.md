# Stryker.NET

Inverse-corpus counterpart to the sibling CSharp-Tools-Clean's
**Stryker.NET** folder. Stays **NOT_INSTALLED** here too -- the blocker is
infrastructure (NuGet / no restorable test framework), not anything about
this corpus being Clean or Invalid, so there is nothing to invert.

Package: dotnet-stryker (NuGet global tool)

Domain: tea plantation harvest grading ledger (HarvestGradingLedger)

**Not installed here**: see Notes for why, and what was checked instead.

## What a result would look like

Stryker.NET's real mutation-testing run against HarvestGradingLedger would
report a real mutation score -- low, for this corpus, since the fixture's
own test coverage is deliberately thin. Not measurable here: see Notes.

## Command

```bash
dotnet stryker
```

## Notes

`dotnet tool install -g dotnet-stryker` requires NuGet, which this
sandbox's egress proxy refuses; Stryker.NET also needs a restorable test
project (xUnit/NUnit/MSTest), themselves NuGet-only and equally
unreachable. The project's own build-contract doc separately flags
Stryker.NET as a category error for the Data-Flow-coverage metrics it is
declared primary for -- a defect in the roster independent of this
sandbox's network block. Identical to the sibling Clean corpus's own
finding.

## Per-family results

| Family | Toolchain | Compiles | Result |
|---|---|---|---|
| `netfx45` | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | yes | NOT_INSTALLED |
| `netfx46` | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | yes | NOT_INSTALLED |
| `netcoreapp30` | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime) | yes | NOT_INSTALLED |
| `net9` | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime) | yes | NOT_INSTALLED |
| `net10` | net10.0 (dotnet-sdk-10.0, native) | yes | NOT_INSTALLED |
