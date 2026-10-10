// Tool Clean (Synthetic Data) -- Roslyn SAST analyzers
//
// CLEAN BY DESIGN: the same five operations as the Invalid fixture, written safely.
// EXPECTED: zero diagnostics in the CA2100 / SCS0001 / CA3003 / CA5351 / CA5394 families.
//
// Family net45, C# 5. The core is C# 5-compatible; src/LanguageMarker.cs pins the folder to C# 5.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ToolData.RoslynSastClean
{
    public sealed class QuerySpecV45
    {
        public string TextV45;
        public IDictionary<string, object> ParametersV45;
    }

    public static class SafeOperationsV45
    {
        private static readonly string[] AllowedReportsV45 = new string[] { "daily", "weekly", "monthly" };

        /// <summary>Parameterised: the SQL text is a constant, the value travels separately.</summary>
        public static QuerySpecV45 BuildOrderQueryV45(string skuV45)
        {
            QuerySpecV45 specV45 = new QuerySpecV45();
            specV45.TextV45 = "SELECT * FROM orders WHERE sku = @sku";
            specV45.ParametersV45 = new Dictionary<string, object>();
            specV45.ParametersV45["@sku"] = skuV45;
            return specV45;
        }

        /// <summary>The report name is checked against an allow-list; nothing is spliced into a command line.</summary>
        public static ProcessStartInfo PrepareReportV45(string reportNameV45)
        {
            if (Array.IndexOf(AllowedReportsV45, reportNameV45) < 0)
            {
                throw new ArgumentException("unknown report", "reportName");
            }
            ProcessStartInfo infoV45 = new ProcessStartInfo();
            infoV45.FileName = "report";
            infoV45.UseShellExecute = false;
            infoV45.Arguments = reportNameV45;
            return infoV45;
        }

        /// <summary>Resolves the path and refuses anything that escapes the root.</summary>
        public static string ReadTemplateV45(string rootV45, string templateNameV45)
        {
            string fullRootV45 = Path.GetFullPath(rootV45);
            string pathV45 = Path.GetFullPath(Path.Combine(fullRootV45, templateNameV45));
            if (!pathV45.StartsWith(fullRootV45 + Path.DirectorySeparatorChar, StringComparison.Ordinal))
            {
                throw new ArgumentException("template escapes root", "templateName");
            }
            return File.Exists(pathV45) ? File.ReadAllText(pathV45) : string.Empty;
        }

        /// <summary>SHA-256, not MD5.</summary>
        public static string FingerprintV45(string payloadV45)
        {
            using (SHA256 shaV45 = SHA256.Create())
            {
                byte[] hashV45 = shaV45.ComputeHash(Encoding.UTF8.GetBytes(payloadV45));
                StringBuilder sbV45 = new StringBuilder();
                for (int iV45 = 0; iV45 < hashV45.Length; iV45++) sbV45.Append(hashV45[iV45].ToString("x2"));
                return sbV45.ToString();
            }
        }

        /// <summary>A cryptographically strong token, not System.Random.</summary>
        public static string NewTokenV45()
        {
            byte[] bytesV45 = new byte[16];
            using (RandomNumberGenerator rngV45 = RandomNumberGenerator.Create())
            {
                rngV45.GetBytes(bytesV45);
            }
            return Convert.ToBase64String(bytesV45);
        }
    }
}
