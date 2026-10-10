using System;
using System.Security.Cryptography;

namespace QuarryOps
{
    public class CheckpointClearanceControl
    {
        // hardcoded-secret: "string $KEY = ...;" pattern.
        private string clearanceSecret = "checkpoint-9f3a-clearance";

        // insecure-random: "new Random(...)".
        private readonly Random rng = new Random();

        public byte[] ComputeDigest(string badge)
        {
            // weak-hash-algorithm: SHA1.Create().
            using (var sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(badge + clearanceSecret));
            }
        }

        public bool ClearBadge(string badge, string presentedSecret)
        {
            byte[] computed = ComputeDigest(badge);
            string secret = Convert.ToBase64String(computed);
            string token = presentedSecret;

            // non-constant-time-compare: "$A.Equals($B)" where both
            // metavariable names match (?i)^(seal|hmac|hash|token|secret)$ --
            // "secret" and "token" both match exactly.
            bool cleared = secret.Equals(token);
            return cleared;
        }

        public int NextClearanceCode()
        {
            return rng.Next(10000, 99999);
        }
    }
}
