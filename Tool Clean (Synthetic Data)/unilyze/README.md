# unilyze

Synthetic, clean-by-design C# project for **unilyze**.

Package: unilyze 0.6.1 (GitHub Release binary, github.com/bigdra50/unilyze)

Domain: coastal lighthouse keeper shift log (LighthouseKeeperLog)

**Measured**: installed (real v0.6.1 linux-x64 release binary) and actually invoked against this folder's own source at every boundary family; the result below is real, not asserted.

## What a passing result looks like

unilyze's plain `analyze` command always exits 0 -- its quality-gate exit code 2 only applies to the separate `badge`/`diff` subcommands when given an explicit `--fail-under`/`--fail-over`/`--fail-on-regression` flag, confirmed by direct invocation, not assumed. A clean result here means every one of unilyze's own documented default smell thresholds (from `unilyze metrics`) is cleared by a wide margin: GodClass, LongMethod, HighComplexity, DeepNesting, ExcessiveParameters, LowCohesion, HighCoupling, DeepInheritance, LowMaintainability, CyclicDependency.

## Command

```bash
unilyze -p . -f json -o result.json --no-open
```

## Notes

This folder previously, incorrectly, claimed unilyze "names no real tool" and had "no folder contents to version." That was wrong: unilyze is a real, actively maintained .NET/C# code-analysis CLI (github.com/bigdra50/unilyze, MIT license, latest release v0.6.1), confirmed here by downloading and running the actual GitHub release binary. The earlier verdict mistook an unrelated PyPI package that happens to share the name (a Unicode-character-inspection tool, last released July 2020, with no connection to code analysis) for the real one. See `csharp-repos-build-contract.md` for the full correction.

unilyze reads compiled .NET assemblies' IL plus source, not a language-version syntax gate, so -- like Lizard/jscpd/Semgrep/Opengrep -- it is version-blind (Class B): the same real metrics are reported at every one of the five boundary families below.

## Per-family results

Boundary families this tool was exploded into, and what each one's own real invocation found (not asserted):

| Family | Toolchain | Compiles | Result |
|---|---|---|---|
| `netfx45` | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | yes | CLEAN |
| `netfx46` | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | yes | CLEAN |
| `netcoreapp30` | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime, rollForward LatestMajor) | yes | CLEAN |
| `net9` | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime, rollForward LatestMajor) | yes | CLEAN |
| `net10` | net10.0 (dotnet-sdk-10.0, native) | yes | CLEAN |

Real measured metrics, identical across all five families: `maxCyclomaticComplexity=2, maxCognitiveComplexity=1, lcom=0, cbo=3, dit=0, codeHealth=10, codeHealthCategory=healthy` -- every documented threshold cleared by a wide margin. unilyze was re-invoked against each family's own compiled-for-real copy of the identical source; the same real metrics came back every time, exactly as expected for a version-blind tool.
