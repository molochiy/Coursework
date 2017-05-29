using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework.Entities.ServicesEntities
{
  public class BranchingLinesProblrmResult
  {
    public List<Line> BranchingLines { get; set; }

    public class Line
    {
      public double[] x { get; set; }
      public double[] y { get; set; }
    }
  }
}
