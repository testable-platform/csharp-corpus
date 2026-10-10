// Tool Clean (Synthetic Data) -- dotnet package list --vulnerable (NuGet audit)
//
// CLEAN BY DESIGN: every package named from code is a patched, current release.
// EXPECTED: zero vulnerable packages.
//
// Family netcoreapp3.0, C# 8.0. No project manifest lives here by design; see expected-advisories.json.

using System.Collections.Generic;

namespace ToolData.NugetAuditClean
{
    public static class AdvisorySurfaceV30
    {
        public static IEnumerable<string> PinsV30()
        {
            List<string> pinsV30 = new List<string>();
            pinsV30.Add("Newtonsoft.Json/13.0.3");
            pinsV30.Add("Serilog/3.1.1");
            return pinsV30;
        }
    }
}
