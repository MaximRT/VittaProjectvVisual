using client_app.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace client_app.UserSection
{
    public interface IUserService
    {
        Task<List<ListUserOrdersDto>> GetUserOrdersListByIdAsync(string id);
    }
}