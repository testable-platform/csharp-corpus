using System;
using System.Collections.Generic;

namespace ShippingOps
{
    public class PackageReferenceV45
    {
        private string _packageNameFieldV45 = string.Empty;
        public string PackageNameV45 { get { return _packageNameFieldV45; } set { _packageNameFieldV45 = value; } }
        private string _versionFieldV45 = string.Empty;
        public string VersionV45 { get { return _versionFieldV45; } set { _versionFieldV45 = value; } }
    }

    public class ContainerManifestScanV45
    {
        private readonly List<PackageReferenceV45> _packagesV45 = new List<PackageReferenceV45>();

        public void Add(PackageReferenceV45 packageV45)
        {
            _packagesV45.Add(packageV45);
        }

        public int Count() { return _packagesV45.Count; }
    }
}
