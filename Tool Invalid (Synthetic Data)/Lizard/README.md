# Lizard

Inverse-corpus counterpart to the sibling CSharp-Tools-Clean's **Lizard**
folder: a synthetic C# project engineered so the real tool reports a
genuinely, measurably wrong (majority-complex) result.

Package: lizard 1.24.0 (PyPI)

Domain: granite quarry conveyor dispatch (ConveyorDispatch)

**Measured**: installed and actually invoked against this folder's own
source; the result below is real, not asserted.

## What "wrong" means here

`ConveyorDispatch` has 4 public methods. Three are deliberately over the
`-C 10 -L 60 -a 5` thresholds (cyclomatic complexity 10, length 60, params
5) -- a flat 13-way routing switch (`RouteCode`, CCN 14), a chained
condition ladder instead of a table (`PriorityLabel`, CCN 19), and a
6-parameter report builder (`ShiftReport`, 6 params). Only `IsEmpty` is
left clean, as the built-in negative control that proves the scan is
reading the file rather than flagging everything indiscriminately.

**3 of 4 functions flagged = 75%.**

## Command

```bash
lizard --languages csharp src/ -C 10 -L 60 -a 5 -w
```

Real measured output:

```text
domain.cs:28: warning: ConveyorDispatch::RouteCode has 21 NLOC, 14 CCN, 103 token, 1 PARAM, 21 length, 0 ND
domain.cs:52: warning: ConveyorDispatch::PriorityLabel has 55 NLOC, 19 CCN, 238 token, 1 PARAM, 56 length, 0 ND
domain.cs:115: warning: ConveyorDispatch::ShiftReport has 42 NLOC, 1 CCN, 412 token, 6 PARAM, 42 length, 0 ND
```

## Notes

Same cross-language, own-tokeniser package used throughout the sibling
corpora; Lizard never loads a C# compiler, so it is entirely version-blind
(Class B) and the real tool was re-invoked against every family's own
compiled-for-real copy of the identical source.

## Per-family results

| Family | Toolchain | Compiles | Result |
|---|---|---|---|
| `netfx45` | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | yes | **FINDING** (3/4 functions over threshold) |
| `netfx46` | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | yes | **FINDING** (3/4 functions over threshold) |
| `netcoreapp30` | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime) | yes | **FINDING** (3/4 functions over threshold) |
| `net9` | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime) | yes | **FINDING** (3/4 functions over threshold) |
| `net10` | net10.0 (dotnet-sdk-10.0, native) | yes | **FINDING** (3/4 functions over threshold) |

Identical source, identical measured result, across all five boundary
families -- Lizard reads text, not a compiled target, so the finding does
not and should not move with the language version.
