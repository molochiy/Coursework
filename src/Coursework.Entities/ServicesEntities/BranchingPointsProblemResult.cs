using System.Collections.Generic;

namespace Coursework.Entities.ServicesEntities
{
  public class BranchingPointsProblemResult
  {
    public List<Line> BranchingLines { get; set; }

    public class Line
    {
      public double[] x { get; set; }
      public double[] y { get; set; }
    }
  }
}
