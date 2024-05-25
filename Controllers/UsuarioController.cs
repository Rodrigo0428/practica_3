using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using A.Integration;
using A.Integration.dto;

namespace A.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly ListarUsuarios _listUsers;
        private readonly ListarUnUsuario _unUser;

        public UsuarioController(ILogger<UsuarioController> logger,
        ListarUsuarios listUsers,
        ListarUnUsuario unUser)
        {
            _logger = logger;
            _listUsers = listUsers;
            _unUser = unUser;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Usuario> users = await _listUsers.GetAllUser();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Perfil(int Id)
        {
            Usuario user = await _unUser.GetUser(Id);
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}