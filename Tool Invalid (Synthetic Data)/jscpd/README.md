# jscpd

Inverse-corpus counterpart to the sibling CSharp-Tools-Clean's **jscpd**
folder: a synthetic C# project engineered so the real tool finds a
genuine, non-vacuous duplicate block.

Package: jscpd 5.3.3 (npm)

Domain: granite quarry block tally (QuarryBlockTally)

**Measured**: installed and actually invoked against this folder's own
source; the result below is real, not asserted.

## What "wrong" means here

`SummarizeGranite()` and `SummarizeBasalt()` are a copy-pasted-with-renames
pair -- identical accumulation loop and identical report-string shape,
differing only in the field name and a literal. Real, detectable
duplication well over the 5-line / 30-token floor, not a coincidental
structural echo.

## Command

```bash
jscpd src/ --format csharp --min-lines 5 --min-tokens 30 --threshold 0
```

Real measured output:

```text
Clone found (csharp)
 - domain.cs [36:44 - 43:28] (8 lines, 48 tokens)
   domain.cs [52:43 - 59:28]
Found 1 clones.
ERROR: jscpd found too many duplicates (11.8%) over threshold (0.0%)
```

## Notes

The format token is `csharp`, not `c#` -- the project's own
`csharp-repos-build-contract.md` records that `c#` silently matches zero
files and still exits 0, a structurally-zero result indistinguishable from
a clean scan unless the file count is also checked. This folder's real run
matched 1 file and found the planted clone -- a genuine, non-vacuous
finding.

## Per-family results

| Family | Toolchain | Compiles | Result |
|---|---|---|---|
| `netfx45` | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | yes | **FINDING** (1 clone, 8 lines / 48 tokens) |
| `netfx46` | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | yes | **FINDING** (1 clone, 8 lines / 48 tokens) |
| `netcoreapp30` | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime) | yes | **FINDING** (1 clone, 8 lines / 48 tokens) |
| `net9` | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime) | yes | **FINDING** (1 clone, 8 lines / 48 tokens) |
| `net10` | net10.0 (dotnet-sdk-10.0, native) | yes | **FINDING** (1 clone, 8 lines / 48 tokens) |

Identical source, identical measured result, across all five boundary
families -- jscpd's tokeniser is version-blind, so the finding does not
and should not move with the language version.
