using System;
using MahdaviEshop.Framework.Entities;

namespace MahdaviEshop.Framework.ServiceProvider.Jwt
{
    public interface IJwtService
    {
        string Generate(User user);
    }
}

