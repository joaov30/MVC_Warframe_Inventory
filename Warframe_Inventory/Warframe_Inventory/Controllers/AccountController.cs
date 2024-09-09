using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Warframe_Inventory.Models;

namespace Warframe_Inventory.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                //Copia os dados do RegisterViewModel para o IdentityUser
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                //Armazena os dados do Usuario na tabela AspNetUsers
                var result = await userManager.CreateAsync(user, model.Password);

                //se for criado com sucesso faz o login usando o SignManager e vai redireciona para o Método Action Index
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                //Se tiver errors incluir no ModelState
                //Sera Mostradinho pela tag helper summary na validação
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
    }
}
