using System.Text;
using Coursework.Services.Abstract;

namespace Coursework.Services.Concrete
{
  public class EncryptionService: IEncryptionService
  {
    public string EncryptPassword(string password)
    {
      var crypt = new System.Security.Cryptography.SHA256Managed();
      var hash = new StringBuilder();
      byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));
      foreach (var theByte in crypto)
      {
        hash.Append(theByte.ToString("x2"));
      }
      return hash.ToString();
    }
  }
}