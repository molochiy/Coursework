using System;

namespace Coursework.Entities.ServicesEntities
{
  public class BranchingPointsProblem

  {
    public DateTime CreationDate { get; set; }
    public double Eps { get; set; }
    public string FModule { get; set; }
    public string FArgument { get; set; }
    public int M1 { get; set; }
    public int M2 { get; set; }
    public int StateId { get; set; }
    public int UserId { get; set; }
  }
}