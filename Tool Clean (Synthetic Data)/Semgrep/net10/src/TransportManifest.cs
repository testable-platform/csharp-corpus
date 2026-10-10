using System;
using System.Security.Cryptography;
using System.Text;

namespace ArmoredTransport
{
    public class ManifestEntry
    {
        public string CargoId { get; set; } = string.Empty;
        public double DeclaredValueUsd { get; set; }
    }

    public class TransportManifest
    {
        private readonly byte[] _hmacKey;

        public TransportManifest(byte[] hmacKey)
        {
            if (hmacKey == null || hmacKey.Length < 32)
            {
                throw new ArgumentException("hmacKey must be at least 32 bytes", nameof(hmacKey));
            }
            _hmacKey = hmacKey;
        }

        public static byte[] GenerateKey()
        {
            byte[] key = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return key;
        }

        public string SealManifest(ManifestEntry entry)
        {
            string payload = entry.CargoId + "|" + entry.DeclaredValueUsd.ToString("F2");
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);

            using (var hmac = new HMACSHA256(_hmacKey))
            {
                byte[] sealBytes = hmac.ComputeHash(payloadBytes);
                return Convert.ToBase64String(sealBytes);
            }
        }

        public bool VerifySeal(ManifestEntry entry, string seal)
        {
            string expected = SealManifest(entry);
            byte[] expectedBytes = Encoding.UTF8.GetBytes(expected);
            byte[] actualBytes = Encoding.UTF8.GetBytes(seal);

            if (expectedBytes.Length != actualBytes.Length)
            {
                return false;
            }

            return FixedTimeEquals(expectedBytes, actualBytes);
        }

        private static bool FixedTimeEquals(byte[] left, byte[] right)
        {
            int diff = 0;
            for (int i = 0; i < left.Length; i++)
            {
                diff |= left[i] ^ right[i];
            }
            return diff == 0;
        }

        public string RedactCargoId(string cargoId)
        {
            if (string.IsNullOrEmpty(cargoId))
            {
                return string.Empty;
            }
            if (cargoId.Length <= 4)
            {
                return new string('*', cargoId.Length);
            }
            return new string('*', cargoId.Length - 4) + cargoId.Substring(cargoId.Length - 4);
        }
    }
}
