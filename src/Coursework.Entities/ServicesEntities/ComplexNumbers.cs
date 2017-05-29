using System;

namespace Coursework.Entities.ServicesEntities
{
  public class ComplexNumbers
  {
    public double Re
    {
      get;
      set;
    }

    public double Im
    {
      get;
      set;
    }

    public ComplexNumbers()
    {
      Re = 0.0;
      Im = 0.0;
    }

    public ComplexNumbers(double re, double im)
    {
      Re = re;
      Im = im;
    }

    public ComplexNumbers(ComplexNumbers cn)
    {
      Re = cn.Re;
      Im = cn.Im;
    }

    public static ComplexNumbers operator +(ComplexNumbers cn1, ComplexNumbers cn2)
    {
      return new ComplexNumbers(cn1.Re + cn2.Re, cn1.Im + cn2.Im);
    }

    public static ComplexNumbers operator -(ComplexNumbers cn1, ComplexNumbers cn2)
    {
      return new ComplexNumbers(cn1.Re - cn2.Re, cn1.Im - cn2.Im);
    }

    public static ComplexNumbers operator *(ComplexNumbers cn1, ComplexNumbers cn2)
    {
      return new ComplexNumbers(cn1.Re * cn2.Re - cn1.Im * cn2.Im, cn1.Re * cn2.Im + cn1.Im * cn2.Re);
    }

    public static bool operator ==(ComplexNumbers cn1, ComplexNumbers cn2)
    {
      return Math.Abs(cn1.Im - cn2.Im) < double.Epsilon && Math.Abs(cn1.Re - cn2.Re) < double.Epsilon;
    }

    public static bool operator !=(ComplexNumbers cn1, ComplexNumbers cn2)
    {
      return !(cn1 == cn2);
    }

    public static bool operator >(ComplexNumbers cn1, ComplexNumbers cn2)
    {
      if (Math.Sqrt(cn1.Re * cn1.Re + cn1.Im * cn1.Im) > Math.Sqrt(cn2.Re * cn2.Re + cn2.Im * cn2.Im))
      {
        return true;
      }
      else
      {
        if (Math.Sqrt(cn1.Re * cn1.Re + cn1.Im * cn1.Im) < Math.Sqrt(cn2.Re * cn2.Re + cn2.Im * cn2.Im))
        {
          return false;
        }
        else
        {
          if (cn1.Re > cn2.Re)
          {
            return true;
          }
          else
          {
            return false;
          }
        }
      }
    }

    public static bool operator <(ComplexNumbers cn1, ComplexNumbers cn2)
    {
      return !(cn1 > cn2) && cn1 != cn2;
    }

    public static bool operator <=(ComplexNumbers first, ComplexNumbers second)
    {
      return (first < second) && (first == second);
    }

    public static bool operator >=(ComplexNumbers first, ComplexNumbers second)
    {
      return (first > second) && (first == second);
    }

    public static ComplexNumbers operator /(ComplexNumbers cn1, ComplexNumbers cn2)
    {
      return new ComplexNumbers((cn1.Re * cn2.Re + cn1.Im * cn2.Im) / (cn2.Re * cn2.Re + cn2.Im * cn2.Im), (cn1.Im * cn2.Re - cn1.Re * cn2.Im) / (cn2.Re * cn2.Re + cn2.Im * cn2.Im));
    }

    public static ComplexNumbers operator *(int first, ComplexNumbers second)
    {
      return new ComplexNumbers(first, 0) * second;
    }

    public override string ToString()
    {
      if (Im > 0.0)
      {
        return $"{Re}+{Im}i";
      }
      else
      {
        if (Im < 0 /*&& Math.Abs(this.Im) > 1e-9*/)
        {
          return $"{Re}{Im}i";
        }
        else
        {
          return $"{Re}";
        }
      }
    }

    public ComplexNumbers Conjugate()
    {
      return new ComplexNumbers(Re, -1 * Im);
    }

    public double Module()
    {
      return Math.Sqrt(this.Re * this.Re + this.Im * this.Im);
    }

    public ComplexNumbers GetModule()
    {
      return new ComplexNumbers(Math.Sqrt(Re * Re + Im * Im), 0);
    }

    public ComplexNumbers GetSqrt()
    {
      double arg = Math.PI + Math.Atan(Im / Re);

      if ((Im >= 0 && Re >= 0) || (Im <= 0 && Re >= 0))
      {
        arg = Math.Atan(Im / Re);
      }

      ComplexNumbers sqrt0 = new ComplexNumbers
      {
        Re = Math.Pow(GetModule().Re, 0.5) * Math.Cos(arg / 2.0),
        Im = Math.Pow(GetModule().Re, 0.5) * Math.Sin(arg / 2.0)
      };

      ComplexNumbers sqrt1 = new ComplexNumbers
      {
        Re = Math.Pow(GetModule().Re, 0.5) * Math.Cos((arg + 2 * Math.PI) / 2.0),
        Im = Math.Pow(GetModule().Re, 0.5) * Math.Sin((arg + 2 * Math.PI) / 2.0)
      };

      if (sqrt0.GetModule() < sqrt1.GetModule())
      {
        return sqrt0;
      }
      else
      {
        return sqrt1;
      }
    }

    public ComplexNumbers GetPow()
    {
      ComplexNumbers result = new ComplexNumbers
      {
        Re = Re * Re - Im * Im,
        Im = 2 * Re * Im
      };
      return result;
    }
  }
}
