# CSharp-Tools-Invalid

A folder of 17 tool-named projects, mirroring the folder names and
boundary-version structure of the sibling **CSharp-Tools-Clean** corpus.
This corpus is the deliberate inverse: each folder is a small **synthetic**
project, engineered so that the tool it is named after finds something
genuinely, majority **wrong** -- confirmed by actually installing (or,
where genuinely unreachable, honestly recording as absent) and invoking
the real tool, never by assertion.

This is the negative control of the negative control. Clean proves a scan
that finds nothing really ran; Invalid proves a scan that finds something
really measured it, and that the "something" is the majority of the
fixture, not an edge case. "Declared support is a claim; invoking is the
fact" applies here exactly as it does in Clean.

## Boundary-version structure -- identical to Clean

16 of the 17 tools are exploded into five per-tool subfolders, one per
boundary family -- **2 earliest + 1 middle + 2 latest**, the same shape as
every sibling corpus:

| Family | Role | Toolchain | How it's verified |
| --- | --- | --- | --- |
| `netfx45` | earliest | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | **live** -- real Mono compile, no NuGet involved |
| `netfx46` | earliest+1 | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | **live** -- real Mono compile, no NuGet involved |
| `netcoreapp30` | middle | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime) | **live** -- real manual `csc` compile, bypasses NuGet entirely |
| `net9` | latest-1 | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime) | **live** -- same manual-compile technique |
| `net10` | latest | net10.0 (dotnet-sdk-10.0, native) | **live** -- real `dotnet build`/`dotnet run`, current LTS |

Same three toolchains as Clean (Mono, manual `csc` against the installed
runtime's own implementation assemblies, and native `dotnet`), none of them
touching NuGet. The domain source for every versionable tool compiles
**unmodified** at every one of the five targets -- plain, langversion-6-safe
C# throughout, since `mcs`'s own ceiling (langversion 6 for both Mono
families) is the binding constraint, exactly as in Clean.

The remaining 2 tools -- **diff-cover, pydriller** -- stay single-version
and unversioned, like their counterparts in Clean and in every sibling
corpus: both mine git history and a coverage report, not language/runtime
version.

**`unilyze` was previously, incorrectly, listed here as a third
"unversioned/no-folder" tool**, on the claim that it "names no real tool."
That was wrong: unilyze is a real, actively maintained .NET/C# code-analysis
CLI (github.com/bigdra50/unilyze, MIT, v0.6.1), confirmed by downloading and
running the actual GitHub release binary -- the earlier verdict mistook an
unrelated, long-dead PyPI package of the same name for the real tool; see
`csharp-repos-build-contract.md` for the full correction. unilyze is now
exploded into the same five boundary families as the other 12 versionable
tools, below, with a genuinely wrong (3-of-4-methods-flagged) result.

## Measured results (13 versioned tools x 5 families = 65 cells)

| Tool | netfx45 | netfx46 | netcoreapp30 | net9 | net10 |
| --- | --- | --- | --- | --- | --- |
| Coverlet | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED |
| Dolos | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED |
| Lizard | **FINDING** | **FINDING** | **FINDING** | **FINDING** | **FINDING** |
| MiniCover | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED |
| OpenTelemetry .NET | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED |
| Opengrep (semgrep stand-in) | **FINDING** | **FINDING** | **FINDING** | **FINDING** | **FINDING** |
| Roslyn | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | **FINDING** |
| Semgrep | **FINDING** | **FINDING** | **FINDING** | **FINDING** | **FINDING** |
| Stryker.NET | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED |
| Trivy | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED |
| altcover | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED |
| jscpd | **FINDING** | **FINDING** | **FINDING** | **FINDING** | **FINDING** |
| unilyze | **FINDING** | **FINDING** | **FINDING** | **FINDING** | **FINDING** |

**Tally: 26 FINDING, 0 CLEAN, 39 NOT INSTALLED** (out of 65 cells). The
exact mirror image of Clean's own 26 CLEAN / 0 FINDING / 39 NOT_INSTALLED
tally -- same 65 cells, same split, opposite verdict on every
live-checkable one.

Plus the 2 unversioned/no-folder tools:

| Tool | Result | Command |
| --- | --- | --- |
| diff-cover | **FINDING** -- 33% diff coverage (2/6 new lines covered) | `diff-cover coverage/cobertura-coverage.xml --compare-branch main` |
| pydriller | **FINDING** -- 62.5% of tagged commits (5/8) mismatch their claimed area | `python3 driver.py` |

**NOT INSTALLED** (altcover, Coverlet, Dolos, MiniCover, OpenTelemetry .NET,
Stryker.NET, Trivy -- unchanged from Clean, across every family): this
sandbox's egress proxy refuses NuGet entirely, GitHub Release downloads,
and `nodejs.org`'s header tarball -- the identical, measured block Clean's
own README documents. That blocking has nothing to do with whether the
fixture is Clean or Invalid, so these 7 tools show the identical result in
both corpora; see each tool's own README for the exact reason. (unilyze's
own GitHub Release download is *not* blocked here either -- same as in
Clean -- so it is not among these 7.)

**Roslyn is the one tool whose result genuinely depends on the family**
(see Genuine findings below) -- every other versioned tool's row is flat
(FINDING x5 or NOT_INSTALLED x5), not because the family never held it
back, but because each of those 11 tools' own blocker (or enabler) is
entirely independent of target framework.

The exit-code vocabulary throughout this corpus never collapses findings,
skipped, and not-installed into the same result -- a missing binary must
never masquerade as a genuine result either way.

## Genuine findings (not papered over)

**Roslyn (`Microsoft.CodeAnalysis.NetAnalyzers`) only actually runs on
net10**, for the identical two family-specific reasons Clean's own README
documents:

- **netfx45, netfx46**: Mono's `mcs`/`mono` path has no MSBuild pipeline at
  all for `dotnet build`'s bundled analyzers to hook into -- a structural
  absence, independent of NuGet.
- **netcoreapp30, net9**: `dotnet build` was genuinely attempted (not
  skipped) and fails at real package restore -- `NU1301`, unable to reach
  `api.nuget.org`.

On the one family that can run it, it genuinely finds something: two
planted `CA1822` violations (`FormatPriorityLabel`, `PriorityWeight` --
both instance methods that never touch instance state), and with
`TreatWarningsAsErrors=true` the build genuinely fails. Three distinct
failure/finding modes for the same single tool across five families, all
confirmed by direct invocation.

## Rules every folder obeys -- same hygiene as Clean, inverted only on purpose

- No suppression anywhere -- no `#pragma warning disable`, no `NoWarn`
  entry beyond the two unrelated style rules (`CA1848`, `CA2007`) Clean
  itself already carried, no jscpd/lizard ignore directives. A finding
  must be real and undisguised.
- Pure ASCII throughout -- verified corpus-wide.
- Real git history (3 real commits on `main`, 1 more on `feature`) for
  diff-cover; a real 9-commit history for pydriller.
- Same domain source, unmodified, across all five families of a given
  tool -- only the compiling toolchain (Mono profile, manual `csc` target,
  or native SDK) differs per family.
- No fabricated tool results. Where a named tool could not be run at all,
  the folder says so and, where a real adjacent tool could stand in
  (Opengrep -> semgrep), that stand-in was actually run and its real
  result reported -- never presented as the named tool's own output.
- A different domain, vocabulary and structural idiom in every folder.

## Layout

```text
<Tool Name>/
  README.md                 what wrong means for this tool, the per-family results
  netfx45/ netfx46/         each holds its own src/ copy, compiled at that
  netcoreapp30/ net9/       family's own boundary via its own real toolchain
  net10/
  security-rules.yml        Opengrep's local semgrep ruleset -- shared, family-independent
  rules.yml                 Semgrep's own ruleset -- shared, family-independent
  .git/                     only where the tool mines real history (diff-cover, pydriller)
_generator/                 family_table.py, generate.py, verify_live.py
```

## Reproducing

```bash
python3 _generator/generate.py       # explode each tool's domain.cs into netfx45/netfx46/netcoreapp30/net9/net10
python3 _generator/verify_live.py    # real compile + real tool run for every live tool, every family
```

`verify_live.py` needs `mono-complete`, `dotnet-sdk-8.0` and
`dotnet-sdk-10.0` (apt) on this host, plus the same `lizard`/`jscpd`/
`semgrep`/`pydriller`/`diff_cover`/`unilyze` PyPI/npm/GitHub-release
packages used by Clean.

## Tool versions used for the measurement

```text
dotnet sdk       8.0.131 (apt, dotnet-sdk-8.0)
dotnet sdk       10.0.112 (apt, dotnet-sdk-10.0)
mono             6.8.0.105 (apt, mono-complete)
lizard           1.24.0 (PyPI)
jscpd            5.3.3 (npm)
semgrep          1.178.0 (PyPI, standalone -- also stand-in for Opengrep)
pydriller        2.12 (PyPI)
diff-cover (diff_cover) 10.6.0 (PyPI)
unilyze          0.6.1 (GitHub Release binary, github.com/bigdra50/unilyze, linux-x64)
Microsoft.CodeAnalysis.NetAnalyzers  bundled with dotnet-sdk-10.0 (no NuGet)
```

Verified on Linux, Ubuntu 24.04 -- the same build environment as
CSharp-Tools-Clean's own measurement.

<!-- alignment-2026-10 -->
## Alignment (October 2026)

- **No project files.** Every `.csproj` and `NuGet.Config` was removed. A project file makes the platform treat its folder as a separate project and run the whole tool roster on it. Where a tool's README below mentions a `.csproj`, that is history. Roslyn's analyzer settings are now in `Roslyn/.editorconfig`.
- **Roster complete.** `Roslyn SAST` and `NuGet Audit` were added at all five versions. `Trivy` gained `sbom.cdx.json` per version, because its .NET scanner reads manifests and SBOMs, not source.
- **netfx45 is real C# 5.** The shared domain sources used C# 6 syntax (auto-property initializers, `nameof`, string interpolation, expression-bodied properties, read-only auto-properties); the `netfx45` copies were rewritten with identical behaviour. The other four versions are unchanged.
- **Version markers.** Each versioned tool folder holds `src/LanguageMarker.cs`: a class legal at that version's C# language level and rejected one level below (netfx45 = C# 5, netfx46 = C# 6, netcoreapp30 = C# 8.0, net9 = C# 13.0, net10 = C# 14.0).
- `NuGet Audit` carries `expected-advisories.json` instead of a manifest: `dotnet package list --vulnerable` needs a restored project, so the audit's real input stays the branch's own root project.
