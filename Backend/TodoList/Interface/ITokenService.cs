using System;
using TodoList.Models;

namespace TodoList.Interface;

public interface ITokenService
{
    string CreateToken(AppUser appuser);
}
