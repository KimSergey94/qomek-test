using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebMVC.Models.DTO;
using WebMVC.Service.IService;

namespace WebMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO loginRequestDTO = new();
            return View(loginRequestDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
        {
            ResponseDTO result = await _authService.LoginAsync(loginRequestDTO);

            if (result != null && result.IsSuccess)
            {
                LoginResponseDTO loginResponseDTO = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(result.Result));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", result.Message);
                return View(loginRequestDTO);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDTO registrationRequestDTO)
        {
            ResponseDTO result = await _authService.RegisterAsync(registrationRequestDTO);

            if(result != null && result.IsSuccess)
            {
                TempData["success"] = "Registration successful";
                return RedirectToAction(nameof(Login));
            }
            return View(registrationRequestDTO);
        }

        [HttpGet]
        public IActionResult Logout()
        {

            return View();
        }
    }
}
