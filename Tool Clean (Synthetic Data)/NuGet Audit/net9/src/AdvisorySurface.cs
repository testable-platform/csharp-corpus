// Tool Clean (Synthetic Data) -- dotnet package list --vulnerable (NuGet audit)
//
// CLEAN BY DESIGN: every package named from code is a patched, current release.
// EXPECTED: zero vulnerable packages.
//
// Family net9.0, C# 13.0. No project manifest lives here by design; see expected-advisories.json.

using System.Collections.Generic;

namespace ToolData.NugetAuditClean
{
    public static class AdvisorySurfaceV9
    {
        public static IEnumerable<string> PinsV9()
        {
            List<string> pinsV9 = new List<string>();
            pinsV9.Add("Newtonsoft.Json/13.0.3");
            pinsV9.Add("Serilog/3.1.1");
            return pinsV9;
        }
    }
}
