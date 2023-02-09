using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreGB.Domain.Entities.Identity;
using WebStoreGB.Domain.ViewModels.Identity;

namespace WebStoreGB.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _UserManager;
        private readonly SignInManager<User> _SignInManager;
        private readonly ILogger<AccountController> _Logger;

        public AccountController(UserManager<User> UserManager, 
            SignInManager<User> SignInManager,
            ILogger<AccountController> Logger)
        {
            _UserManager = UserManager;
            _SignInManager = SignInManager;
            _Logger = Logger; // все записи которые будет вести логгер в журнал будут помечены названием WebStore.Controllers.AccountControllers
        }
        //
        #region Register

        [AllowAnonymous]
        public async Task<IActionResult> IsNameFree(string UserName) // название параметра должно совпадать с названием свойства, потому что скрипт будет отправлять данные с названием этого параметра
        {
            var user = await _UserManager.FindByNameAsync(UserName);
            return Json(user is null ? "true" : $"Пользователь с именем {user.UserName} уже существует");
        }

        [AllowAnonymous]
        public IActionResult Register() => View(new RegisterUserViewModel());

        [HttpPost, ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUserViewModel Model)
        {
            if (!ModelState.IsValid) return View(Model);


            using (_Logger.BeginScope("Регистрация пользователя {0}", Model.UserName))
            {
                var user = new User
                {
                    UserName = Model.UserName,
                };
                _Logger.LogInformation("Регистрация пользователя {0}", user.UserName);
                //_Logger.LogInformation($"Регистрация пользователя {user.UserName}"); // не стоит использовать строковую интерполяцию

                var register_result = await _UserManager.CreateAsync(user, Model.Password);
                if (register_result.Succeeded)
                {
                    _Logger.LogInformation("Регистрация пользователя {0} пройдена успешно", user.UserName);

                    await _UserManager.AddToRoleAsync(user, Role.Users);
                    _Logger.LogInformation("Пользователю {0} присвоена роль {1}", user.UserName, Role.Users);

                    await _SignInManager.SignInAsync(user, false);
                    _Logger.LogInformation("Пользователь {0} вошёл в систему", user.UserName);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in register_result.Errors)
                    ModelState.AddModelError("", error.Description);
                _Logger.LogWarning("Ошибка при регистрации пользователя {0}: {1}", user.UserName,
                    string.Join(", ", register_result.Errors.Select(e => e.Description)));
            }

            return View(Model);
        }
        #endregion

        #region Login

        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl) => View(new LoginViewModel { ReturnUrl = ReturnUrl });

        [HttpPost, ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel Model)
        {
            if (!ModelState.IsValid) return View(Model);

            var login_result = await _SignInManager.PasswordSignInAsync(Model.UserName, 
                Model.Password, Model.RememberMe,false);

            if (login_result.Succeeded)
            {
                _Logger.LogInformation("Пользователь {0} успешно вошёл в систему", Model.UserName);
                return LocalRedirect(Model.ReturnUrl ?? "/");
            }
                
            ModelState.AddModelError("", "Ошибка ввода имени пользоватея или пароля");
            _Logger.LogWarning("Ошибка ввода имени пользователя или пароля при входу {0}", Model.UserName);

            return View(Model);
        }
        #endregion

        public async Task<IActionResult> Logout()
        {
            var user_name = User.Identity!.Name;
            await _SignInManager.SignOutAsync();

            _Logger.LogInformation("Пользователь {0} вышел из системы", user_name);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            _Logger.LogWarning("Пользователю {0} отказано в доступе к uri:{1}"
                ,User.Identity!.Name
                ,HttpContext.Request.Path);
            return View();
        }
    }
}
