using DAL.DAL;
using DAL.Entities.User;
using Interfaces.Repository.BaseRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utilites
{
    ///I fix this in future
    public class AccountLimitMiddleware 
    {
        private readonly RequestDelegate _next;
        private readonly ConcurrentDictionary<string, int> _sessionCounts;


        public AccountLimitMiddleware(RequestDelegate next)
        {
            _next = next;
            _sessionCounts = new ConcurrentDictionary<string, int>();
           
        }


        public async Task InvokeAsync(HttpContext context)
        {
            var userManager = context.RequestServices.GetRequiredService<UserManager<User>>();
            var sub = context.RequestServices.GetRequiredService<IBaseRepository<Subscribe>>();


            var accountId = context.User.Identity.Name;

            if (!string.IsNullOrEmpty(accountId))
            {
                var sessionCount = _sessionCounts.AddOrUpdate(accountId, 1, (key, count) => count + 1);
                var user = await userManager.FindByNameAsync(accountId);
                var subType = sub.GetWithInclude().FirstOrDefault(x => x.Id == user.SubscribeId);
                //var sub = _subs.GetWithInclude("Users").Select(x => x.Users.FirstOrDefault(s => s.Id == user.Id));
                if (sessionCount > subType.MaxUser)
                {
                    context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                    await context.Response.WriteAsync("Maximum number of sessions reached.");
                    return;
                }
            }

            await _next(context);

            if (!string.IsNullOrEmpty(accountId))
            {
                _sessionCounts.AddOrUpdate(accountId, 0, (key, count) => count - 1);
            }
        }
    }
}
