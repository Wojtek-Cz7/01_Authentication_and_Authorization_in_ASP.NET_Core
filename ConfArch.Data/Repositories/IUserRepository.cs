using ConfArch.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfArch.Data.Repositories
{
    public interface IUserRepository
    {
        User GetByUsernameAndPassword(string username, string password);
        User GetByGoogleId(string googleId);
    }
}
