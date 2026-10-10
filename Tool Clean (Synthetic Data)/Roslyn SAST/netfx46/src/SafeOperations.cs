// Tool Clean (Synthetic Data) -- Roslyn SAST analyzers
//
// CLEAN BY DESIGN: the same five operations as the Invalid fixture, written safely.
// EXPECTED: zero diagnostics in the CA2100 / SCS0001 / CA3003 / CA5351 / CA5394 families.
//
// Family net46, C# 6. The core is C# 5-compatible; src/LanguageMarker.cs pins the folder to C# 6.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ToolData.RoslynSastClean
{
    public sealed class QuerySpecV46
    {
        public string TextV46;
        public IDictionary<string, object> ParametersV46;
    }

    public static class SafeOperationsV46
    {
        private static readonly string[] AllowedReportsV46 = new string[] { "daily", "weekly", "monthly" };

        /// <summary>Parameterised: the SQL text is a constant, the value travels separately.</summary>
        public static QuerySpecV46 BuildOrderQueryV46(string skuV46)
        {
            QuerySpecV46 specV46 = new QuerySpecV46();
            specV46.TextV46 = "SELECT * FROM orders WHERE sku = @sku";
            specV46.ParametersV46 = new Dictionary<string, object>();
            specV46.ParametersV46["@sku"] = skuV46;
            return specV46;
        }

        /// <summary>The report name is checked against an allow-list; nothing is spliced into a command line.</summary>
        public static ProcessStartInfo PrepareReportV46(string reportNameV46)
        {
            if (Array.IndexOf(AllowedReportsV46, reportNameV46) < 0)
            {
                throw new ArgumentException("unknown report", "reportName");
            }
            ProcessStartInfo infoV46 = new ProcessStartInfo();
            infoV46.FileName = "report";
            infoV46.UseShellExecute = false;
            infoV46.Arguments = reportNameV46;
            return infoV46;
        }

        /// <summary>Resolves the path and refuses anything that escapes the root.</summary>
        public static string ReadTemplateV46(string rootV46, string templateNameV46)
        {
            string fullRootV46 = Path.GetFullPath(rootV46);
            string pathV46 = Path.GetFullPath(Path.Combine(fullRootV46, templateNameV46));
            if (!pathV46.StartsWith(fullRootV46 + Path.DirectorySeparatorChar, StringComparison.Ordinal))
            {
                throw new ArgumentException("template escapes root", "templateName");
            }
            return File.Exists(pathV46) ? File.ReadAllText(pathV46) : string.Empty;
        }

        /// <summary>SHA-256, not MD5.</summary>
        public static string FingerprintV46(string payloadV46)
        {
            using (SHA256 shaV46 = SHA256.Create())
            {
                byte[] hashV46 = shaV46.ComputeHash(Encoding.UTF8.GetBytes(payloadV46));
                StringBuilder sbV46 = new StringBuilder();
                for (int iV46 = 0; iV46 < hashV46.Length; iV46++) sbV46.Append(hashV46[iV46].ToString("x2"));
                return sbV46.ToString();
            }
        }

        /// <summary>A cryptographically strong token, not System.Random.</summary>
        public static string NewTokenV46()
        {
            byte[] bytesV46 = new byte[16];
            using (RandomNumberGenerator rngV46 = RandomNumberGenerator.Create())
            {
                rngV46.GetBytes(bytesV46);
            }
            return Convert.ToBase64String(bytesV46);
        }
    }
}
