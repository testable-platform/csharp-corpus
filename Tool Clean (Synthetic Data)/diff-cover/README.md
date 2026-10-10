# diff-cover

Synthetic, clean-by-design C# project for **diff-cover**.

Package: diff_cover 10.6.0 (PyPI)

Domain: harbor pilot rotation assignment (PilotRotation)

**Measured**: installed (or built from real source) and actually invoked in the build environment; the result below is real, not asserted.

## What a passing result looks like

`diff-cover` reports 100% coverage on every line the `feature` branch adds over `main`, read from a real Cobertura report over real git history.

## Command

```bash
diff-cover coverage/cobertura-coverage.xml --compare-branch main
```

## Notes

Coverlet, AltCover and MiniCover -- every normal source of a .NET Cobertura report -- are NuGet-only and blocked here (see their own folders), so this folder produces the coverage report itself: `src/Cov.cs` is a small hand-rolled probe that records the real call-site line (via `[CallerLineNumber]`, resolved by the compiler, not computed by hand) every time a line actually executes, and `tools/driver.cs` walks every branch of the `feature` commit's new `NextPilotFor` method -- the found case and the not-found case -- before writing a genuine Cobertura XML from the resulting hit set. diff-cover itself is the real, unmodified PyPI tool, reading a real coverage report; only the report's producer is this corpus's own driver instead of Coverlet, exactly as this corpus's own diff-cover folders in the sibling Python/JavaScript/Java/TypeScript corpora read whatever coverage reporter each ecosystem's own test runner produces.
