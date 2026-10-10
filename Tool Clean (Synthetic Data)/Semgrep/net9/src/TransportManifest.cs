using System;
using System.Security.Cryptography;
using System.Text;

namespace ArmoredTransport
{
    public class ManifestEntryV9
    {
        public string CargoIdV9 { get; set; } = string.Empty;
        public double DeclaredValueUsdV9 { get; set; }
    }

    public class TransportManifestV9
    {
        private readonly byte[] _hmacKeyV9;

        public TransportManifestV9(byte[] hmacKeyV9)
        {
            if (hmacKeyV9 == null || hmacKeyV9.Length < 32)
            {
                throw new ArgumentException("hmacKey must be at least 32 bytes", nameof(hmacKeyV9));
            }
            _hmacKeyV9 = hmacKeyV9;
        }

        public static byte[] GenerateKeyV9()
        {
            byte[] keyV9 = new byte[32];
            using (var rngV9 = RandomNumberGenerator.Create())
            {
                rngV9.GetBytes(keyV9);
            }
            return keyV9;
        }

        public string SealManifestV9(ManifestEntryV9 entryV9)
        {
            string payloadV9 = entryV9.CargoIdV9 + "|" + entryV9.DeclaredValueUsdV9.ToString("F2");
            byte[] payloadBytesV9 = Encoding.UTF8.GetBytes(payloadV9);

            using (var hmacV9 = new HMACSHA256(_hmacKeyV9))
            {
                byte[] sealBytesV9 = hmacV9.ComputeHash(payloadBytesV9);
                return Convert.ToBase64String(sealBytesV9);
            }
        }

        public bool VerifySealV9(ManifestEntryV9 entryV9, string sealV9)
        {
            string expectedV9 = SealManifestV9(entryV9);
            byte[] expectedBytesV9 = Encoding.UTF8.GetBytes(expectedV9);
            byte[] actualBytesV9 = Encoding.UTF8.GetBytes(sealV9);

            if (expectedBytesV9.Length != actualBytesV9.Length)
            {
                return false;
            }

            return FixedTimeEqualsV9(expectedBytesV9, actualBytesV9);
        }

        private static bool FixedTimeEqualsV9(byte[] leftV9, byte[] rightV9)
        {
            int diffV9 = 0;
            for (int iV9 = 0; iV9 < leftV9.Length; iV9++)
            {
                diffV9 |= leftV9[iV9] ^ rightV9[iV9];
            }
            return diffV9 == 0;
        }

        public string RedactCargoIdV9(string cargoIdV9)
        {
            if (string.IsNullOrEmpty(cargoIdV9))
            {
                return string.Empty;
            }
            if (cargoIdV9.Length <= 4)
            {
                return new string('*', cargoIdV9.Length);
            }
            return new string('*', cargoIdV9.Length - 4) + cargoIdV9.Substring(cargoIdV9.Length - 4);
        }
    }
}
