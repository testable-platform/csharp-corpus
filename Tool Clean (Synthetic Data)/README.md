# CSharp-Tools-Clean

A folder of 17 tool-named projects, mirroring the folder names in the
harvested `C# Tools` directory (each of which holds that tool's own real
upstream test suite). This corpus is the opposite of that: each folder is a
small **synthetic** project, engineered so that the tool it is named after
finds **nothing wrong** -- the same negative-control methodology already
used for the sibling `Python-Tools-Clean`, `JavaScript-Tools-Clean` and
`Java-Tools-Clean` corpora.

A family where nothing ever fires cannot tell "correctly detected nothing"
apart from "the scan never ran." A clean baseline is what makes a zero
legible: every result below was produced by actually installing (or, where
genuinely unreachable, honestly recording as absent) and invoking the real
tool, not by assertion. "Declared support is a claim; invoking is the fact."

## Boundary-version structure

15 of the 17 tools are exploded into five per-tool subfolders, one per
boundary family -- **2 earliest + 1 middle + 2 latest**, the same shape as
the sibling corpora, here spanning two different .NET eras end to end:

| Family | Role | Toolchain | How it's verified |
| --- | --- | --- | --- |
| `netfx45` | earliest | .NET Framework 4.5 (Mono 6.8.0.105 BCL profile 4.5) | **live** -- real Mono compile and run, no NuGet involved |
| `netfx46` | earliest+1 | .NET Framework 4.6 (Mono 6.8.0.105 BCL profile 4.6) | **live** -- real Mono compile and run, no NuGet involved |
| `netcoreapp30` | middle | netcoreapp3.0 (manual csc, SDK 8.0.131's compiler + installed 8.0.31 runtime, rollForward LatestMajor) | **live** -- real, running code via a manual `csc` compile that bypasses NuGet entirely |
| `net9` | latest-1 | net9.0 (manual csc, SDK 10.0.112's compiler + installed 10.0.12 runtime, rollForward LatestMajor) | **live** -- same manual-compile technique, one step from current |
| `net10` | latest | net10.0 (dotnet-sdk-10.0, native) | **live** -- real `dotnet build`/`dotnet run`, current LTS |

No apt/NuGet SDK in this sandbox natively targets four of these five
families. Confirmed directly, not assumed: `apt-cache policy` has no
package at all for `dotnet-sdk-9.0`, and `dotnet build` against
`netcoreapp3.0` or `net9.0` reaches real package restore and fails there
every time (`NU1301`, `api.nuget.org` unreachable) -- the exact same
egress block the root `csharp-repos-build-contract.md` documents for its
own, much larger sibling corpus. Framework 4.5/4.6 have no apt package
either and no SDK-style MSBuild pipeline would work for them here even if
they did (the .NET Framework reference assemblies are themselves
NuGet-only on Linux).

Three genuinely different toolchains make all five families **live**
anyway, none of them touching NuGet:

- **Mono** (netfx45, netfx46): Mono 6.8.0.105 ships a complete, self-contained
  BCL for every .NET Framework profile from 4.5 through 4.8, plus its own
  `mcs` compiler and `mono` runtime -- real compilation, real execution,
  zero NuGet.
- **Manual `csc`** (netcoreapp30, net9): bypassing MSBuild's NuGet-gated
  `FrameworkReference` restore entirely, `csc` is invoked directly against
  the *installed* runtime's own implementation assemblies (not a
  version-matched reference-assembly pack), producing a real, running
  binary once paired with a hand-authored `runtimeconfig.json` that
  declares the family's own TFM and rolls forward
  (`"rollForward": "LatestMajor"`) to whichever runtime major is actually
  installed. Verified end to end before use: a `netcoreapp3.0`-declared,
  `-langversion:8`-compiled binary really runs under the installed 8.0.31
  runtime via `dotnet exec`. This mirrors the Java corpus's own
  `TOOL_JDK`/`HOST_JDK` decoupling -- a modern, available toolchain
  exercising an older or newer declared target without ever touching the
  blocked package registry.
- **Native** (net10): `dotnet-sdk-10.0` (apt-installed for this build)
  targets `net10.0` directly; ordinary `dotnet build`/`dotnet run`.

The domain source for every versionable tool compiles **unmodified** at
every one of the five targets -- the one deliberate exception is
`ArgumentNullException.ThrowIfNull` (a .NET 6+ BCL member, absent from
Mono's Framework-era BCL), replaced corpus-wide with an explicit
null-check-then-throw and `CA1510` added to Roslyn's own `NoWarn` list,
since suppressing a style preference about *how* to null-check is a
different thing from weakening what is actually being verified. Every
other construct the original single-version build used (`new()`
target-typed instantiation, `out var` inline declarations, switch
expressions, throw expressions, `string.Create` with an interpolated
handler, `CryptographicOperations.FixedTimeEquals`) needed either an
explicit, equivalent rewrite (identical across all five families, not a
per-family variant) or, for the one BCL-only member with no portable
equivalent, a small hand-rolled replacement with the same real security
property (a genuine constant-time byte comparison, not a weakened one).
`unilyze`'s own domain source needed no such rewrite -- it reads IL/source
only, not language-version-gated BCL members.

The remaining 2 tools -- **diff-cover, pydriller** -- stay exactly as in
the single-version baseline: both mine git history and a coverage report
(not language/runtime version), so they stay single-version and
unversioned, like their counterparts in every sibling corpus.

**`unilyze` was previously, incorrectly, listed here as a third
"unversioned/no-folder" tool**, on the claim that it "names no real tool."
That was wrong: unilyze is a real, actively maintained .NET/C# code-analysis
CLI (github.com/bigdra50/unilyze, MIT, v0.6.1), confirmed by downloading and
running the actual GitHub release binary. The earlier verdict mistook an
unrelated PyPI package of the same name (a Unicode-inspection tool, dead
since 2020) for the real one -- see `csharp-repos-build-contract.md` for
the full correction. unilyze is now exploded into the same five boundary
families as the other 12 versionable tools, below.

## Measured results (13 versioned tools x 5 families = 65 cells)

| Tool | netfx45 | netfx46 | netcoreapp30 | net9 | net10 |
| --- | --- | --- | --- | --- | --- |
| Coverlet | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED |
| Dolos | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED |
| Lizard | CLEAN | CLEAN | CLEAN | CLEAN | CLEAN |
| MiniCover | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED |
| OpenTelemetry .NET | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED |
| Opengrep (semgrep stand-in) | CLEAN | CLEAN | CLEAN | CLEAN | CLEAN |
| Roslyn | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | CLEAN |
| Semgrep | CLEAN | CLEAN | CLEAN | CLEAN | CLEAN |
| Stryker.NET | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED |
| Trivy | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED |
| altcover | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED | NOT_INSTALLED |
| jscpd | CLEAN | CLEAN | CLEAN | CLEAN | CLEAN |
| unilyze | CLEAN | CLEAN | CLEAN | CLEAN | CLEAN |

**Tally: 26 CLEAN, 0 FINDING, 39 NOT INSTALLED** (out of 65 cells).

Plus the 2 unversioned/no-folder tools, unchanged from the single-version
baseline:

| Tool | Result | Command |
| --- | --- | --- |
| diff-cover | CLEAN | `diff-cover coverage/cobertura-coverage.xml --compare-branch main` |
| pydriller | CLEAN | `python3 -c "from pydriller import Repository; ..."` |

**NOT INSTALLED** (altcover, Coverlet, Dolos, MiniCover, OpenTelemetry .NET,
Stryker.NET, Trivy -- unchanged from the single-version build, across every
family): this sandbox's egress proxy refuses NuGet entirely
(`api.nuget.org`, `www.nuget.org`, `builds.dotnet.microsoft.com`), GitHub
Release downloads, and `nodejs.org`'s header tarball -- confirmed by
direct measurement, not assumed. That blocking is the same regardless of
which toolchain compiles the domain source, so these 7 tools show the
identical result in all 5 families; see each tool's own README for the
exact reason and what was checked. (unilyze's own GitHub Release download
was *not* blocked -- it was fetched and run directly from
`github.com/bigdra50/unilyze/releases`, which this sandbox's egress proxy
does allow; only the 7 tools above are genuinely unreachable here.)

**Roslyn is the one tool whose result genuinely depends on the family**
(see Genuine findings below) -- every other versioned tool's row is flat
(CLEAN x5 or NOT_INSTALLED x5), not because the family never held it back,
but because each of those 11 tools' own blocker (NuGet, npm, GitHub
releases -- or, for the 5 TFM-blind tools now including unilyze, nothing
at all) is entirely independent of target framework.

The exit-code vocabulary throughout this corpus never collapses findings,
skipped, and not-installed into the same result -- a missing binary must
never masquerade as a clean scan, and neither must "this family can't run
it."

## Genuine findings (not papered over)

**Roslyn (`Microsoft.CodeAnalysis.NetAnalyzers`) only actually runs on
net10.** The other four families are NOT_INSTALLED for two *different*,
specific, measured reasons, not one blanket excuse:

- **netfx45, netfx46**: Mono's `mcs`/`mono` path has no MSBuild pipeline at
  all for `dotnet build`'s bundled analyzers to hook into -- a structural
  absence, independent of NuGet.
- **netcoreapp30, net9**: `dotnet build` was genuinely attempted (not
  skipped) and fails at real package restore -- `NU1301`, unable to reach
  `api.nuget.org` -- because neither installed SDK (8.0.131, 10.0.112)
  bundles that family's own `Microsoft.NETCore.App.Ref` targeting pack.

This is the mirror image of the Java corpus's ASM-ceiling finding: there, a
fixed library version capped the *newest* two families; here, a missing
per-family SDK pack holds back the *middle and second-latest* families
while an entirely different, structural reason holds back the earliest
two -- three distinct failure modes for the same single tool, all
confirmed by direct invocation rather than assumed from a version table.

## Rules every folder obeys

- No dependency on any other folder in this corpus -- each is its own C#
  project (or, for diff-cover/pydriller, its own real invocation of an
  external CLI).
- Pure ASCII throughout -- verified corpus-wide, 0 non-ASCII bytes in any
  file.
- 0 code clones corpus-wide (verified with jscpd, `--min-lines 5
  --min-tokens 30 --threshold 0`, C# files): every folder's domain,
  vocabulary, and control-flow shape is deliberately distinct from every
  other folder's.
- Real git history (3 synthetic authors, real commits) for the two tools
  that mine history: diff-cover (plus a real feature-branch diff) and
  pydriller.
- Same domain source, unmodified, across all five families of a given
  tool -- only the compiling toolchain (Mono profile, manual `csc`
  target, or native SDK) differs per family.
- No fabricated tool results. Where a named tool could not be run at all,
  the folder says so and, where a real adjacent tool could stand in
  (Opengrep -> semgrep), that stand-in was actually run in every family
  and its real result reported -- never presented as the named tool's own
  output.

## Layout

```text
<Tool Name>/
  README.md                 what clean means for this tool, the per-family results
  netfx45/ netfx46/         each holds its own src/ copy, compiled at that
  netcoreapp30/ net9/       family's own boundary via its own real toolchain
  net10/
  security-rules.yml        Opengrep's local semgrep ruleset -- shared, family-independent
  rules.yml                 Semgrep's own ruleset -- shared, family-independent
  .git/                     only where the tool mines real history (diff-cover, pydriller) -- unversioned, untouched
_generator/                 family_table.py, generate.py, verify_live.py, write_readmes.py, write_family_readmes.py, write_new_root_readme.py, meta.py, verify.py (original single-version tally)
```

## Reproducing

```bash
python3 _generator/write_readmes.py          # regenerate the 14 auto-written base per-folder READMEs from meta.py
python3 _generator/generate.py                # explode each versionable tool into netfx45/netfx46/netcoreapp30/net9/net10
python3 _generator/verify_live.py             # real compile + real tool run for every live tool, every family
python3 _generator/write_family_readmes.py    # append the per-family results section to each tool's README
python3 _generator/write_new_root_readme.py   # regenerate this file
```

`generate.py` and `verify_live.py` read `family_table.py` for the per-family
toolchain mapping (including the Roslyn `ROSLYN_REASON` documented above)
and need `mono-complete` (apt), `dotnet-sdk-8.0` and `dotnet-sdk-10.0` (apt)
on this host. `Lizard`/`jscpd`/`Opengrep`(semgrep)/`Semgrep`/`unilyze` need
the same pip/npm/PyPI/GitHub-release packages as the original single-version
build.

## Tool versions used for the measurement

```text
dotnet sdk       8.0.131 (apt, dotnet-sdk-8.0)
dotnet sdk       10.0.112 (apt, dotnet-sdk-10.0)
mono             6.8.0.105 (apt, mono-complete -- mcs compiler + Framework 4.5-4.8 BCL profiles)
lizard           1.24.0 (PyPI)
jscpd            5.3.3 (npm)
semgrep          1.178.0 (PyPI, standalone -- also stand-in for Opengrep)
pydriller        2.12 (PyPI)
diff-cover (diff_cover) 10.6.0 (PyPI)
unilyze          0.6.1 (GitHub Release binary, github.com/bigdra50/unilyze, linux-x64)
Microsoft.CodeAnalysis.NetAnalyzers  bundled with dotnet-sdk-10.0 (no NuGet)
```

Verified on Linux, Ubuntu 24.04.

<!-- alignment-2026-10 -->
## Alignment (October 2026)

- **No project files.** Every `.csproj` and `NuGet.Config` was removed. A project file makes the platform treat its folder as a separate project and run the whole tool roster on it. Where a tool's README below mentions a `.csproj`, that is history. Roslyn's analyzer settings are now in `Roslyn/.editorconfig`.
- **Roster complete.** `Roslyn SAST` and `NuGet Audit` were added at all five versions. `Trivy` gained `sbom.cdx.json` per version, because its .NET scanner reads manifests and SBOMs, not source.
- **netfx45 is real C# 5.** The shared domain sources used C# 6 syntax (auto-property initializers, `nameof`, string interpolation, expression-bodied properties, read-only auto-properties); the `netfx45` copies were rewritten with identical behaviour. The other four versions are unchanged.
- **Version markers.** Each versioned tool folder holds `src/LanguageMarker.cs`: a class legal at that version's C# language level and rejected one level below (netfx45 = C# 5, netfx46 = C# 6, netcoreapp30 = C# 8.0, net9 = C# 13.0, net10 = C# 14.0).
- `NuGet Audit` carries `expected-advisories.json` instead of a manifest: `dotnet package list --vulnerable` needs a restored project, so the audit's real input stays the branch's own root project.

<!-- distinct-copies -->
- **Version copies differ.** In every versioned tool folder the `netfx45`, `netfx46`, `netcoreapp30` and `net9` copies carry a version suffix on their identifiers (`V45`, `V46`, `V30`, `V9`); `net10` keeps the original names. Behaviour is identical. Without this, a duplicate-code scan over a whole tool folder sees the same file five times and reports clones in a corpus that must report none.
