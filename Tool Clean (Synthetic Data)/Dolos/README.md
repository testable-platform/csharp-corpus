# Dolos

Synthetic, clean-by-design C# project for **Dolos**.

Package: @dodona/dolos 2.x + @dodona/dolos-parsers 1.4.1 (npm)

Domain: textile mill loom shift log (LoomCount)

**Not installed here**: see Notes for why, and what was checked instead.

## What a passing result looks like

A Dolos similarity scan of LoomCount against itself would report zero cross-submission similarity above threshold.

## Command

```bash
dolos src/
```

## Notes

Measured, not assumed: `npm install @dodona/dolos` was actually run here. `@dodona/dolos-parsers` needs a native `node-gyp` rebuild, which tries to download Node's own header tarball from `nodejs.org` to compile against -- that host is refused by this sandbox's egress proxy, so the build fails (`gyp ERR! Request was cancelled`) and the package never installs. Confirmed on this exact host and this exact Node version (22.22.2), matching the project's own build-contract finding for its sibling C#-Repos corpus.

## Per-family results

Boundary families this tool was exploded into, and what each one's own real invocation found (not asserted -- see `_generator/verify_live.py`):

| Family | Toolchain | Compiles | Result |
|---|---|---|---|
| `netfx45` | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | yes | NOT_INSTALLED |
| `netfx46` | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | yes | NOT_INSTALLED |
| `netcoreapp30` | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime, rollForward LatestMajor) | yes | NOT_INSTALLED |
| `net9` | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime, rollForward LatestMajor) | yes | NOT_INSTALLED |
| `net10` | net10.0 (dotnet-sdk-10.0, native) | yes | NOT_INSTALLED |

Per-family notes:

**netfx45**: Genuinely unreachable in this sandbox -- same reason as the single-version baseline, unaffected by target framework (see this file's own 'Notes' section above).

**netfx46**: Genuinely unreachable in this sandbox -- same reason as the single-version baseline, unaffected by target framework (see this file's own 'Notes' section above).

**netcoreapp30**: Genuinely unreachable in this sandbox -- same reason as the single-version baseline, unaffected by target framework (see this file's own 'Notes' section above).

**net9**: Genuinely unreachable in this sandbox -- same reason as the single-version baseline, unaffected by target framework (see this file's own 'Notes' section above).

**net10**: Genuinely unreachable in this sandbox -- same reason as the single-version baseline, unaffected by target framework (see this file's own 'Notes' section above).
