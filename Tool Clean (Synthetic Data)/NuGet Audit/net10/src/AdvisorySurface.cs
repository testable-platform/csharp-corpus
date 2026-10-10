// Tool Clean (Synthetic Data) -- dotnet package list --vulnerable (NuGet audit)
//
// CLEAN BY DESIGN: every package named from code is a patched, current release.
// EXPECTED: zero vulnerable packages.
//
// Family net10.0, C# 14.0. No project manifest lives here by design; see expected-advisories.json.

using System.Collections.Generic;

namespace ToolData.NugetAuditClean
{
    public static class AdvisorySurface
    {
        public static IEnumerable<string> Pins()
        {
            List<string> pins = new List<string>();
            pins.Add("Newtonsoft.Json/13.0.3");
            pins.Add("Serilog/3.1.1");
            return pins;
        }
    }
}
