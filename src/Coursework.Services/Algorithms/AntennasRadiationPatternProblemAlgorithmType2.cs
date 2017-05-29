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
    static double c1 = 1.15;
    static double c2 = 1.15;
    static double eps = 0.00001;
    //const double alpha = ((2 * Math.PI) * (2 * Math.PI)) / (c1 * c2);
    //static ComplexNumbers P = new ComplexNumbers(1, 0);
    //static double eps = 1e-6;
    const int SplitNumberForIntegral = 10;
    static double[] ksi1;
    static double[] ksi2;
    static ComplexNumbers P = new ComplexNumbers(1, 0);

    static List<List<ComplexNumbers>> matrixF = new List<List<ComplexNumbers>>();
    static List<List<ComplexNumbers>> matrixFNext = new List<List<ComplexNumbers>>();
    //static double Beta;
    static double modulF = 1;
    static double argF = 0;
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

    public static ComplexNumbers GetK(double integralKsi1, double integralKsi2, double Ksi1, double Ksi2)
    {
      ComplexNumbers sum = new ComplexNumbers();
      for (int n = -N; n <= N; n++)
      {
        for (int m = -M; m <= M; m++)
        {
          double val = c1 * n * (Ksi1 - integralKsi1) + c2 * m * ((Ksi2 - integralKsi2));
          sum += new ComplexNumbers
          {
            Re = Math.Cos(val),
            Im = Math.Sin(val)
          };
        }
      }
      return sum;
    }

    public static void InitializeF()
    {
      matrixF = new List<List<ComplexNumbers>>();
      for (int i = 0; i <= SplitNumberForIntegral; i++)
      {
        matrixF.Add(new List<ComplexNumbers>());
        for (int j = 0; j <= SplitNumberForIntegral; j++)
        {
          matrixF[i].Add(new ComplexNumbers
          {
            Re = modulF * Math.Cos(argF),
            Im = modulF * Math.Sin(argF)
          });
        }
      }
    }

    public static void CopyMatrix(List<List<ComplexNumbers>> From, List<List<ComplexNumbers>> To)
    {
      for (int i = 0; i < From.Count; i++)
      {
        for (int j = 0; j < From[i].Count; j++)
        {
          To[i][j] = From[i][j];
        }
      }
    }

    public static double getAlpha()
    {
      return Math.Pow(2 * Math.PI, 2) / (c1 * c2);
    }

    public static void GetNextF()
    {
      if (matrixFNext.Count != 0) CopyMatrix(matrixFNext, matrixF);
      NormalizeF();
      matrixFNext = new List<List<ComplexNumbers>>();
      for (int i = 0; i <= SplitNumberForIntegral; i++)
      {
        matrixFNext.Add(new List<ComplexNumbers>());
        for (int j = 0; j <= SplitNumberForIntegral; j++)
        {
          matrixFNext[i].Add(new ComplexNumbers(1.0 / (2 * Math.Pow(getAlpha(), 2)), 0) * CalculateIntegral(ksi1[i], ksi2[j]));
        }
      }
    }

    public static ComplexNumbers GetF(int i, int j)
    {
      return matrixF[i][j];
    }

    public static ComplexNumbers GetValueUnerIntegralFunction(int i, int j, double Ksi1, double Ksi2)
    {
      double integralKsi1 = ksi1[i];
      double integralKsi2 = ksi2[j];
      return P * GetK(integralKsi1, integralKsi2, Ksi1, Ksi2) * GetF(i, j);
    }

    public static void NormalizeF()
    {
      for (int i = 0; i < matrixF.Count; i++)
      {
        for (int j = 0; j < matrixF[i].Count; j++)
        {
          matrixF[i][j].Re = Math.Abs(matrixF[i][j].Re);
        }
      }

      ComplexNumbers maxF = new ComplexNumbers(matrixF[0][0]);
      for (int i = 0; i < matrixF.Count; i++)
      {
        for (int j = 0; j < matrixF[i].Count; j++)
        {
          if (matrixF[i][j].Re > maxF.Re) maxF.Re = matrixF[i][j].Re;
        }
      }

      for (int i = 0; i < matrixF.Count; i++)
      {
        for (int j = 0; j < matrixF[i].Count; j++)
        {
          matrixF[i][j].Re /= maxF.Re;

        }
      }

    }

    public static ComplexNumbers CalculateIntegral(double Ksi1, double Ksi2)
    {
      //reshitka
      double a = -1, b = 1, c = -1, d = 1;

      double Hx = (b - a) / (2 * N);
      double Hy = (d - c) / (2 * M);
      ComplexNumbers I = new ComplexNumbers(Hx * Hy / 9.0, 0);
      ComplexNumbers sum = new ComplexNumbers();

      for (int i = 0; i < SplitNumberForIntegral / 2; i++)
      {
        for (int j = 0; j < SplitNumberForIntegral / 2; j++)
        {
          sum += GetValueUnerIntegralFunction(2 * i, 2 * j, Ksi1, Ksi2) + GetValueUnerIntegralFunction(2 * i + 2, 2 * j, Ksi1, Ksi2) +
              GetValueUnerIntegralFunction(2 * i, 2 * j + 2, Ksi1, Ksi2) + GetValueUnerIntegralFunction(2 * i + 2, 2 * j + 2, Ksi1, Ksi2) +
              4 * GetValueUnerIntegralFunction(2 * i + 1, 2 * j, Ksi1, Ksi2) + 4 * GetValueUnerIntegralFunction(2 * i, 2 * j + 1, Ksi1, Ksi2) +
              4 * GetValueUnerIntegralFunction(2 * i + 2, 2 * j + 1, Ksi1, Ksi2) + 4 * GetValueUnerIntegralFunction(2 * i + 1, 2 * j + 2, Ksi1, Ksi2) +
              16 * GetValueUnerIntegralFunction(2 * i + 1, 2 * j + 1, Ksi1, Ksi2);
        }
      }

      return I * sum;
    }

    public static bool checkForСonvergence(List<List<ComplexNumbers>> FirstList, List<List<ComplexNumbers>> SecondList)
    {
      bool flag = true;

      for (int n = 0; n <= 10; ++n)
      {
        for (int m = 0; m <= 10; ++m)
        {
          if ((FirstList[n][m] - SecondList[n][m]).Module() > eps)
            flag = false;
        }
      }
      return flag;
    }

    public static List<List<ComplexNumbers>> Inm = new List<List<ComplexNumbers>>();

    //find Inm
    ///////////////////////////////////////////////////////////////////////////
    public static ComplexNumbers GetValueUnerIntegralFunctionI(int i, int j, int n, int m)
    {
      double integralKsi1 = ksi1[i];
      double integralKsi2 = ksi2[j];
      return P * (new ComplexNumbers(Math.Cos(c1 * n * integralKsi1 + c2 * m * integralKsi2), -1 * Math.Sin(c1 * n * integralKsi1 + c2 * m * integralKsi2))) * GetF(i, j);
    }

    public static ComplexNumbers CalculateIntegralI(int n, int m)
    {
      //reshitka
      double a = -1, b = 1, c = -1, d = 1;

      double Hx = (b - a) / (2 * N);
      double Hy = (d - c) / (2 * M);
      ComplexNumbers I = new ComplexNumbers(Hx * Hy / 9.0, 0);
      ComplexNumbers sum = new ComplexNumbers();

      for (int i = 0; i < SplitNumberForIntegral / 2; i++)
      {
        for (int j = 0; j < SplitNumberForIntegral / 2; j++)
        {
          sum += GetValueUnerIntegralFunctionI(2 * i, 2 * j, n, m) + GetValueUnerIntegralFunctionI(2 * i + 2, 2 * j, n, m) +
              GetValueUnerIntegralFunctionI(2 * i, 2 * j + 2, n, m) + GetValueUnerIntegralFunctionI(2 * i + 2, 2 * j + 2, n, m) +
              4 * GetValueUnerIntegralFunctionI(2 * i + 1, 2 * j, n, m) + 4 * GetValueUnerIntegralFunctionI(2 * i, 2 * j + 1, n, m) +
              4 * GetValueUnerIntegralFunctionI(2 * i + 2, 2 * j + 1, n, m) + 4 * GetValueUnerIntegralFunctionI(2 * i + 1, 2 * j + 2, n, m) +
              16 * GetValueUnerIntegralFunctionI(2 * i + 1, 2 * j + 1, n, m);
        }
      }

      return I * sum;
    }


    public static void NormalizeI()
    {
      for (int i = 0; i < Inm.Count; i++)
      {
        for (int j = 0; j < Inm[i].Count; j++)
        {
          Inm[i][j].Re = Math.Abs(Inm[i][j].Re);
        }
      }

      ComplexNumbers maxI = new ComplexNumbers(Inm[0][0]);
      for (int i = 0; i < Inm.Count; i++)
      {
        for (int j = 0; j < Inm[i].Count; j++)
        {
          if (Inm[i][j].Re > maxI.Re) maxI.Re = Inm[i][j].Re;
        }
      }

      for (int i = 0; i < Inm.Count; i++)
      {
        for (int j = 0; j < Inm[i].Count; j++)
        {
          Inm[i][j].Re /= maxI.Re;

        }
      }
    }

    public static AntennasRadiationPatternProblemResult Calculate(Problem problem)
    {
      M = problem.M1;
      N = problem.M2;
      c1 = problem.C1;
      c2 = problem.C2;
      eps = problem.Eps;
      Inm.Clear();
      matrixF.Clear();
      matrixFNext.Clear();
      /////////////////////////////////////////////////////////////////////////////////////////////////////////////
      Splitting();
      InitializeF();
      GetNextF();
      int ci = 0;
      while (!checkForСonvergence(matrixF, matrixFNext))
      {
        ci++;
        GetNextF();
        if (ci == 10)
        {
          break;
        }
      }


      //find Inm
      ///////////////////////////////////////////////////////////////////////////
      for (int n = 0; n <= 2 * N + 1; n++)
      {
        Inm.Add(new List<ComplexNumbers>());
        for (int m = 0; m <= 2 * M + 1; m++)
        {
          Inm[n].Add(CalculateIntegralI(n - N, m - M));
        }
      }
      NormalizeI();

      ////////////////////////////////////////////////////////////////////////////////////////////////////////////

      double[][] arF = new double[SplitNumberForIntegral + 1][];
      for (int i = 0; i <= SplitNumberForIntegral; i++)
      {
        arF[i] = new double[SplitNumberForIntegral + 1];
      }

      for (int i = 0; i <= SplitNumberForIntegral; i++)
        for (int j = 0; j <= SplitNumberForIntegral; j++)
          arF[i][j] = matrixF[i][j].Re;

      double[][] arI = new double[2 * N + 1][];
      for (int i = 0; i < 2 * N + 1; i++)
      {
        arI[i] = new double[2 * M + 1];
      }

      double[] Ix = new double[2 * N + 1];
      double[] Iy = new double[2 * M + 1];
      for (int i = 0; i < 2 * N + 1; i++)
      {
        Ix[i] = i - N;
        for (int j = 0; j < 2 * M + 1; j++)
        {
          arI[i][j] = Inm[i][j].Re;
        }
      }

      for (int i = 0; i < 2 * M + 1; i++)
      {
        Iy[i] = i - M;
      }

      return new AntennasRadiationPatternProblemResult
      {
        F = arF,
        Fx = ksi1,
        Fy = ksi2,
        Ix = Ix,
        Iy = Iy,
        I = arI
      };

    }
  }
}
