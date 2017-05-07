using System;

namespace Coursework.Entities
{
  public class ProblemBase: EntityBase
  {
    public DateTime CreationDate { get; set; }
    public double Eps { get; set; }
    public string FModule { get; set; }
    public string FArgument { get; set; }
    public int M1 { get; set; }
    public int M2 { get; set; }
    public int? ResultId { get; set; }
    public int StateId { get; set; }
    public int? TaskId { get; set; }
    public int UserId { get; set; }

    public virtual ProblemResult Result { get; set; }
    public virtual State State { get; set; }
    public virtual User User { get; set; }
  }
}
