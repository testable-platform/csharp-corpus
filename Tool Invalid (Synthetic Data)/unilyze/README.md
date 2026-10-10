# unilyze

Inverse-corpus counterpart to the sibling CSharp-Tools-Clean's **unilyze**
folder: a synthetic C# project engineered so the real tool reports a
genuinely, measurably wrong result.

Package: unilyze 0.6.1 (GitHub Release binary, github.com/bigdra50/unilyze)

Domain: coastal lighthouse beacon rotation scheduler (BeaconRotationScheduler)

**Measured**: installed (real v0.6.1 linux-x64 release binary) and actually
invoked against this folder's own source; the result below is real, not
asserted.

## What "wrong" means here

`BeaconRotationScheduler` has 4 public methods. Three are deliberately
engineered over unilyze's own documented default smell thresholds (from
`unilyze metrics`): a flat 16-arm routing switch instead of a lookup table
(`ClassifyBeaconPattern`, cyclomatic complexity 17 against the
HighComplexity threshold of >= 15), a deeply nested condition ladder
instead of a decision table (`DetermineFogHornSchedule`, cognitive
complexity 30 against the HighComplexity threshold of >= 15, and nesting
depth 4 against the DeepNesting threshold of >= 4), and a 7-parameter
report builder (`BuildMaintenanceReport`, 7 params against the
ExcessiveParameters threshold of > 5). Only `IsOperational` is left clean,
as the negative control proving the scan reads the file rather than
flagging everything indiscriminately.

**3 of 4 methods flagged = 75%** -- the same ratio as the sibling Lizard
Invalid fixture.

## Command

```bash
unilyze -p . -f json -o result.json --no-open
```

Real measured output (per-type and per-method metrics, read from
`typeMetrics[0]` in the JSON result):

```text
TYPE BeaconRotationScheduler maxCycCC=17 maxCogCC=30 excessiveParamMethods=1 codeHealth=5.5 category=warning
   ClassifyBeaconPattern     CycCC=17 CogCC=1  params=1 nesting=1
   DetermineFogHornSchedule  CycCC=9  CogCC=30 params=4 nesting=4
   BuildMaintenanceReport    CycCC=1  CogCC=0  params=7 nesting=0
   IsOperational             CycCC=1  CogCC=0  params=1 nesting=0
```

## Notes

This folder previously, incorrectly, claimed unilyze "names no real tool."
That was wrong: unilyze is a real, actively maintained .NET/C# code-analysis
CLI (github.com/bigdra50/unilyze, MIT license, latest release v0.6.1),
confirmed here by downloading and running the actual GitHub release binary
-- the earlier verdict mistook an unrelated, long-dead PyPI package sharing
the same name (a Unicode-character-inspection tool, last released July
2020) for the real tool. See `csharp-repos-build-contract.md` for the full
correction.

unilyze reads compiled .NET assemblies' IL plus source, not a
language-version syntax gate, so it is version-blind (Class B): the same
genuinely-wrong result is reported at every one of the five boundary
families below.

## Per-family results

| Family | Toolchain | Compiles | Result |
|---|---|---|---|
| `netfx45` | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | yes | **FINDING** (3/4 methods over threshold) |
| `netfx46` | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | yes | **FINDING** (3/4 methods over threshold) |
| `netcoreapp30` | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime, rollForward LatestMajor) | yes | **FINDING** (3/4 methods over threshold) |
| `net9` | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime, rollForward LatestMajor) | yes | **FINDING** (3/4 methods over threshold) |
| `net10` | net10.0 (dotnet-sdk-10.0, native) | yes | **FINDING** (3/4 methods over threshold) |

Identical source, identical measured result, across all five boundary
families -- unilyze reads IL/source, not a language-version syntax gate, so
the finding does not and should not move with the target framework.
