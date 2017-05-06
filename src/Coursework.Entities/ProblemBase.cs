using System;
using System.Data;

namespace Coursework.Entities
{
  public class ProblemBase: EntityBase
  {
    public int M1 { get; set; }
    public int M2 { get; set; }
    public string FModule { get; set; }
    public string FArgument { get; set; }
    public double Eps { get; set; }
    public int UserId { get; set; }
    public int StateId { get; set; }
    public DateTime CreationDate { get; set; }
    public int? TaskId { get; set; }

    public virtual User User { get; set; }
    public virtual State State { get; set; }
  }
}
