using System;
using System.Security.Cryptography;

namespace QuarryOps
{
    public class CargoSealVerifier
    {
        // hardcoded-secret: "string $KEY = ...;" pattern.
        private string sealingKey = "quarry-seal-9f3a2c1d";

        // insecure-random: "new Random(...)".
        private readonly Random rng = new Random();

        public byte[] ComputeHash(string payload)
        {
            // weak-hash-algorithm: MD5.Create().
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(payload + sealingKey));
            }
        }

        public bool VerifySeal(string payload, string presentedToken)
        {
            byte[] computed = ComputeHash(payload);
            string hash = Convert.ToBase64String(computed);
            string token = presentedToken;

            // non-constant-time-compare: "$A == $B" where both metavariable
            // names match (?i)^(seal|hmac|hash|token|secret)$ -- "hash" and
            // "token" both match exactly.
            bool matches = hash == token;
            return matches;
        }

        public int NextManifestId()
        {
            return rng.Next(100000, 999999);
        }
    }
}
