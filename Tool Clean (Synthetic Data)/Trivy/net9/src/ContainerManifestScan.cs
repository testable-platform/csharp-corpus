using System;
using System.Collections.Generic;

namespace ShippingOps
{
    public class PackageReferenceV9
    {
        public string PackageNameV9 { get; set; } = string.Empty;
        public string VersionV9 { get; set; } = string.Empty;
    }

    public class ContainerManifestScanV9
    {
        private readonly List<PackageReferenceV9> _packagesV9 = new List<PackageReferenceV9>();

        public void Add(PackageReferenceV9 packageV9)
        {
            _packagesV9.Add(packageV9);
        }

        public int Count() => _packagesV9.Count;
    }
}
