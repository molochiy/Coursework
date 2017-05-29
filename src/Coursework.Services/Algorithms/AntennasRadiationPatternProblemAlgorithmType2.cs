using System;
using System.Collections.Generic;
using Coursework.Entities.ServicesEntities;
using Problem = Coursework.Entities.DatabaseEntities.Problem;

namespace Coursework.Services.Algorithms
{
  static class AntennasRadiationPatternProblemAlgorithmType2
  {

    #region Constants
    static int M = 5;
    static int N = 5;
    static double c1 = 1;
    static double c2 = 1;
    static double alpha = ((2 * Math.PI) * (2 * Math.PI)) / (c1 * c2);
    static ComplexNumbers P = new ComplexNumbers(1, 0);
    static double eps = 1e-6;
    const int SplitNumberForIntegral = 20;
    static double[] ksi1;
    static double[] ksi2;
    static List<List<ComplexNumbers>> Imn = new List<List<ComplexNumbers>>();
    static List<List<ComplexNumbers>> ImnNext = new List<List<ComplexNumbers>>();
    static double Beta;
    #endregion

    /// <summary>
    /// calculate kernel 'K' in formula
    /// </summary>
    /// <param name="prevKsi1"></param>
    /// <param name="prevKsi2"></param>
    /// <param name="nextKsi1"></param>
    /// <param name="nextKsi2"></param>
    /// <returns></returns>
    public static ComplexNumbers K(double prevKsi1, double prevKsi2, double nextKsi1, double nextKsi2)
    {
      ComplexNumbers sum = new ComplexNumbers();
      for (int n = -N; n <= N; n++)
      {
        for (int m = -M; m <= M; m++)
        {
          sum += new ComplexNumbers
          {
            Re = Math.Cos(c1 * n * (nextKsi1 - prevKsi1) + c2 * m * ((nextKsi2 - prevKsi2))),
            Im = Math.Sin(c1 * n * (nextKsi1 - prevKsi1) + c2 * m * ((nextKsi2 - prevKsi2)))
          };
        }
      }
      return sum;
    }

    public static void CopyImn(List<List<ComplexNumbers>> From, List<List<ComplexNumbers>> To)
    {
      for (int i = 0; i < 2*N+1; i++)
      {
        for (int j = 0; j < 2*M+1; j++)
        {
          To[i][j] = From[i][j];
        }
      }
    }

    /// <summary>
    /// initialization current strength.
    /// Set first values for current
    /// </summary>
    public static void InitializationImn()
    {
      Imn.Clear();
      for (int i = 0; i < 2 * N + 1; i++)
      {
        Imn.Add(new List<ComplexNumbers>());
        for (int j = 0; j < 2 * M + 1; j++)
        {
          Imn[i].Add(new ComplexNumbers(1.0, 0));
        }
      }
    }

    public static void InitializationImnNext()
    {
      ImnNext.Clear();
      for (int i = 0; i < 2 * N + 1; i++)
      {
        ImnNext.Add(new List<ComplexNumbers>());
        for (int j = 0; j < 2 * M + 1; j++)
        {
          ImnNext[i].Add(new ComplexNumbers());
        }
      }
    }

    public static bool checkForСonvergence(List<List<ComplexNumbers>> FirstList, List<List<ComplexNumbers>> SecondList)
    {
      bool flag = true;

      for (int n = 0; n < 2 * N + 1; ++n)
      {
        for (int m = 0; m < 2 * M + 1; ++m)
        {
          if ((FirstList[n][m] - SecondList[n][m]).Module() > eps)
            flag = false;
        }
      }
      return flag;
    }

    /// <summary>
    /// set splitting for ksi1 and ksi2 for calculate integral
    /// </summary>
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

    /// <summary>
    /// set function of two variables
    /// write your function for calculate integral later
    /// </summary>
    /// <param name="i"></param>
    /// <param name="j"></param>
    /// <returns></returns>
    public static ComplexNumbers Fxy(int i, int j, int n, int m)
    {
      double x = ksi1[i];
      double y = ksi2[j];

      ComplexNumbers resultFunction = new ComplexNumbers(P);
      resultFunction *= new ComplexNumbers(Math.Cos(c1 * n * x + c2 * m * y), -1 * Math.Sin(c1 * n * x + c2 * m * y));

      ComplexNumbers summ = new ComplexNumbers();
      for (int k = -N; k <= N; ++k)
      {
        for (int l = -M; l <= M; ++l)
        {
          summ += Imn[k + N][l + M] * new ComplexNumbers(Math.Cos(c1 * l * x + c2 * k * y), Math.Sin(c1 * l * x + c2 * k * y));
        }
      }

      resultFunction *= summ;

      return resultFunction;
    }

    /// <summary>
    /// calculate integral for function Fxy
    /// </summary>
    /// <returns></returns>
    public static ComplexNumbers CalculateIntegral(int n, int m)
    {
      int Nint = 10, Mint = 10;
      double a = -1, b = 1, c = -1, d = 1;
      double Hx = (b - a) / (2 * Nint);
      double Hy = (d - c) / (2 * Mint);
      ComplexNumbers I = new ComplexNumbers(Hx * Hy / 9, 0);
      ComplexNumbers sum = new ComplexNumbers();

      for (int i = 0; i < Nint; i++)
      {
        for (int j = 0; j < Mint; j++)
        {
          sum += Fxy(2 * i, 2 * j, n, m) + Fxy(2 * i + 2, 2 * j, n, m) + Fxy(2 * i, 2 * j + 2, n, m) + Fxy(2 * i + 2, 2 * j + 2, n, m) +
              4 * Fxy(2 * i + 1, 2 * j, n, m) + 4 * Fxy(2 * i, 2 * j + 1, n, m) + 4 * Fxy(2 * i + 2, 2 * j + 1, n, m) + 4 * Fxy(2 * i + 1, 2 * j + 2, n, m) +
              16 * Fxy(2 * i + 1, 2 * j + 1, n, m);
        }
      }

      return I * sum;
    }

    /// <summary>
    /// calculate beta value
    /// </summary>
    /// <returns></returns>
    public static void CalculateBeta()
    {
      double result = 0.0;
      for (int n = 0; n < 2*N+1; ++n)
      {
        for (int m = 0; m < 2 * M + 1; ++m)
        {
          result += Math.Pow(Imn[n][m].Module(), 2);
        }
      }

      Beta = result;
    }

    /// <summary>
    /// searching Imn
    /// </summary>
    public static void CalculateImn()
    {
      Splitting();
      InitializationImn();
      InitializationImnNext();
      int count = 0;
      while (true)
      {
        CalculateBeta();
        for (int n = 0; n < 2 * N + 1; ++n)
        {
          for (int m = 0; m < 2 * M + 1; ++m)
          {
            ImnNext[n][m] = CalculateIntegral(n, m);
            ImnNext[n][m] = new ComplexNumbers(ImnNext[n][m].Re / (alpha * alpha * Beta), ImnNext[n][m].Im / (alpha * alpha * Beta));
          }
        }

        if (count == 20)
        {
          PrintResultImn();
          break;
        }
        CopyImn(ImnNext, Imn);
        count++;
      }
    }

    public static void NormalizeImn()
    {
      for (int i = 0; i < 2 * N + 1; i++)
      {
        for (int j = 0; j < 2 * M + 1; j++)
        {
          Imn[i][j].Re = Math.Abs(Imn[i][j].Re);
        }
      }

      List<List<ComplexNumbers>> tempList = new List<List<ComplexNumbers>>();
      for (int i = 0; i < 2 * N + 1; i++)
      {
        tempList.Add(new List<ComplexNumbers>());
        for (int j = 0; j < 2*M+1; j++)
        {
          tempList[i].Add(new ComplexNumbers());
        }
      }

      ComplexNumbers maxImn = new ComplexNumbers(Imn[0][0]);
      ComplexNumbers maxImnNext = new ComplexNumbers(ImnNext[0][0]);
      for (int i = 0; i < 2 * N + 1; i++)
      {
        for (int j = 0; j < 2 * M + 1; j++)
        {
          if (Imn[i][j].Re > maxImn.Re) maxImn.Re = Imn[i][j].Re;
        }
      }

      for (int i = 0; i < 2 * N + 1; i++)
      {
        for (int j = 0; j < 2 * M + 1; j++)
        {
          Imn[i][j].Re /= maxImn.Re;

        }
      }

    }

    static List<List<double>> F = new List<List<double>>();
    public static void FindF()
    {
      for (int i = 0; i <= 21; i++)
      {
        F.Add(new List<double>());
        for (int j = 0; j <= 21; j++)
        {
          F[i].Add(0);
        }
      }


      int et1 = 0;
      int et2 = 0;
      for (double i = -1; i <= 1; i += 0.1)
      {
        et2 = 0;
        for (double j = -1; j <= 1; j += 0.1)
        {
          double summ = 0;
          for (int n = -5; n <= 5; n++)
          {
            for (int m = -5; m <= 5; m++)
            {
              summ += Imn[n + 5][m + 5].Re * Math.Cos(c1 * n * i + c2 * m * j);
            }
          }
          F[et1][et2] = summ;
          et2++;
        }
        et1++;
      }
    }

    public static void NormalizeF()
    {
      double max = Math.Pow(F[0][0], 2);
      for (int i = 0; i <= 21; i++)
      {
        for (int j = 0; j <= 21; j++)
        {
          if (Math.Pow(F[i][j], 2) > max) max = Math.Pow(F[i][j], 2);
        }
      }

      for (int i = 0; i <= 21; i++)
      {
        for (int j = 0; j <= 21; j++)
        {
          F[i][j] = Math.Pow(F[i][j], 2) / max;
        }
      }
    }

    public static void PrintResultImn()
    {
      FindF();
      NormalizeF();
      NormalizeImn();
    }


    public static AntennasRadiationPatternProblemResult Calculate(Problem problem)
    {
      M = problem.M1;
      N = problem.M2;
      c1 = problem.C1;
      c2 = problem.C2;
      eps = problem.Eps;

      CalculateImn();

      double[][] arF = new double[22][];
      for (int i = 0; i < 22; i++)
      {
        arF[i] = new double[22];
      }

      for (int i = 0; i < 22; i++)
        for (int j = 0; j < 22; j++)
          arF[i][j] = F[i][j];
      //for (int i = 10; i >=0; i--)
      //    for (int j = 10; j >=0; j--)
      //      arF[10-i][10-j] = F[i][j];

      //for (int i = 21; i > 11; i--)
      //  for (int j = 10; j >= 0; j--)
      //    arF[33 - i][10 - j] = F[i][j];

      //for (int i = 10; i >= 0; i--)
      //  for (int j = 21; j > 11; j--)
      //    arF[10 - i][33 - j] = F[i][j];

      //for (int i = 21; i > 11; i--)
      //  for (int j = 21; j > 11; j--)
      //    arF[33 - i][33 - j] = F[i][j];

      arF[11][11] = F[11][11];

      double[][] arI = new double[2 * N + 1][];
      for (int i = 0; i < 2 * N + 1; i++)
      {
        arI[i] = new double[2 * M + 1];
      }

      for (int i = 0; i < 2 * N + 1; i++)
        for (int j = 0; j < 2 * M + 1; j++)
          arI[i][j] = Imn[i][j].Re;

      return new AntennasRadiationPatternProblemResult
      {
        F = arF,
        I = arI
      };

    }
  }
}
