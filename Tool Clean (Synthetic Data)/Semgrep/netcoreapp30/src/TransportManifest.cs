using System;
using System.Security.Cryptography;
using System.Text;

namespace ArmoredTransport
{
    public class ManifestEntryV30
    {
        public string CargoIdV30 { get; set; } = string.Empty;
        public double DeclaredValueUsdV30 { get; set; }
    }

    public class TransportManifestV30
    {
        private readonly byte[] _hmacKeyV30;

        public TransportManifestV30(byte[] hmacKeyV30)
        {
            if (hmacKeyV30 == null || hmacKeyV30.Length < 32)
            {
                throw new ArgumentException("hmacKey must be at least 32 bytes", nameof(hmacKeyV30));
            }
            _hmacKeyV30 = hmacKeyV30;
        }

        public static byte[] GenerateKeyV30()
        {
            byte[] keyV30 = new byte[32];
            using (var rngV30 = RandomNumberGenerator.Create())
            {
                rngV30.GetBytes(keyV30);
            }
            return keyV30;
        }

        public string SealManifestV30(ManifestEntryV30 entryV30)
        {
            string payloadV30 = entryV30.CargoIdV30 + "|" + entryV30.DeclaredValueUsdV30.ToString("F2");
            byte[] payloadBytesV30 = Encoding.UTF8.GetBytes(payloadV30);

            using (var hmacV30 = new HMACSHA256(_hmacKeyV30))
            {
                byte[] sealBytesV30 = hmacV30.ComputeHash(payloadBytesV30);
                return Convert.ToBase64String(sealBytesV30);
            }
        }

        public bool VerifySealV30(ManifestEntryV30 entryV30, string sealV30)
        {
            string expectedV30 = SealManifestV30(entryV30);
            byte[] expectedBytesV30 = Encoding.UTF8.GetBytes(expectedV30);
            byte[] actualBytesV30 = Encoding.UTF8.GetBytes(sealV30);

            if (expectedBytesV30.Length != actualBytesV30.Length)
            {
                return false;
            }

            return FixedTimeEqualsV30(expectedBytesV30, actualBytesV30);
        }

        private static bool FixedTimeEqualsV30(byte[] leftV30, byte[] rightV30)
        {
            int diffV30 = 0;
            for (int iV30 = 0; iV30 < leftV30.Length; iV30++)
            {
                diffV30 |= leftV30[iV30] ^ rightV30[iV30];
            }
            return diffV30 == 0;
        }

        public string RedactCargoIdV30(string cargoIdV30)
        {
            if (string.IsNullOrEmpty(cargoIdV30))
            {
                return string.Empty;
            }
            if (cargoIdV30.Length <= 4)
            {
                return new string('*', cargoIdV30.Length);
            }
            return new string('*', cargoIdV30.Length - 4) + cargoIdV30.Substring(cargoIdV30.Length - 4);
        }
    }
}
