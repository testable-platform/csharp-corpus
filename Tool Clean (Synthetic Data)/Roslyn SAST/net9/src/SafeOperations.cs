// Tool Clean (Synthetic Data) -- Roslyn SAST analyzers
//
// CLEAN BY DESIGN: the same five operations as the Invalid fixture, written safely.
// EXPECTED: zero diagnostics in the CA2100 / SCS0001 / CA3003 / CA5351 / CA5394 families.
//
// Family net9.0, C# 13.0. The core is C# 5-compatible; src/LanguageMarker.cs pins the folder to C# 13.0.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ToolData.RoslynSastClean
{
    public sealed class QuerySpecV9
    {
        public string TextV9;
        public IDictionary<string, object> ParametersV9;
    }

    public static class SafeOperationsV9
    {
        private static readonly string[] AllowedReportsV9 = new string[] { "daily", "weekly", "monthly" };

        /// <summary>Parameterised: the SQL text is a constant, the value travels separately.</summary>
        public static QuerySpecV9 BuildOrderQueryV9(string skuV9)
        {
            QuerySpecV9 specV9 = new QuerySpecV9();
            specV9.TextV9 = "SELECT * FROM orders WHERE sku = @sku";
            specV9.ParametersV9 = new Dictionary<string, object>();
            specV9.ParametersV9["@sku"] = skuV9;
            return specV9;
        }

        /// <summary>The report name is checked against an allow-list; nothing is spliced into a command line.</summary>
        public static ProcessStartInfo PrepareReportV9(string reportNameV9)
        {
            if (Array.IndexOf(AllowedReportsV9, reportNameV9) < 0)
            {
                throw new ArgumentException("unknown report", "reportName");
            }
            ProcessStartInfo infoV9 = new ProcessStartInfo();
            infoV9.FileName = "report";
            infoV9.UseShellExecute = false;
            infoV9.Arguments = reportNameV9;
            return infoV9;
        }

        /// <summary>Resolves the path and refuses anything that escapes the root.</summary>
        public static string ReadTemplateV9(string rootV9, string templateNameV9)
        {
            string fullRootV9 = Path.GetFullPath(rootV9);
            string pathV9 = Path.GetFullPath(Path.Combine(fullRootV9, templateNameV9));
            if (!pathV9.StartsWith(fullRootV9 + Path.DirectorySeparatorChar, StringComparison.Ordinal))
            {
                throw new ArgumentException("template escapes root", "templateName");
            }
            return File.Exists(pathV9) ? File.ReadAllText(pathV9) : string.Empty;
        }

        /// <summary>SHA-256, not MD5.</summary>
        public static string FingerprintV9(string payloadV9)
        {
            using (SHA256 shaV9 = SHA256.Create())
            {
                byte[] hashV9 = shaV9.ComputeHash(Encoding.UTF8.GetBytes(payloadV9));
                StringBuilder sbV9 = new StringBuilder();
                for (int iV9 = 0; iV9 < hashV9.Length; iV9++) sbV9.Append(hashV9[iV9].ToString("x2"));
                return sbV9.ToString();
            }
        }

        /// <summary>A cryptographically strong token, not System.Random.</summary>
        public static string NewTokenV9()
        {
            byte[] bytesV9 = new byte[16];
            using (RandomNumberGenerator rngV9 = RandomNumberGenerator.Create())
            {
                rngV9.GetBytes(bytesV9);
            }
            return Convert.ToBase64String(bytesV9);
        }
    }
}
