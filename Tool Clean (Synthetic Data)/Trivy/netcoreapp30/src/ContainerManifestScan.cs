using System;
using System.Collections.Generic;

namespace ShippingOps
{
    public class PackageReferenceV30
    {
        public string PackageNameV30 { get; set; } = string.Empty;
        public string VersionV30 { get; set; } = string.Empty;
    }

    public class ContainerManifestScanV30
    {
        private readonly List<PackageReferenceV30> _packagesV30 = new List<PackageReferenceV30>();

        public void Add(PackageReferenceV30 packageV30)
        {
            _packagesV30.Add(packageV30);
        }

        public int Count() => _packagesV30.Count;
    }
}
