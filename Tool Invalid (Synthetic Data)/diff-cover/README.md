# diff-cover

Inverse-corpus counterpart to the sibling CSharp-Tools-Clean's **diff-cover**
folder: a real git repository (`main` + `feature` branches) engineered so
the real `diff-cover` tool reports genuinely, majority wrong diff coverage.

Package: diff_cover 10.6.0 (PyPI)

Domain: quarry stockpile reclamation ledger (StockpileReclaim)

**Measured**: installed and actually invoked against a real Cobertura
report generated from a real test run; the result below is real, not
asserted.

## What "wrong" means here

`feature` adds a 6-way tonnage classifier, `ClassifyStockpile`, to the
`main`-branch ledger. The real driver (`tools/driver.cs`) only ever calls
it with two inputs -- 50 (`"small"`) and -5 (`"invalid"`) -- leaving the
other four branches (`"empty"`, `"medium"`, `"large"`, `"bulk"`) genuinely
unexecuted. The Cobertura report is generated from real, hand-rolled
line-coverage instrumentation (`src/Cov.cs`, via `[CallerLineNumber]` --
Coverlet/AltCover/MiniCover all need a NuGet restore this sandbox's egress
proxy refuses), not asserted numbers.

**2 of 6 new lines covered = 33%, well under the 50% target.**

## Command

```bash
dotnet run                                          # generates coverage/cobertura-coverage.xml for real
diff-cover coverage/cobertura-coverage.xml --compare-branch main
```

Real measured output:

```text
Diff Coverage
Diff: main...HEAD, staged and unstaged changes
-------------
src/StockpileReclaim.cs (33.3%): Missing lines 41,51,56,61
-------------
Total:   6 lines
Missing: 4 lines
Coverage: 33%
```

## Notes

Coverlet, AltCover and MiniCover -- every normal source of a .NET Cobertura
report -- are NuGet-only and blocked here (see their own folders), so this
folder produces the coverage report itself, exactly as the sibling Clean
corpus's own diff-cover folder does: `diff-cover` itself is the real,
unmodified PyPI tool, reading a real coverage report; only the report's
producer is this corpus's own driver instead of Coverlet.

Single-version, unversioned -- diff-cover mines a coverage report and git
history, not language/runtime version, so it is not exploded into the five
boundary families, matching its counterpart in every sibling corpus.
