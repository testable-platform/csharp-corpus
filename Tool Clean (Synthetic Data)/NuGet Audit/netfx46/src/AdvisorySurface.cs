// Tool Clean (Synthetic Data) -- dotnet package list --vulnerable (NuGet audit)
//
// CLEAN BY DESIGN: every package named from code is a patched, current release.
// EXPECTED: zero vulnerable packages.
//
// Family net46, C# 6. No project manifest lives here by design; see expected-advisories.json.

using System.Collections.Generic;

namespace ToolData.NugetAuditClean
{
    public static class AdvisorySurfaceV46
    {
        public static IEnumerable<string> PinsV46()
        {
            List<string> pinsV46 = new List<string>();
            pinsV46.Add("Newtonsoft.Json/13.0.3");
            pinsV46.Add("Serilog/3.1.1");
            return pinsV46;
        }
    }
}
