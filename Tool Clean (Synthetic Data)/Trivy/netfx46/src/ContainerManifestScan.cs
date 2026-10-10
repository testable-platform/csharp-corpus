using System;
using System.Collections.Generic;

namespace ShippingOps
{
    public class PackageReferenceV46
    {
        public string PackageNameV46 { get; set; } = string.Empty;
        public string VersionV46 { get; set; } = string.Empty;
    }

    public class ContainerManifestScanV46
    {
        private readonly List<PackageReferenceV46> _packagesV46 = new List<PackageReferenceV46>();

        public void Add(PackageReferenceV46 packageV46)
        {
            _packagesV46.Add(packageV46);
        }

        public int Count() => _packagesV46.Count;
    }
}
