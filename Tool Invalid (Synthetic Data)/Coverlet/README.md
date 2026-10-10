# Coverlet

Inverse-corpus counterpart to the sibling CSharp-Tools-Clean's **Coverlet**
folder. Stays **NOT_INSTALLED** here too -- the blocker is infrastructure
(NuGet / no restorable test framework), not anything about this corpus
being Clean or Invalid, so there is nothing to invert.

Package: coverlet.collector / coverlet.msbuild (NuGet)

Domain: aviary hatch clutch record (AviaryHatchRecord)

**Not installed here**: see Notes for why, and what was checked instead.

## What a result would look like

Coverlet's cross-platform coverage collector would report real statement
and branch coverage from a real `dotnet test` run. Not measurable here:
see Notes.

## Command

```bash
dotnet test --collect:"XPlat Code Coverage"
```

## Notes

Coverlet's collector and its VSTest data-collector plumbing are NuGet-only;
`api.nuget.org` is blocked here (same measured 403 as every other
NuGet-only tool in this corpus). No test framework (xUnit/NUnit/MSTest) is
installable either -- all three are NuGet packages too, and Ubuntu's
apt-packaged NUnit (2.6.3, Mono-era CIL assemblies) predates SDK-style
.csproj entirely and cannot host a net8.0 test project. Identical to the
sibling Clean corpus's own finding. The source still compiles clean at
every one of the five boundary families.

## Per-family results

| Family | Toolchain | Compiles | Result |
|---|---|---|---|
| `netfx45` | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | yes | NOT_INSTALLED |
| `netfx46` | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | yes | NOT_INSTALLED |
| `netcoreapp30` | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime) | yes | NOT_INSTALLED |
| `net9` | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime) | yes | NOT_INSTALLED |
| `net10` | net10.0 (dotnet-sdk-10.0, native) | yes | NOT_INSTALLED |
