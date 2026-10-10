using System;
using System.Security.Cryptography;
using System.Text;

namespace ArmoredTransport
{
    public class ManifestEntryV45
    {
        private string _cargoIdFieldV45 = string.Empty;
        public string CargoIdV45 { get { return _cargoIdFieldV45; } set { _cargoIdFieldV45 = value; } }
        public double DeclaredValueUsdV45 { get; set; }
    }

    public class TransportManifestV45
    {
        private readonly byte[] _hmacKeyV45;

        public TransportManifestV45(byte[] hmacKeyV45)
        {
            if (hmacKeyV45 == null || hmacKeyV45.Length < 32)
            {
                throw new ArgumentException("hmacKey must be at least 32 bytes", "hmacKey");
            }
            _hmacKeyV45 = hmacKeyV45;
        }

        public static byte[] GenerateKeyV45()
        {
            byte[] keyV45 = new byte[32];
            using (var rngV45 = RandomNumberGenerator.Create())
            {
                rngV45.GetBytes(keyV45);
            }
            return keyV45;
        }

        public string SealManifestV45(ManifestEntryV45 entryV45)
        {
            string payloadV45 = entryV45.CargoIdV45 + "|" + entryV45.DeclaredValueUsdV45.ToString("F2");
            byte[] payloadBytesV45 = Encoding.UTF8.GetBytes(payloadV45);

            using (var hmacV45 = new HMACSHA256(_hmacKeyV45))
            {
                byte[] sealBytesV45 = hmacV45.ComputeHash(payloadBytesV45);
                return Convert.ToBase64String(sealBytesV45);
            }
        }

        public bool VerifySealV45(ManifestEntryV45 entryV45, string sealV45)
        {
            string expectedV45 = SealManifestV45(entryV45);
            byte[] expectedBytesV45 = Encoding.UTF8.GetBytes(expectedV45);
            byte[] actualBytesV45 = Encoding.UTF8.GetBytes(sealV45);

            if (expectedBytesV45.Length != actualBytesV45.Length)
            {
                return false;
            }

            return FixedTimeEqualsV45(expectedBytesV45, actualBytesV45);
        }

        private static bool FixedTimeEqualsV45(byte[] leftV45, byte[] rightV45)
        {
            int diffV45 = 0;
            for (int iV45 = 0; iV45 < leftV45.Length; iV45++)
            {
                diffV45 |= leftV45[iV45] ^ rightV45[iV45];
            }
            return diffV45 == 0;
        }

        public string RedactCargoIdV45(string cargoIdV45)
        {
            if (string.IsNullOrEmpty(cargoIdV45))
            {
                return string.Empty;
            }
            if (cargoIdV45.Length <= 4)
            {
                return new string('*', cargoIdV45.Length);
            }
            return new string('*', cargoIdV45.Length - 4) + cargoIdV45.Substring(cargoIdV45.Length - 4);
        }
    }
}
