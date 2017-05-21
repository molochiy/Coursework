using AutoMapper;
using Coursework.Entities.TypeMapping.Abstract;

namespace Coursework.Entities.TypeMapping.Concrete
{
  public class AutoMapperAdapter: IAutoMapper
  {
    public T Map<T>(object objectToMap)
    {
      return Mapper.Map<T>(objectToMap);
    }
  }
}