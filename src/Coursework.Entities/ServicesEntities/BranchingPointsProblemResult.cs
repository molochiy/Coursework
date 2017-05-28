using System.Collections.Generic;

namespace Coursework.Entities.ServicesEntities
{
  public class BranchingPointsProblemResult
  {
    public List<List<Point>> BranchingLines { get; set; }

    public class Point
    {
      public double C1 { get; set; }
      public double C2 { get; set; }
    }
  }
}
