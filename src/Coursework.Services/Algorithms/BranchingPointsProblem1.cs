using System;
using System.Collections.Generic;
using Coursework.Entities.ServicesEntities;
using Problem = Coursework.Entities.DatabaseEntities.Problem;

namespace Coursework.Services.Algorithms
{
  static class BranchingPointsProblem1
  {
    #region Constants
    const int SplitNumberForIntegral = 10;
    static double[] ksi1;
    static double[] ksi2;
    static int M = 5;
    static int N = 5;
    static double eps = 1e-3;
    #endregion

    public static void Splitting()
    {
      ksi1 = new double[SplitNumberForIntegral + 1];
      ksi2 = new double[SplitNumberForIntegral + 1];
      for (int i = 0; i <= SplitNumberForIntegral; i++)
      {
        ksi1[i] = i * 1.0 / (SplitNumberForIntegral / 2) - 1;
        ksi2[i] = i * 1.0 / (SplitNumberForIntegral / 2) - 1;
      }
    }

    public static double CalculateAlpha(double c1, double c2)
    {
      return (c1 == 0 || c2 == 0) ? 0 : ((2 * Math.PI) * (2 * Math.PI)) / (c1 * c2);
    }

    public static ComplexNumbers Fxy(double c1, double c2, double ksi1Value, double ksi2Value, int i, int j)
    {
      double x = ksi1[i];
      double y = ksi2[j];

      ComplexNumbers sum = new ComplexNumbers();
      for (int n = -N; n <= N; n++)
      {
        for (int m = -M; m <= M; m++)
        {
          sum += new ComplexNumbers
          {
            Re = Math.Cos(c1 * n * (ksi1Value - x) + c2 * m * ((ksi2Value - y))),
            Im = Math.Sin(c1 * n * (ksi1Value - x) + c2 * m * ((ksi2Value - y)))
          };
        }
      }
      return sum;
    }

    public static ComplexNumbers CalculateIntegral(double c1, double c2, double ksi1Value, double ksi2Value)
    {
      int N = SplitNumberForIntegral / 2, M = SplitNumberForIntegral / 2;
      double a = -1, b = 1, c = -1, d = 1;
      double Hx = (b - a) / (2 * N);
      double Hy = (d - c) / (2 * M);
      ComplexNumbers I = new ComplexNumbers(Hx * Hy / 9, 0);
      ComplexNumbers sum = new ComplexNumbers();

      for (int i = 0; i < N; i++)
      {
        for (int j = 0; j < M; j++)
        {
          sum += Fxy(c1, c2, ksi1Value, ksi2Value, 2 * i, 2 * j) + Fxy(c1, c2, ksi1Value, ksi2Value, 2 * i + 2, 2 * j) +
              Fxy(c1, c2, ksi1Value, ksi2Value, 2 * i, 2 * j + 2) + Fxy(c1, c2, ksi1Value, ksi2Value, 2 * i + 2, 2 * j + 2) +
              4 * Fxy(c1, c2, ksi1Value, ksi2Value, 2 * i + 1, 2 * j) + 4 * Fxy(c1, c2, ksi1Value, ksi2Value, 2 * i, 2 * j + 1) +
              4 * Fxy(c1, c2, ksi1Value, ksi2Value, 2 * i + 2, 2 * j + 1) + 4 * Fxy(c1, c2, ksi1Value, ksi2Value, 2 * i + 1, 2 * j + 2) +
              16 * Fxy(c1, c2, ksi1Value, ksi2Value, 2 * i + 1, 2 * j + 1);
        }
      }

      // ComplexNumbers res = new ComplexNumbers(I * sum * (new ComplexNumbers(1, 0) / (new ComplexNumbers(2, 0)*new ComplexNumbers(CalculateAlpha(c1, c2), 0) * new ComplexNumbers(CalculateAlpha(c1, c2), 0))));
      ComplexNumbers res = new ComplexNumbers(I * sum * (new ComplexNumbers(2, 0) / (new ComplexNumbers(CalculateAlpha(c1, c2), 0))));
      return res;
    }

    public static KeyValuePair<ComplexNumbers[,], ComplexNumbers[,]> LU(ComplexNumbers[,] A)
    {
      int n = A.GetLength(0);
      ComplexNumbers[,] L = new ComplexNumbers[n, n];
      ComplexNumbers[,] U = new ComplexNumbers[n, n];
      for (int i = 0; i < n; i++)
      {
        for (int j = 0; j < n; j++)
        {
          U[0, i] = A[0, i];
          L[i, 0] = A[i, 0] / U[0, 0];
          ComplexNumbers sum = new ComplexNumbers();
          for (int k = 0; k < i; k++)
          {
            sum += L[i, k] * U[k, j];
          }
          U[i, j] = A[i, j] - sum;
          if (i > j)
          {
            L[j, i] = new ComplexNumbers();
          }
          else
          {
            sum = new ComplexNumbers();
            for (int k = 0; k < i; k++)
            {
              sum += L[j, k] * U[k, i];
            }
            L[j, i] = (A[j, i] - sum) / U[i, i];
          }
        }
      }
      KeyValuePair<ComplexNumbers[,], ComplexNumbers[,]> result = new KeyValuePair<ComplexNumbers[,], ComplexNumbers[,]>(L, U);
      return result;
    }

    public static ComplexNumbers Det(ComplexNumbers[,] A)
    {
      KeyValuePair<ComplexNumbers[,], ComplexNumbers[,]> lu = LU(A);
      int n = A.GetLength(0);
      ComplexNumbers det1 = new ComplexNumbers(1, 0);
      ComplexNumbers det2 = new ComplexNumbers(1, 0);
      for (int i = 0; i < n; i++)
      {
        det1 *= lu.Key[i, i];
        det2 *= lu.Value[i, i];
      }
      return det1 * det2;
    }

    public static ComplexNumbers FxNewton(double c1, double c2)
    {
      ComplexNumbers[,] a = new ComplexNumbers[SplitNumberForIntegral, SplitNumberForIntegral];
      for (int i = 0; i < SplitNumberForIntegral; i++)
      {
        for (int j = 0; j < SplitNumberForIntegral; j++)
        {
          a[i, j] = CalculateIntegral(c1, c2, ksi1[i], ksi1[j]);
        }
      }

      return Det(a);
    }

    public static ComplexNumbers[,] PoxidnaMatrix(double c1, double c2)
    {
      double delta = 0.001;
      ComplexNumbers[,] a = new ComplexNumbers[SplitNumberForIntegral, SplitNumberForIntegral];
      for (int i = 0; i < SplitNumberForIntegral; i++)
      {
        for (int j = 0; j < SplitNumberForIntegral; j++)
        {
          a[i, j] = (CalculateIntegral(c1, c2 + delta, ksi1[i], ksi1[j]) - CalculateIntegral(c1, c2, ksi1[i], ksi1[j])) / new ComplexNumbers(delta, 0);
        }
      }

      return a;
    }

    private static ComplexNumbers FxNewtonPox(double c1, double c2)
    {
      // D = LU
      // B = MU + LV

      int n = SplitNumberForIntegral;

      ComplexNumbers[,] D = new ComplexNumbers[n, n];
      for (int i = 0; i < SplitNumberForIntegral; i++)
      {
        for (int j = 0; j < SplitNumberForIntegral; j++)
        {
          D[i, j] = CalculateIntegral(c1, c2, ksi1[i], ksi1[j]);
        }
      }

      ComplexNumbers[,] B = PoxidnaMatrix(c1, c2);
      ComplexNumbers[,] L = new ComplexNumbers[n, n];

      for (int i = 0; i < n; i++)
      {
        L[i, i] = new ComplexNumbers(1, 0);
      }

      ComplexNumbers[,] U = new ComplexNumbers[n, n];
      ComplexNumbers[,] V = new ComplexNumbers[n, n];
      ComplexNumbers[,] M = new ComplexNumbers[n, n];

      for (int r = 0; r < n; r++)
      {
        for (int k = r; k < n; k++)
        {
          ComplexNumbers sumU = new ComplexNumbers(0, 0.0);
          ComplexNumbers sumV = new ComplexNumbers(0, 0.0);
          for (int j = 0; j < r; j++)
          {
            sumU += L[r, j] * U[j, k];
            sumV += M[r, j] * U[j, k] + L[r, j] * V[j, k];
          }
          U[r, k] = D[r, k] - sumU;
          V[r, k] = B[r, k] - sumV;
        }

        for (int i = r + 1; i < n; i++)
        {
          ComplexNumbers sumL = new ComplexNumbers(0, 0.0);
          ComplexNumbers sumM = new ComplexNumbers(0, 0.0);
          for (int j = 0; j < r; j++)
          {
            sumL = sumL + (L[i, j] * U[j, r]);
            sumM = sumM + (M[i, j] * U[j, r] + L[i, j] * V[j, r]);
          }
          L[i, r] = (D[i, r] - sumL) / U[r, r];
          M[i, r] = (B[i, r] - sumM - L[i, r] * V[r, r]) / U[r, r];
        }
      }


      ComplexNumbers detB = new ComplexNumbers(0, 0.0);

      for (int i = 0; i < n; i++)
      {
        ComplexNumbers sum = V[i, i];

        for (int k = 0; k < n; k++)
        {
          if (k != i)
          {
            sum *= U[k, k];
          }
        }

        detB += sum;
      }

      return detB;
    }

    public static BranchingLinesProblrmResult Calculate(Problem problem)
    {
      M = problem.M1;
      N = problem.M2;
      eps = problem.Eps;
      
      Splitting();
      double c1 = 2.3;
      double c2 = 0.1;
      List<double> C1 = new List<double>();
      List<double> C2 = new List<double>();
      List<List<KeyValuePair<double, double>>> list = new List<List<KeyValuePair<double, double>>>();

      c1 = 1.8;
      while (c1 <= 2.0)
      {
        c2 = 2.2;
        List<KeyValuePair<double, double>> res = new List<KeyValuePair<double, double>>();
        while (c2 <= 2.5)
        {
          double prev = c2;
          double next = 10;
          int count = 0;
          double temp = 0;

          while (true)
          {
            double x1 = FxNewton(c1, prev).Re;
            double x2 = FxNewtonPox(c1, prev).Re;
            next = prev - ((x2 == 0) ? 0 : (x1 / x2));
            count++;
            Console.Write(count + " ");
            if ((Math.Abs(next - prev) < eps || count == 100))
            {
              res.Add(new KeyValuePair<double, double>(c1, next));

              temp = next;
              break;
            }
            prev = next;
          }

          c2 = c2 + 0.1;
        }
        list.Add(res);
        c1 = c1 + 0.1;
      }

      BranchingLinesProblrmResult result = new BranchingLinesProblrmResult();
      result.BranchingLines = new List<BranchingLinesProblrmResult.Line>();
      for (int i = 0; i < list.Count; i++)
      {
        BranchingLinesProblrmResult.Line line = new BranchingLinesProblrmResult.Line();
        line.x = new double[list[i].Count];
        line.y = new double[list[i].Count];
        for (int j = 0; j < list[i].Count; j++)
        {
          line.x[j] = list[i][j].Key;
          line.y[j] = list[i][j].Value;
        }
        result.BranchingLines.Add(line);
      }

      return result;
    }
  }
}
