// Tool Clean (Synthetic Data) -- Roslyn SAST analyzers
//
// CLEAN BY DESIGN: the same five operations as the Invalid fixture, written safely.
// EXPECTED: zero diagnostics in the CA2100 / SCS0001 / CA3003 / CA5351 / CA5394 families.
//
// Family net10.0, C# 14.0. The core is C# 5-compatible; src/LanguageMarker.cs pins the folder to C# 14.0.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ToolData.RoslynSastClean
{
    public sealed class QuerySpec
    {
        public string Text;
        public IDictionary<string, object> Parameters;
    }

    public static class SafeOperations
    {
        private static readonly string[] AllowedReports = new string[] { "daily", "weekly", "monthly" };

        /// <summary>Parameterised: the SQL text is a constant, the value travels separately.</summary>
        public static QuerySpec BuildOrderQuery(string sku)
        {
            QuerySpec spec = new QuerySpec();
            spec.Text = "SELECT * FROM orders WHERE sku = @sku";
            spec.Parameters = new Dictionary<string, object>();
            spec.Parameters["@sku"] = sku;
            return spec;
        }

        /// <summary>The report name is checked against an allow-list; nothing is spliced into a command line.</summary>
        public static ProcessStartInfo PrepareReport(string reportName)
        {
            if (Array.IndexOf(AllowedReports, reportName) < 0)
            {
                throw new ArgumentException("unknown report", "reportName");
            }
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "report";
            info.UseShellExecute = false;
            info.Arguments = reportName;
            return info;
        }

        /// <summary>Resolves the path and refuses anything that escapes the root.</summary>
        public static string ReadTemplate(string root, string templateName)
        {
            string fullRoot = Path.GetFullPath(root);
            string path = Path.GetFullPath(Path.Combine(fullRoot, templateName));
            if (!path.StartsWith(fullRoot + Path.DirectorySeparatorChar, StringComparison.Ordinal))
            {
                throw new ArgumentException("template escapes root", "templateName");
            }
            return File.Exists(path) ? File.ReadAllText(path) : string.Empty;
        }

        /// <summary>SHA-256, not MD5.</summary>
        public static string Fingerprint(string payload)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] hash = sha.ComputeHash(Encoding.UTF8.GetBytes(payload));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++) sb.Append(hash[i].ToString("x2"));
                return sb.ToString();
            }
        }

        /// <summary>A cryptographically strong token, not System.Random.</summary>
        public static string NewToken()
        {
            byte[] bytes = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return Convert.ToBase64String(bytes);
        }
    }
}
