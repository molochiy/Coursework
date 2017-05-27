﻿using System;

namespace Coursework.Entities.ViewModels
{
  public class ProblemViewModel

  {
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public double Eps { get; set; }
    public string FModule { get; set; }
    public string FArgument { get; set; }
    public int M1 { get; set; }
    public int M2 { get; set; }
    public double C1 { get; set; }
    public double C2 { get; set; }
    public int? ResultId { get; set; }
    public int StateId { get; set; }
    public int TypeId { get; set; }
  }
}
