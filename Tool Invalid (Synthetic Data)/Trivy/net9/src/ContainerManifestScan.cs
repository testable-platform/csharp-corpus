using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class ManifestEntry
    {
        public string PackageName { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
    }

    public class ContainerManifestScan
    {
        private readonly List<ManifestEntry> _entries = new List<ManifestEntry>();

        public void AddEntry(ManifestEntry entry)
        {
            _entries.Add(entry);
        }

        public int Count()
        {
            return _entries.Count;
        }

        public bool Contains(string packageName)
        {
            foreach (var entry in _entries)
            {
                if (entry.PackageName == packageName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
