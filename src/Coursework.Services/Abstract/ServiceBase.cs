using Coursework.Repositories.Abstract;

namespace Coursework.Services.Abstract
{
  public abstract class ServiceBase
  {
    protected readonly IRepository _repository;

    protected ServiceBase(IRepository repository)
    {
      _repository = repository;
    }
  }
}