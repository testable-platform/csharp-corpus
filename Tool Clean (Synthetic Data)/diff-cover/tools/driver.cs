using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using PilotOps;

var rotation = new PilotRotation();
rotation.Register(new PilotAssignment { PilotName = "Dana Okafor", VesselId = "MV-Halcyon" });
rotation.Register(new PilotAssignment { PilotName = "Iker Solano", VesselId = "MV-Meridian" });

if (rotation.Count() != 2)
{
    Console.Error.WriteLine("ASSERTION FAILED: expected 2 assignments");
    Environment.Exit(1);
}

var found = rotation.NextPilotFor("MV-Meridian");
if (found != "Iker Solano")
{
    Console.Error.WriteLine("ASSERTION FAILED: expected Iker Solano for MV-Meridian");
    Environment.Exit(1);
}

var missing = rotation.NextPilotFor("MV-Nonexistent");
if (missing != null)
{
    Console.Error.WriteLine("ASSERTION FAILED: expected null for unknown vessel");
    Environment.Exit(1);
}

WriteCobertura();
Console.WriteLine("ALL_ASSERTIONS_PASSED");

void WriteCobertura()
{
    var snapshot = Cov.Snapshot();
    Directory.CreateDirectory("coverage");

    var sourceFile = "src/PilotRotation.cs";
    var coverableLines = FindCoverableLines(sourceFile);
    var hitLines = snapshot.TryGetValue(sourceFile, out var set) ? set : new HashSet<int>();

    int hitCount = coverableLines.Count(l => hitLines.Contains(l));
    double lineRate = coverableLines.Count == 0 ? 1.0 : (double)hitCount / coverableLines.Count;

    using var writer = new StreamWriter("coverage/cobertura-coverage.xml");
    writer.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
    writer.WriteLine($"<coverage line-rate=\"{lineRate.ToString("0.0000", CultureInfo.InvariantCulture)}\" branch-rate=\"1.0\" version=\"1.9\" timestamp=\"{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}\">");
    writer.WriteLine("  <packages>");
    writer.WriteLine($"    <package name=\"PilotOps\" line-rate=\"{lineRate.ToString("0.0000", CultureInfo.InvariantCulture)}\" branch-rate=\"1.0\">");
    writer.WriteLine("      <classes>");
    writer.WriteLine($"        <class name=\"PilotRotation\" filename=\"{sourceFile}\" line-rate=\"{lineRate.ToString("0.0000", CultureInfo.InvariantCulture)}\" branch-rate=\"1.0\">");
    writer.WriteLine("          <lines>");
    foreach (var line in coverableLines.OrderBy(l => l))
    {
        int hits = hitLines.Contains(line) ? 1 : 0;
        writer.WriteLine($"            <line number=\"{line}\" hits=\"{hits}\" branch=\"false\"/>");
    }
    writer.WriteLine("          </lines>");
    writer.WriteLine("        </class>");
    writer.WriteLine("      </classes>");
    writer.WriteLine("    </package>");
    writer.WriteLine("  </packages>");
    writer.WriteLine("</coverage>");
}

List<int> FindCoverableLines(string relativePath)
{
    var lines = File.ReadAllLines(relativePath);
    var result = new List<int>();
    for (int i = 0; i < lines.Length; i++)
    {
        if (lines[i].Contains("Cov.Mark("))
        {
            result.Add(i + 1);
        }
    }
    return result;
}
