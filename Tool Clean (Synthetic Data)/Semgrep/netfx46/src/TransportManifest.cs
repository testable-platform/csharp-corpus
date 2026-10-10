using System;
using System.Security.Cryptography;
using System.Text;

namespace ArmoredTransport
{
    public class ManifestEntryV46
    {
        public string CargoIdV46 { get; set; } = string.Empty;
        public double DeclaredValueUsdV46 { get; set; }
    }

    public class TransportManifestV46
    {
        private readonly byte[] _hmacKeyV46;

        public TransportManifestV46(byte[] hmacKeyV46)
        {
            if (hmacKeyV46 == null || hmacKeyV46.Length < 32)
            {
                throw new ArgumentException("hmacKey must be at least 32 bytes", nameof(hmacKeyV46));
            }
            _hmacKeyV46 = hmacKeyV46;
        }

        public static byte[] GenerateKeyV46()
        {
            byte[] keyV46 = new byte[32];
            using (var rngV46 = RandomNumberGenerator.Create())
            {
                rngV46.GetBytes(keyV46);
            }
            return keyV46;
        }

        public string SealManifestV46(ManifestEntryV46 entryV46)
        {
            string payloadV46 = entryV46.CargoIdV46 + "|" + entryV46.DeclaredValueUsdV46.ToString("F2");
            byte[] payloadBytesV46 = Encoding.UTF8.GetBytes(payloadV46);

            using (var hmacV46 = new HMACSHA256(_hmacKeyV46))
            {
                byte[] sealBytesV46 = hmacV46.ComputeHash(payloadBytesV46);
                return Convert.ToBase64String(sealBytesV46);
            }
        }

        public bool VerifySealV46(ManifestEntryV46 entryV46, string sealV46)
        {
            string expectedV46 = SealManifestV46(entryV46);
            byte[] expectedBytesV46 = Encoding.UTF8.GetBytes(expectedV46);
            byte[] actualBytesV46 = Encoding.UTF8.GetBytes(sealV46);

            if (expectedBytesV46.Length != actualBytesV46.Length)
            {
                return false;
            }

            return FixedTimeEqualsV46(expectedBytesV46, actualBytesV46);
        }

        private static bool FixedTimeEqualsV46(byte[] leftV46, byte[] rightV46)
        {
            int diffV46 = 0;
            for (int iV46 = 0; iV46 < leftV46.Length; iV46++)
            {
                diffV46 |= leftV46[iV46] ^ rightV46[iV46];
            }
            return diffV46 == 0;
        }

        public string RedactCargoIdV46(string cargoIdV46)
        {
            if (string.IsNullOrEmpty(cargoIdV46))
            {
                return string.Empty;
            }
            if (cargoIdV46.Length <= 4)
            {
                return new string('*', cargoIdV46.Length);
            }
            return new string('*', cargoIdV46.Length - 4) + cargoIdV46.Substring(cargoIdV46.Length - 4);
        }
    }
}
