# jscpd

Synthetic, clean-by-design C# project for **jscpd**.

Package: jscpd 5.3.3 (npm)

Domain: granite quarry block tally (QuarryBlockTally)

**Measured**: installed (or built from real source) and actually invoked in the build environment; the result below is real, not asserted.

## What a passing result looks like

`jscpd --format csharp` finds zero duplicate blocks in QuarryBlockTally's own source at 5 lines / 30 tokens.

## Command

```bash
jscpd src/ --format csharp --min-lines 5 --min-tokens 30 --threshold 0
```

## Notes

The format token is `csharp`, not `c#` -- the project's own build-contract doc records that `c#` silently matches zero files and still exits 0, a structurally-zero result indistinguishable from a clean scan unless the file count is also checked. This folder's real run matched 1 file, 259 tokens -- a genuine, non-vacuous zero.

## Per-family results

Boundary families this tool was exploded into, and what each one's own real invocation found (not asserted -- see `_generator/verify_live.py`):

| Family | Toolchain | Compiles | Result |
|---|---|---|---|
| `netfx45` | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | yes | CLEAN |
| `netfx46` | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | yes | CLEAN |
| `netcoreapp30` | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime, rollForward LatestMajor) | yes | CLEAN |
| `net9` | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime, rollForward LatestMajor) | yes | CLEAN |
| `net10` | net10.0 (dotnet-sdk-10.0, native) | yes | CLEAN |

Per-family notes:

**netfx45**: Reads source text only (or, for Semgrep/Opengrep, parses with a tree-sitter grammar) -- entirely version-blind. The real tool was re-invoked against this family's own compiled-for-real copy of the source.

**netfx46**: Reads source text only (or, for Semgrep/Opengrep, parses with a tree-sitter grammar) -- entirely version-blind. The real tool was re-invoked against this family's own compiled-for-real copy of the source.

**netcoreapp30**: Reads source text only (or, for Semgrep/Opengrep, parses with a tree-sitter grammar) -- entirely version-blind. The real tool was re-invoked against this family's own compiled-for-real copy of the source.

**net9**: Reads source text only (or, for Semgrep/Opengrep, parses with a tree-sitter grammar) -- entirely version-blind. The real tool was re-invoked against this family's own compiled-for-real copy of the source.

**net10**: Reads source text only (or, for Semgrep/Opengrep, parses with a tree-sitter grammar) -- entirely version-blind. The real tool was re-invoked against this family's own compiled-for-real copy of the source.
