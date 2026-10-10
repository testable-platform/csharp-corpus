# Roslyn

Synthetic, clean-by-design C# project for **Roslyn**.

Package: Microsoft.CodeAnalysis (bundled with the .NET SDK)

Domain: observatory telescope scheduling queue (TelescopeScheduling)

**Measured**: installed (or built from real source) and actually invoked in the build environment; the result below is real, not asserted.

## What a passing result looks like

`dotnet build` with `EnableNETAnalyzers`, `AnalysisMode=All`, `AnalysisLevel=latest-all`, nullable reference types and `TreatWarningsAsErrors` reports zero warnings against TelescopeScheduling.

## Command

```bash
dotnet build
```

## Notes

The project's own build-contract doc flags `Roslyn`/`roslyn sast` as not being pinnable package names (19 metrics) and names SonarAnalyzer.CSharp/Roslynator/NetAnalyzers as the real resolution -- all three ship on NuGet, blocked here. But the CA rule family (`Microsoft.CodeAnalysis.NetAnalyzers`) has shipped bundled inside the .NET SDK itself since .NET 5, needing no NuGet restore at all: `dotnet build` here genuinely invoked real Roslyn analyzers (confirmed non-vacuous -- CA1510 and CA1822 both fired for real on the first draft of this file, before the fixes below) rather than a no-op.

## Per-family results

Boundary families this tool was exploded into, and what each one's own real invocation found (not asserted -- see `_generator/verify_live.py`):

| Family | Toolchain | Compiles | Result |
|---|---|---|---|
| `netfx45` | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | yes | NOT_INSTALLED |
| `netfx46` | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | yes | NOT_INSTALLED |
| `netcoreapp30` | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime, rollForward LatestMajor) | yes | NOT_INSTALLED |
| `net9` | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime, rollForward LatestMajor) | yes | NOT_INSTALLED |
| `net10` | net10.0 (dotnet-sdk-10.0, native) | yes | CLEAN |

Per-family notes:

**netfx45**: Mono compiles and runs real .NET Framework 4.5 code, but there is no MSBuild/`dotnet build` pipeline in that path at all -- `Microsoft.CodeAnalysis.NetAnalyzers` hooks into the SDK-style build pipeline (`dotnet build`'s own analyzer targets), not into `mcs`. No SDK-style build was ever attempted for this family; it genuinely cannot happen, independent of NuGet.

**netfx46**: Same reason as netfx45: Mono's `mcs`/`mono` path has no SDK-style `dotnet build` pipeline for NetAnalyzers to hook into.

**netcoreapp30**: `dotnet build` was actually attempted and fails at restore -- `NU1301`, unable to reach `api.nuget.org` -- before Roslyn or its analyzers ever run. Neither installed SDK (8.0.131, 10.0.112) bundles netcoreapp3.0's own `Microsoft.NETCore.App.Ref` targeting pack; it is NuGet-only and NuGet is blocked at the egress proxy (measured directly, not assumed).

**net9**: Same failure mode as netcoreapp3.0, one family later: `dotnet build` under SDK 10.0.112 reaches restore and fails with the identical `NU1301` -- net9.0's own targeting pack is NuGet-only too. The manual `csc` compile this corpus uses elsewhere for net9.0 bypasses MSBuild entirely, which is exactly why it cannot carry the MSBuild-integrated NetAnalyzers pipeline with it.

**net10**: `dotnet build` ran for real with `Microsoft.CodeAnalysis.NetAnalyzers` bundled in the SDK, `AnalysisMode=All`, `AnalysisLevel=latest-all` and `TreatWarningsAsErrors=true` -- 0 warnings, 0 errors.
