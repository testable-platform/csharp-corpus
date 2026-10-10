# Opengrep

Synthetic, clean-by-design C# project for **Opengrep**.

Package: opengrep/opengrep (Go binary / GitHub release)

Domain: armory checkpoint clearance control (CheckpointClearance)

**Measured**: installed (or built from real source) and actually invoked in the build environment; the result below is real, not asserted.

Stand-in tool actually run: `semgrep`

## What a passing result looks like

Opengrep is a semgrep fork sharing its rule format; not reachable here (see notes), so `semgrep` -- already installed, and used the same way as this corpus's own Semgrep folder -- was run for real against a local custom ruleset (hardcoded secrets, weak hashes, insecure randomness, non-constant-time comparison) and found zero findings.

## Command

```bash
semgrep --config security-rules.yml src/
```

## Notes

Opengrep's real distribution is a GitHub Release binary, and GitHub Releases return 403 at this sandbox's egress proxy (measured directly), with no apt or go-install route either. Same treatment as the sibling TypeScript and JavaScript corpora's Opengrep folders.

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
