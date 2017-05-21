namespace Coursework.Entities.TypeMapping.Abstract
{
  public interface IAutoMapper
  {
    T Map<T>(object objectToMap);
  }
}