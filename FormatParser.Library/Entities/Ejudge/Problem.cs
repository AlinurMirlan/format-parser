using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatParser.Library.Entities.Ejudge;

public class Problem
{
    public byte UseStdin { get; set; }
    public byte UseStdout { get; set; }
    public byte UseCorr { get; set; }
    public byte EnabeTestlibMode { get; set; }
    public double TimeLimit { get; set; }
    public required string MaxVmSize { get; set; }
    public required string LongName { get; set; }
    public required string LongNameEn { get; set; }
    public required string InternalName { get; set; }
    public required string TestPat { get; set; }
    public required string CorrPat { get; set; }
    public required string CheckCmd { get; set; }
    public required string SolutionCmd { get; set; }
    public string? ExtId { get; set; }
    public int Revision { get; set; }
}
