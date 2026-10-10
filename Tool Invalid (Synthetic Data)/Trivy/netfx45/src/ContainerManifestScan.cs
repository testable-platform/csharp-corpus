using System;
using System.Collections.Generic;

namespace QuarryOps
{
    public class ManifestEntry
    {
        private string _packageNameField = string.Empty;
        public string PackageName { get { return _packageNameField; } set { _packageNameField = value; } }
        private string _versionField = string.Empty;
        public string Version { get { return _versionField; } set { _versionField = value; } }
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
