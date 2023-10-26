using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormatParser.Library.Entities.Ejudge;

public class Valuer
{
    public Global? Global { get; set; }
    public List<Group> Groups { get; set; } = new List<Group>();
}
