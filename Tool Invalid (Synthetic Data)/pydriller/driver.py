#!/usr/bin/env python3
"""Real pydriller measurement for the Invalid corpus's pydriller folder.

Walks the real git history of this repo (via pydriller.Repository, the
genuine PyPI package, not a mock) and checks each commit that declares an
"[area:X]" tag in its message against the files that commit *actually*
touched. "ledger" area commits should touch src/, "docs" area commits
should touch docs/; anything else is a genuine, measured mismatch between
what the commit message claims and what the commit really did.
"""
import re
import sys
from pydriller import Repository

AREA_PATTERN = re.compile(r"\[area:(\w+)\]")

AREA_DIR = {
    "ledger": "src/",
    "docs": "docs/",
    # "meta" has no corroborating directory by design -- any commit tagged
    # meta is automatically a mismatch, exactly like the sibling corpora's
    # dulwich/pydriller folders treat an uncorroborated tag.
}


def main():
    total = 0
    mismatches = []
    for commit in Repository(".").traverse_commits():
        m = AREA_PATTERN.search(commit.msg)
        if not m:
            continue
        area = m.group(1)
        touched = [f.new_path or f.old_path for f in commit.modified_files]
        total += 1
        expected_dir = AREA_DIR.get(area)
        corroborated = expected_dir is not None and any(
            t and t.startswith(expected_dir) for t in touched
        )
        status = "MATCH" if corroborated else "MISMATCH"
        if status == "MISMATCH":
            mismatches.append((commit.hash[:7], commit.msg.strip(), touched))
        print(f"{commit.hash[:7]}  area={area:8s} touched={touched}  -> {status}")

    print()
    print(f"Total tagged commits: {total}")
    print(f"Mismatches: {len(mismatches)} ({len(mismatches) / total * 100:.1f}%)")
    for h, msg, touched in mismatches:
        print(f"  {h}  {msg}  touched={touched}")

    if len(mismatches) / total < 0.5:
        print("\nFAIL: mismatch rate is not a majority -- fixture does not meet the Invalid bar")
        return 1
    print("\nOK: majority of tagged commits genuinely mismatch their claimed area.")
    return 0


if __name__ == "__main__":
    sys.exit(main())
