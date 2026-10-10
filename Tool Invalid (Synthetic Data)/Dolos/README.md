# Dolos

Inverse-corpus counterpart to the sibling CSharp-Tools-Clean's **Dolos**
folder. Stays **NOT_INSTALLED** here too -- the blocker is infrastructure
(a blocked native-module rebuild), not anything about this corpus being
Clean or Invalid, so there is nothing to invert.

Package: @dodona/dolos 2.x + @dodona/dolos-parsers 1.4.1 (npm)

Domain: textile mill loom shift log (LoomShiftLog)

**Not installed here**: see Notes for why, and what was checked instead.

## What a result would look like

A Dolos similarity scan would compare LoomShiftLog against a near-identical
sibling file and report high cross-submission similarity. Not measurable
here: see Notes.

## Command

```bash
dolos src/
```

## Notes

Measured, not assumed: `npm install @dodona/dolos` was actually run (again)
for this corpus. `@dodona/dolos-parsers` needs a native `node-gyp` rebuild,
which tries to download Node's own header tarball from `nodejs.org` to
compile against -- that host is refused by this sandbox's egress proxy, so
the build fails (`gyp ERR! Request was cancelled`) and the package never
installs. Identical to the sibling Clean corpus's own finding, on this
exact host and this exact Node version.

## Per-family results

| Family | Toolchain | Compiles | Result |
|---|---|---|---|
| `netfx45` | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | yes | NOT_INSTALLED |
| `netfx46` | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | yes | NOT_INSTALLED |
| `netcoreapp30` | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime) | yes | NOT_INSTALLED |
| `net9` | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime) | yes | NOT_INSTALLED |
| `net10` | net10.0 (dotnet-sdk-10.0, native) | yes | NOT_INSTALLED |
