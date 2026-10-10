# pydriller

Inverse-corpus counterpart to the sibling CSharp-Tools-Clean's **pydriller**
folder: a real git repository with 8 tagged commits engineered so the real
`pydriller` tool, mining real history, finds a genuine majority-wrong
result.

Package: PyDriller 2.12 (PyPI)

Domain: quarry manifest ledger history (QuarryManifestHistory)

**Measured**: installed and actually invoked against this folder's own
real git history; the result below is real, not asserted.

## What "wrong" means here

Every commit that touches the ledger or its docs carries an `[area:X]` tag
in its message (`ledger`, `docs`, or `meta`). `driver.py` walks the real
history with `pydriller.Repository` and checks each tagged commit's
*actual* modified files against what its own tag claims:

| Commit | Tag claims | Actually touched | Verdict |
|---|---|---|---|
| `feat: add manifest ledger core` | ledger | `src/QuarryManifestHistory.cs` | MATCH |
| `docs: write usage notes` | docs | `docs/NOTES.md` | MATCH |
| `feat: add lookup by manifest id` | ledger | `src/QuarryManifestHistory.cs` | MATCH |
| `chore: reformat ledger spacing` | ledger | `docs/NOTES.md` | **MISMATCH** |
| `feat: add totals helper` | ledger | `docs/NOTES.md` | **MISMATCH** |
| `docs: add totals example` | docs | `src/QuarryManifestHistory.cs` | **MISMATCH** |
| `chore: bump schema version metadata` | meta | `src/QuarryManifestHistory.cs` | **MISMATCH** |
| `feat: add filter helper` | ledger | `docs/NOTES.md` | **MISMATCH** |

**5 of 8 tagged commits mismatch their claimed area = 62.5%.**

## Command

```bash
python3 driver.py
```

Real measured output:

```text
Total tagged commits: 8
Mismatches: 5 (62.5%)
  6cd1150  chore: reformat ledger spacing [area:ledger]  touched=['docs/NOTES.md']
  893262c  feat: add totals helper [area:ledger]  touched=['docs/NOTES.md']
  2a70607  docs: add totals example [area:docs]  touched=['src/QuarryManifestHistory.cs']
  e85abdc  chore: bump schema version metadata [area:meta]  touched=['src/QuarryManifestHistory.cs']
  4d4fa10  feat: add filter helper [area:ledger]  touched=['docs/NOTES.md']
```

## Notes

Real, unmodified PyDriller mining a real git repository -- the same
package used for this purpose in every sibling corpus (Python, JavaScript,
Java, TypeScript). The "`area` tag doesn't match touched files" metric is
the same shape used for the sibling corpora's own pydriller (and
dulwich-equivalent) Invalid folders, kept consistent across the whole
Testable project.

Single-version, unversioned -- pydriller mines git history, not
language/runtime version, so it is not exploded into the five boundary
families, matching its counterpart in every sibling corpus.
