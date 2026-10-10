# Semgrep

Synthetic, clean-by-design C# project for **Semgrep**.

Package: semgrep 1.178.0 (PyPI, standalone)

Domain: armored transport manifest sealing (TransportManifest)

**Measured**: installed (or built from real source) and actually invoked in the build environment; the result below is real, not asserted.

## What a passing result looks like

`semgrep --config rules.yml` reports zero findings against TransportManifest, which seals cargo manifests with HMAC-SHA256, verifies them with `CryptographicOperations.FixedTimeEquals`, and generates key material with `RandomNumberGenerator`.

## Command

```bash
semgrep --config rules.yml src/
```

## Notes

Semgrep's tree-sitter grammar covers C# directly (verified: a quick pattern match against a throwaway file returned a real finding). The ruleset was verified non-vacuous by running it against a deliberately bad sample file before shipping this folder: all 4 rules fired for real (hardcoded secret, weak hash, insecure random, non-constant-time compare).

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
