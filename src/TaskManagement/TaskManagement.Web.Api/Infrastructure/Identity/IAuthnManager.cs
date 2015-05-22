using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TaskManagement.Web.Api.Infrastructure.Identity
{
    public interface IAuthnManager
    {
        string GetCurrentUser { get; }
        int GetCurrentUserId { get; }

        Task<Infrastructure.Identity.AppUser> FindByNameAsync(string name);
        Task<Infrastructure.Identity.AppUser> FindByIdAsync(string id);

    }
}