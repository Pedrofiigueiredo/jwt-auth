using System.Collections.Generic;
using System.Linq;
using AuthJWT.Models;

namespace AuthJwt.Repository
{
  public static class UserRepository
  {
    public static User GetUser(string username, string password)
    {
      /* Criação de usuários (para facilitar o processo) */
      var users = new List<User>();
      users.Add(new User { Id = 1, Username = "pedro", Password = "pedro", Role = "manager" });
      users.Add(new User { Id = 2, Username = "daniel", Password = "daniel", Role = "employee" });

      return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == password).FirstOrDefault();
    }
  }
}