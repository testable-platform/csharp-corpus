# Roslyn

Inverse-corpus counterpart to the sibling CSharp-Tools-Clean's **Roslyn**
folder: a synthetic C# project engineered so the SDK's own bundled
`Microsoft.CodeAnalysis.NetAnalyzers` genuinely fires, on the one family
that can actually run them.

Package: Microsoft.CodeAnalysis (bundled with the .NET SDK)

Domain: quarry blast scheduling queue (BlastScheduling)

**Measured**: installed (bundled with the SDK) and actually invoked; the
result below is real, not asserted.

## What "wrong" means here

`BlastScheduling` plants two real `CA1822` violations -- `FormatPriorityLabel`
and `PriorityWeight` are both instance methods that never touch `this` or
the queue, so the real analyzer flags both as "does not access instance
data and can be marked as static." With `TreatWarningsAsErrors=true` (the
same project settings as the sibling Clean folder, minus the one targeted
suppression below), the build genuinely fails.

## Command

```bash
dotnet build
```

Real measured output (net10 only):

```text
src/BlastScheduling.cs(51,23): error CA1822: Member 'FormatPriorityLabel' does not access instance data and can be marked as static
src/BlastScheduling.cs(75,20): error CA1822: Member 'PriorityWeight' does not access instance data and can be marked as static

Build FAILED.
    0 Warning(s)
    2 Error(s)
```

Both are real, reproducible `CA1822` findings, not an asserted failure --
and the project deliberately does **not** add `CA1822` to `NoWarn` (it
keeps the sibling Clean folder's `CA1848;CA2007;CA1510` suppressions,
which are unrelated style rules, and nothing more).

## Notes

The project's own `csharp-repos-build-contract.md` flags `Roslyn`/`roslyn
sast` as not being pinnable package names and names
SonarAnalyzer.CSharp/Roslynator/NetAnalyzers as the real resolution -- all
three ship on NuGet, blocked here. But the CA rule family
(`Microsoft.CodeAnalysis.NetAnalyzers`) has shipped bundled inside the .NET
SDK itself since .NET 5, needing no NuGet restore at all, exactly as the
sibling Clean folder documents.

## Per-family results

| Family | Toolchain | Compiles | Result |
|---|---|---|---|
| `netfx45` | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | yes | NOT_INSTALLED |
| `netfx46` | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | yes | NOT_INSTALLED |
| `netcoreapp30` | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime) | yes | NOT_INSTALLED |
| `net9` | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime) | yes | NOT_INSTALLED |
| `net10` | net10.0 (dotnet-sdk-10.0, native) | yes | **FINDING** (2 real CA1822 errors, build fails) |

**Only net10 actually runs `dotnet build` with the SDK's bundled
NetAnalyzers** -- identical to the sibling Clean corpus's own Roslyn
folder, and for the same two, family-specific, measured reasons (not one
blanket excuse):

- **netfx45, netfx46**: Mono's `mcs`/`mono` path has no MSBuild pipeline at
  all for `dotnet build`'s bundled analyzers to hook into -- a structural
  absence, independent of NuGet.
- **netcoreapp30, net9**: `dotnet build` was genuinely attempted (not
  skipped) and fails at real package restore -- `NU1301`, unable to reach
  `api.nuget.org` -- because neither installed SDK (8.0.131, 10.0.112)
  bundles that family's own `Microsoft.NETCore.App.Ref` targeting pack.

**Roslyn is the one tool in this corpus whose result genuinely depends on
the family** -- every other live-checkable tool's row is flat (FINDING x5),
not because the family never held it back, but because each of those
tools' own blocker (or, here, enabler) is entirely independent of target
framework.
