using System;
using System.Collections.Generic;
using Coursework.Entities.ServicesEntities;
using Problem = Coursework.Entities.DatabaseEntities.Problem;

namespace Coursework.Services.Algorithms
{
  static class AntennasRadiationPatternProblemAlgorithmType1
  {
    private static int _m;
    private static int _n;

    private static double _c1;
    private static double _c2;

    private static double _modF;
    private static double _argF;

    private static ComplexNumbers ComputeIntegralForKsiInPow(double ksi1, double ksi2)
    {
      ComplexNumbers result = new ComplexNumbers();

      for (int n = -_n; n <= _n; n++)
      {
        for (int m = -_m; m <= _m; m++)
        {
          result += (new ComplexNumbers(-Math.Cos(_c1 * n * (ksi1 - 1) + _c2 * m * (ksi2 - 1))
            + Math.Cos(_c1 * n * (ksi1 + 1) + _c2 * m * (ksi2 - 1))
            + Math.Cos(_c1 * n * (ksi1 - 1) + _c2 * m * (ksi2 + 1))
            - Math.Cos(_c1 * n * (ksi1 + 1) + _c2 * m * (ksi2 + 1)),
            -Math.Sin(_c1 * n * (ksi1 - 1) + _c2 * m * (ksi2 - 1))
            + Math.Sin(_c1 * n * (ksi1 + 1) + _c2 * m * (ksi2 - 1))
            + Math.Sin(_c1 * n * (ksi1 - 1) + _c2 * m * (ksi2 + 1))
            - Math.Sin(_c1 * n * (ksi1 + 1) + _c2 * m * (ksi2 + 1)))
  * new ComplexNumbers(_c1 * _c2 * n * m, 0)).GetPow();
        }

      }
      return result;
    }

    private static ComplexNumbers ComputeIntegralForKsi(double ksi1, double ksi2)
    {
      ComplexNumbers result = new ComplexNumbers();

      for (int n = -_n; n <= _n; n++)
      {
        for (int m = -_m; m <= _m; m++)
        {
          result += new ComplexNumbers(-Math.Cos(_c1 * n * (ksi1 - 1) + _c2 * m * (ksi2 - 1)) + Math.Cos(_c1 * n * (ksi1 + 1) + _c2 * m * (ksi2 - 1)) + Math.Cos(_c1 * n * (ksi1 - 1) + _c2 * m * (ksi2 + 1)) - Math.Cos(_c1 * n * (ksi1 + 1) + _c2 * m * (ksi2 + 1)), -Math.Sin(_c1 * n * (ksi1 - 1) + _c2 * m * (ksi2 - 1)) + Math.Sin(_c1 * n * (ksi1 + 1) + _c2 * m * (ksi2 - 1)) + Math.Sin(_c1 * n * (ksi1 - 1) + _c2 * m * (ksi2 + 1)) - Math.Sin(_c1 * n * (ksi1 + 1) + _c2 * m * (ksi2 + 1))) * new ComplexNumbers(_c1 * _c2 * n * m, 0);
        }

      }
      return result;
    }

    private static ComplexNumbers ComputeIntegralForI(double ksi1, double ksi2)
    {
      ComplexNumbers result = new ComplexNumbers();

      for (int n = -_n; n <= _n; n++)
      {
        for (int m = -_m; m <= _m; m++)
        {
          result += new ComplexNumbers(Math.Cos(-_c1 * n * ksi1 - _c2 * m * ksi2), Math.Sin(-_c1 * n * ksi1 - _c2 * m * ksi2));
        }

      }
      return result;
    }

    public static AntennasRadiationPatternProblemResult Calculate(Problem problem)
    {
      _m = problem.M1;
      _n = problem.M2;
      _c1 = problem.C1;
      _c2 = problem.C2;
      _modF = Convert.ToDouble(problem.FModule.Replace(".", ","));
      _argF = Convert.ToDouble(problem.FArgument.Replace(".", ","));

      /*****************************************************************************************/

      List<List<ComplexNumbers>> I = new List<List<ComplexNumbers>>();

      for (int i = 0; i < 11; i++)
      {
        I.Add(new List<ComplexNumbers>());
      }

      ComplexNumbers alpha = new ComplexNumbers(Math.Pow(2 * Math.PI, 2) / (_c1 * _c2), 0);
      ComplexNumbers p = new ComplexNumbers(1, 0);

      double limitWidth = 1;
      double limitHeight = 1;

      List<List<ComplexNumbers>> lastF = new List<List<ComplexNumbers>>();

      ComplexNumbers maxF = new ComplexNumbers();

      double step = problem.Eps < 0.01 ? problem.Eps : 0.01;//limitHeight / M;

      for (double i = -limitWidth; i <= limitWidth; i += step)
      {
        lastF.Add(new List<ComplexNumbers>());
        for (double j = -limitHeight; j <= limitHeight; j += step)
        {
          ComplexNumbers fPrev = new ComplexNumbers(_modF * Math.Cos(_argF), _modF * Math.Sin(_argF));

          ComplexNumbers F;

          ComplexNumbers D;

          double amountStepsForKsi1 = 10;
          double amountStepsForKsi2 = 10;
          double hksi1 = (limitHeight * 2) / (2 * amountStepsForKsi1); // (b-a)/2N
          double hksi2 = (limitWidth * 2) / (2 * amountStepsForKsi2); // (d-c)/2M

          ComplexNumbers kFor2 = new ComplexNumbers();

          for (int k = 0; k < amountStepsForKsi1; k++)
          {
            for (int l = 0; l < amountStepsForKsi2; l++)
            {
              kFor2 += (ComputeIntegralForKsiInPow(2 * k * hksi1, 2 * l * hksi2) + ComputeIntegralForKsiInPow((2 * k + 2) * hksi1, 2 * l * hksi2) + ComputeIntegralForKsiInPow(2 * k * hksi1, (2 * l + 2) * hksi2) + ComputeIntegralForKsiInPow((2 * k + 2) * hksi1, (2 * l + 2) * hksi2) +
                      new ComplexNumbers(4.0, 0) * (ComputeIntegralForKsiInPow((2 * k + 1) * hksi1, 2 * l * hksi2) +
                      ComputeIntegralForKsiInPow(2 * k * hksi1, (2 * l + 1) * hksi2) +
                      ComputeIntegralForKsiInPow((2 * k + 2) * hksi1, (2 * l + 1) * hksi2) +
                      ComputeIntegralForKsiInPow((2 * k + 1) * hksi1, (2 * l + 2) * hksi2)) +
                      new ComplexNumbers(16.0, 0) * ComputeIntegralForKsiInPow((2 * k + 1) * hksi1, (2 * l + 1) * hksi2));
            }
          }
          kFor2 *= new ComplexNumbers((hksi1 * hksi2) / 9.0, 0);

          var ab = kFor2 * (p - fPrev.GetModule().GetPow()) * fPrev.GetPow();
          var a2 = kFor2 * (p - fPrev.GetModule().GetPow()).GetPow() * fPrev.GetPow();
          var b2 = kFor2 * fPrev.GetPow();

          D = new ComplexNumbers(16, 0) * ab.GetPow() - new ComplexNumbers(4, 0) * b2 * (a2 - alpha.GetPow() * p);

          ComplexNumbers l1 = (new ComplexNumbers(-4, 0) * ab + D.GetSqrt()) / (new ComplexNumbers(2, 0) * b2);
          ComplexNumbers l2 = (new ComplexNumbers(-4, 0) * ab - D.GetSqrt()) / (new ComplexNumbers(2, 0) * b2);

          ComplexNumbers lambda;
          if (l2.GetModule() > l1.GetModule())
          {
            lambda = l1;
          }
          else
          {
            lambda = l2;
          }

          ComplexNumbers a = ComputeIntegralForKsi(i, j) * (p - fPrev.GetModule().GetPow()) * fPrev;

          ComplexNumbers b = ComputeIntegralForKsi(i, j) * fPrev;

          F = (new ComplexNumbers(2, 0) * a + lambda * b) / alpha;

          if (i >= -1.1 && i <= 1.1 && j >= -1.1 && j <= 1.1)
          {
            ComplexNumbers kForI = new ComplexNumbers();

            for (int k = 0; k < amountStepsForKsi1; k++)
            {
              for (int l = 0; l < amountStepsForKsi2; l++)
              {
                kForI += (ComputeIntegralForI(2 * k * hksi1, 2 * l * hksi2) + ComputeIntegralForI((2 * k + 2) * hksi1, 2 * l * hksi2) + ComputeIntegralForI(2 * k * hksi1, (2 * l + 2) * hksi2) + ComputeIntegralForI((2 * k + 2) * hksi1, (2 * l + 2) * hksi2) +
                        new ComplexNumbers(4.0, 0) * (ComputeIntegralForI((2 * k + 1) * hksi1, 2 * l * hksi2) +
                        ComputeIntegralForI(2 * k * hksi1, (2 * l + 1) * hksi2) +
                        ComputeIntegralForI((2 * k + 2) * hksi1, (2 * l + 1) * hksi2) +
                        ComputeIntegralForI((2 * k + 1) * hksi1, (2 * l + 2) * hksi2)) +
                        new ComplexNumbers(16.0, 0) * ComputeIntegralForI((2 * k + 1) * hksi1, (2 * l + 1) * hksi2));
              }
            }

            kForI *= new ComplexNumbers((hksi1 * hksi2) / 9.0, 0);
            int index = Convert.ToInt32((1.0 + i) / 0.2);
            I[index].Add((p - F.GetModule().GetPow()) * F * kForI + lambda * F * kForI);

          }

          if (F > maxF)
          {
            maxF = F;
          }
          lastF[lastF.Count - 1].Add(F);
        }
      }

      var maxI = I[0][0];

      for (int i = 0; i < I.Count; i++)
      {
        for (int j = 0; j < I[i].Count; j++)
        {
          if (maxI < I[i][j])
          {
            maxI = I[i][j];
          }
        }
      }

      var result = new AntennasRadiationPatternProblemResult();
      result.I = new double[I.Count][];

      for (int i = 0; i < I.Count; i++)
      {
        result.I[i] = new double[I[i].Count];
        for (int j = 0; j < I[i].Count; j++)
        {
          result.I[i][j] = (I[i][j] / maxI).GetModule().Re;
        }
      }

      result.F = new double[lastF.Count][];
      for (int i = 0; i < lastF.Count; i++)
      {
        result.F[i] = new double[lastF.Count];
        for (int j = 0; j < lastF[i].Count; j++)
        {
          result.F[i][j] = (lastF[i][j] / maxF).GetModule().Re;
        }
      }

      return result;
    }
  }
}
