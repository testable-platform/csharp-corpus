// Tool Clean (Synthetic Data) -- Roslyn SAST analyzers
//
// CLEAN BY DESIGN: the same five operations as the Invalid fixture, written safely.
// EXPECTED: zero diagnostics in the CA2100 / SCS0001 / CA3003 / CA5351 / CA5394 families.
//
// Family netcoreapp3.0, C# 8.0. The core is C# 5-compatible; src/LanguageMarker.cs pins the folder to C# 8.0.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ToolData.RoslynSastClean
{
    public sealed class QuerySpecV30
    {
        public string TextV30;
        public IDictionary<string, object> ParametersV30;
    }

    public static class SafeOperationsV30
    {
        private static readonly string[] AllowedReportsV30 = new string[] { "daily", "weekly", "monthly" };

        /// <summary>Parameterised: the SQL text is a constant, the value travels separately.</summary>
        public static QuerySpecV30 BuildOrderQueryV30(string skuV30)
        {
            QuerySpecV30 specV30 = new QuerySpecV30();
            specV30.TextV30 = "SELECT * FROM orders WHERE sku = @sku";
            specV30.ParametersV30 = new Dictionary<string, object>();
            specV30.ParametersV30["@sku"] = skuV30;
            return specV30;
        }

        /// <summary>The report name is checked against an allow-list; nothing is spliced into a command line.</summary>
        public static ProcessStartInfo PrepareReportV30(string reportNameV30)
        {
            if (Array.IndexOf(AllowedReportsV30, reportNameV30) < 0)
            {
                throw new ArgumentException("unknown report", "reportName");
            }
            ProcessStartInfo infoV30 = new ProcessStartInfo();
            infoV30.FileName = "report";
            infoV30.UseShellExecute = false;
            infoV30.Arguments = reportNameV30;
            return infoV30;
        }

        /// <summary>Resolves the path and refuses anything that escapes the root.</summary>
        public static string ReadTemplateV30(string rootV30, string templateNameV30)
        {
            string fullRootV30 = Path.GetFullPath(rootV30);
            string pathV30 = Path.GetFullPath(Path.Combine(fullRootV30, templateNameV30));
            if (!pathV30.StartsWith(fullRootV30 + Path.DirectorySeparatorChar, StringComparison.Ordinal))
            {
                throw new ArgumentException("template escapes root", "templateName");
            }
            return File.Exists(pathV30) ? File.ReadAllText(pathV30) : string.Empty;
        }

        /// <summary>SHA-256, not MD5.</summary>
        public static string FingerprintV30(string payloadV30)
        {
            using (SHA256 shaV30 = SHA256.Create())
            {
                byte[] hashV30 = shaV30.ComputeHash(Encoding.UTF8.GetBytes(payloadV30));
                StringBuilder sbV30 = new StringBuilder();
                for (int iV30 = 0; iV30 < hashV30.Length; iV30++) sbV30.Append(hashV30[iV30].ToString("x2"));
                return sbV30.ToString();
            }
        }

        /// <summary>A cryptographically strong token, not System.Random.</summary>
        public static string NewTokenV30()
        {
            byte[] bytesV30 = new byte[16];
            using (RandomNumberGenerator rngV30 = RandomNumberGenerator.Create())
            {
                rngV30.GetBytes(bytesV30);
            }
            return Convert.ToBase64String(bytesV30);
        }
    }
}
