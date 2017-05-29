using System;

namespace Coursework.Entities.DatabaseEntities
{
  public class Problem: EntityBase
  {
    public double C1 { get; set; }
    public double C2 { get; set; }
    public int NumberPartitionsC1 { get; set; }
    public int NumberPartitionsC2 { get; set; }
    public DateTime CreationDate { get; set; }
    public double Eps { get; set; }
    public string FModule { get; set; }
    public string FArgument { get; set; }
    public int M1 { get; set; }
    public int M2 { get; set; }
    public int TypeId { get; set; }
    public int? ResultId { get; set; }
    public int StateId { get; set; }
    public int? TaskId { get; set; }
    public int UserId { get; set; }

    public virtual ProblemResult Result { get; set; }
    public virtual ProblemType ProblemType { get; set; }
    public virtual State State { get; set; }
    public virtual User User { get; set; }
  }
}
