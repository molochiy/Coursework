using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Coursework.Entities.ServicesEntities;
using Coursework.Repositories.Abstract;
using Coursework.Services.Abstract;
using Coursework.Services.Algorithms;
using Problem = Coursework.Entities.DatabaseEntities.Problem;
using ProblemResult = Coursework.Entities.DatabaseEntities.ProblemResult;

namespace Coursework.Services.Concrete
{
  public class SolverService : ServiceBase, ISolverService
  {
    private readonly List<Task> _tasks;
    private readonly object _lockRero = new object();
    private readonly object _lockTasks = new object();

    public SolverService(IRepository repository) : base(repository)
    {
      _tasks = new List<Task>();
    }

    public void StartSolver()
    {
      var solverThread = new Thread(SolverProcess);
      solverThread.Start();
    }

    void SolverProcess()
    {
      while (true)
      {
        lock (_lockTasks)
        {
          while (_tasks.Count < 4)
          {
            var problem = GetProblemFromDb();

            if (problem != null)
            {
              var task = GetTask(problem);
              task.ContinueWith(antecedent => DeleteFinishedTasks());
              _tasks.Add(task);
              task.Start();

              lock (_lockRero)
              {
                problem.StateId = 2;
                _repository.Update(problem);
              }
            }
            else
            {
              break;
            }
          }
        }

        Thread.Sleep(10000);
      }
    }

    private Task GetTask(Problem problem)
    {
      switch (problem.TypeId)
      {
        case 1:
          return new Task(() =>
          {
            var antennasRadiationPatternProblemResult = AntennasRadiationPatternProblemAlgorithmType1.Calculate(problem);
            var resultXml = SerializationService.ToXmlString(antennasRadiationPatternProblemResult);
            var result = new ProblemResult { Result = resultXml };
            lock (_lockRero)
            {
              var insertedResult = _repository.Insert(result);
              problem.ResultId = insertedResult.Id;
              problem.StateId = 3;
              _repository.Update(problem);
            }
          });
        case 2:
          return new Task(() =>
          {
            var antennasRadiationPatternProblemResult = AntennasRadiationPatternProblemAlgorithmType2.Calculate(problem);
            var resultXml = SerializationService.ToXmlString(antennasRadiationPatternProblemResult);
            var result = new ProblemResult { Result = resultXml };
            lock (_lockRero)
            {
              var insertedResult = _repository.Insert(result);
              problem.ResultId = insertedResult.Id;
              problem.StateId = 3;
              _repository.Update(problem);
            }
          });
        case 3:
          return new Task(() =>
          {
            var branchingPointsProblem = BranchingPointsProblem1.Calculate(problem);
            var resultXml = SerializationService.ToXmlString(branchingPointsProblem);
            var result = new ProblemResult { Result = resultXml };
            lock (_lockRero)
            {
              var insertedResult = _repository.Insert(result);
              problem.ResultId = insertedResult.Id;
              problem.StateId = 3;
              _repository.Update(problem);
            }
          });
        default:
          return new Task(() =>
          {
            var branchingPointsProblem = BranchingPointsProblem1.Calculate(problem);
            var resultXml = SerializationService.ToXmlString(branchingPointsProblem);
            var result = new ProblemResult { Result = resultXml };
            lock (_lockRero)
            {
              var insertedResult = _repository.Insert(result);
              problem.ResultId = insertedResult.Id;
              problem.StateId = 3;
              _repository.Update(problem);
            }
          });
      }
    }

    private void DeleteFinishedTasks()
    {
      lock (_lockTasks)
      {
        _tasks.RemoveAll(t => t.IsCompleted || t.IsCanceled || t.IsFaulted);
      }
    }

    private Problem GetProblemFromDb()
    {
      lock (_lockRero)
      {
        var proplemEntities = _repository.Get<Problem>(p => p.StateId == 1);
        proplemEntities.Sort((p1, p2) => p1.CreationDate.CompareTo(p2.CreationDate));

        return proplemEntities.FirstOrDefault();
      }
    }

    
  }
}
