using System;
using System.Linq;
using System.Security.Principal;
using Coursework.Entities.DatabaseEntities;
using Coursework.Entities.ServicesEntities;
using Coursework.Entities.TypeMapping.Abstract;
using Coursework.Repositories.Abstract;
using Coursework.Services.Abstract;

namespace Coursework.Services.Concrete
{
  public class MembershipService : ServiceBase, IMembershipService
  {
    private readonly IEncryptionService _encryptionService;
    private readonly IAutoMapper _mapper;

    public MembershipService(IRepository repository, IEncryptionService encryptionService, IAutoMapper mapper) : base(repository)
    {
      _encryptionService = encryptionService;
      _mapper = mapper;
    }

    public MembershipContext ValidateUser(string username, string password)
    {
      var membershipContext = new MembershipContext();

      var existingUser = _repository.GetSingle<Entities.DatabaseEntities.User>(u => u.Username == username, u => u.Roles);

      if (existingUser != null && IsPasswordValid(password, existingUser.HashedPassword))
      {
        membershipContext.User = _mapper.Map<Entities.ServicesEntities.User>(existingUser);

        var identity = new GenericIdentity(existingUser.Username);

        membershipContext.Principal = new GenericPrincipal(identity, existingUser.Roles.Select(r => r.Name).ToArray());
      }

      return membershipContext;
    }

    public Entities.DatabaseEntities.User CreateUser(Entities.ServicesEntities.User user, int[] rolesIds)
    {
      var existingUser = _repository.GetSingle<Entities.DatabaseEntities.User>(u => u.Username == user.Username);

      if (existingUser != null)
      {
        throw new ArgumentException("Username is already in use");
      }

      var userEntity = new Entities.DatabaseEntities.User
      {
        Username = user.Username,
        Email = user.Email,
        HashedPassword = _encryptionService.EncryptPassword(user.Password)
      };

      if (rolesIds != null && rolesIds.Length > 0)
      {
        foreach (var roleId in rolesIds)
        {
          AddUserToRole(userEntity, roleId);
        }
      }

      var createdUser = _repository.Insert(userEntity);

      return createdUser;
    }

    #region Helpers

    private void AddUserToRole(Entities.DatabaseEntities.User user, int roleId)
    {
      var role = _repository.GetSingle<Role>(r => r.Id == roleId);

      if (role == null)
      {
        throw new ArgumentException("Role doesn't exist.");
      }

      user.Roles.Add(role);
    }

    private bool IsPasswordValid(string password, string hashedPassword)
    {
      return string.Equals(_encryptionService.EncryptPassword(password), hashedPassword);
    }

    #endregion
  }
}