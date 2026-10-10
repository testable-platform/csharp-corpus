# Trivy

Synthetic, clean-by-design C# project for **Trivy**.

Package: github.com/aquasecurity/trivy (Go binary / GitHub release)

Domain: shipping container package manifest (ContainerManifestScan)

**Not installed here**: see Notes for why, and what was checked instead.

## What a passing result looks like

A Trivy filesystem scan of ContainerManifestScan's declared packages would report zero known-vulnerable dependencies.

## Command

```bash
trivy fs .
```

## Notes

Trivy ships as a GitHub Release binary or via its own apt repository at `aquasecurity.github.io`; both return 403 at this sandbox's egress proxy (measured directly), and `go install` is blocked the same way it was in the sibling TypeScript and Java corpora (`proxy.golang.org` not in the allowlist). No package for it exists in Ubuntu's own apt archive.

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
