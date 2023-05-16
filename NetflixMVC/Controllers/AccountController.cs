using Alachisoft.NCache.Config.Dom;
using BusinesLogic.ViewModel.Subscribe;
using DAL.DAL;
using DAL.Entities.User;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NetflixMVC.ViewModel;
using Stripe;
using User = DAL.Entities.User.User;

namespace NetflixMVC.Controllers
{
    public class AccountController : Controller
    {
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;
        RoleManager<IdentityRole> _roles;
        ISubscribeService<SubscribeVM> _sub;
        AppDbContext _context;
        IMemoryCache _cache;
        IConfiguration _configuration;
        IBaseRepository<User> _users;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roles, ISubscribeService<BusinesLogic.ViewModel.Subscribe.SubscribeVM> sub, IMemoryCache cache, IConfiguration configuration, AppDbContext context, IBaseRepository<User> users)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roles = roles;
            _sub = sub;
            _cache = cache;
            _configuration = configuration;

            _context = context;
            _users = users;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            ViewBag.Subs = _sub.GetWithId();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM UserVM)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Subs = _sub.GetWithId();
                return View();
            }


            User ExsistUser = await _userManager.FindByNameAsync(UserVM.UserName);

            if (ExsistUser != null)
            {
                ModelState.AddModelError("UserName", "This UserName is exsist");
                ViewBag.Subs = _sub.GetWithId();
                return View();
            }

            User user = new User()
            {
                UserName = UserVM.UserName,
                FirstName = UserVM.FirstName,
                LastName = UserVM.LastName,
                Email = UserVM.Email,
                SubscribeId = UserVM.SubscribeId,
                

            };

            var res = await _userManager.CreateAsync(user, UserVM.Password);
            if (!res.Succeeded)
            {
                foreach (var item in res.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                ViewBag.Subs = _sub.GetWithId();
                return View();
            }

            await _signInManager.SignInAsync(user, true);

            var role = _userManager.AddToRoleAsync(user, "User");
            //if (!role.IsCompletedSuccessfully)
            //{
            //    foreach (var item in role.Result.Errors)
            //    {
            //        ViewBag.Subs = _sub.GetWithId();
            //        ModelState.AddModelError("", item.Description);
            //    }
            //    return View();
            //}

            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogInVM user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var sessionCount = _cache.GetOrCreate("SessionCount", entry =>
            {
                entry.SetSlidingExpiration(TimeSpan.FromMinutes(30));
                return 0;
            });

            User ExsistUser = await _userManager.FindByNameAsync(user.UserNameOdEmail);
            var User = _context.Users.Include(x => x.Subscribe).FirstOrDefault(x => x.UserName == ExsistUser.UserName);


            if (sessionCount >= ExsistUser.Subscribe.MaxUser)
            {
                ModelState.AddModelError(string.Empty, "The maximum number of concurrent users for this account has been reached. Please try again later.");
                return View(user);
            }

            
            if (ExsistUser == null)
            {
                ExsistUser = await _userManager.FindByEmailAsync(user.UserNameOdEmail);
                if (ExsistUser == null)
                {
                    ModelState.AddModelError("", "Login Or Password is wrong");
                    return View();
                }
            }

            var res = await _signInManager.PasswordSignInAsync(ExsistUser, user.Password, user.IsPersistance, true);

            if (!res.Succeeded)
            {
                ModelState.AddModelError("", "Login Or Password is wrong");
                return View();
            }

            _cache.Set("SessionCount", sessionCount + 1, TimeSpan.FromMinutes(30));

            return RedirectToAction(nameof(Index), "Home");
        }


        public IActionResult BuySubscribe()
        {
            ViewBag.Subs = _sub.GetWithId();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BuySubscribe(BuySubscribeVM subscribeVM)
        {
            if (!User.Identity.IsAuthenticated || User.Identity == null)
            {
                return RedirectToAction(nameof(Login));
            }
            if (!ModelState.IsValid)
            {
                ViewBag.Subs = _sub.GetWithId();
                return View(subscribeVM);
            }
            var subs = (List<SubscribeWithIdVM>)_sub.GetWithId();
            StripeConfiguration.ApiKey = _configuration["Stripe:ApiKey"] /*_configuration.GetSection("Stripe").Value*/;

            var chargeService = new ChargeService();
            var options = new ChargeCreateOptions
            {
                Amount = (long)subs.FirstOrDefault(x => x.Id == subscribeVM.SubId).Price * 100,
                Currency = "usd",
                Description = "Charge for test@example.com",
                Source = "tok_visa", // obtained with Stripe.js
            };
            var charge = chargeService.Create(options);

            if (charge.Status == "succeeded")
            {
                var user = await _userManager.GetUserAsync(User);
                user.SubscribeId = subscribeVM.SubId;
                _users.Update(user);
                string res = charge.BalanceTransactionId;
                return RedirectToAction("Index", "Home");
            }




            ViewBag.Subs = _sub.GetWithId();

            return View();
        }

        //public async Task<IActionResult> CreateRoles()
        //{
        //    await _roles.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roles.CreateAsync(new IdentityRole { Name = "User" });
        //    await _roles.CreateAsync(new IdentityRole { Name = "SuperAdmin" });


        //    return View();
        //}

        public async Task<IActionResult> CreateAdmin()
        {
            User user = new User()
            {
                FirstName = "admin",
                UserName = "admin",
                LastName = "admin",
                Email = "admin",
            };

            var res = _userManager.CreateAsync(user, "admin12345");
            if (res.IsCompletedSuccessfully)
            {
                _userManager.AddToRoleAsync(user, "Admin");
            }

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
