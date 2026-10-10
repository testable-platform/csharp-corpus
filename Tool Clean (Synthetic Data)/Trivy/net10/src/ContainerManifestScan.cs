using System;
using System.Collections.Generic;

namespace ShippingOps
{
    public class PackageReference
    {
        public string PackageName { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
    }

    public class ContainerManifestScan
    {
        private readonly List<PackageReference> _packages = new List<PackageReference>();

        public void Add(PackageReference package)
        {
            _packages.Add(package);
        }

        public int Count() => _packages.Count;
    }
}
