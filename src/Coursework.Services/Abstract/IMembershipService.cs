using Coursework.Entities.ServicesEntities;

namespace Coursework.Services.Abstract
{
  public interface IMembershipService
  {
    MembershipContext ValidateUser(string username, string password);

    Entities.DatabaseEntities.User CreateUser(User user, int[] roles);
    int GetUserIdByLogin(string login);
  }
}