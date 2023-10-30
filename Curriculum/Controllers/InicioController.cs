using Curriculum.Datos;
using Curriculum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Curriculum.Controllers
{
    public class InicioController : Controller
    {
        
        private readonly ApplicationDbContext _contexto;

        public InicioController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
            
        }
        [HttpGet]
        public async  Task <IActionResult> Index()
        {
            return View(await _contexto.Usuario.ToListAsync());
        }

        [HttpGet]
        public IActionResult crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Usuario usuario, IFormFile archivo)
        {
            if (ModelState.IsValid)
            {
                if (archivo != null && archivo.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await archivo.CopyToAsync(memoryStream);
                        usuario.ImagenPerfil = memoryStream.ToArray();
                    }
                }

                _contexto.Usuario.Add(usuario);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Usuario = _contexto.Usuario.Find(id);
            if(Usuario== null)
            {
                return NotFound();
            }
            return View(Usuario);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(usuario);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Ver(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Usuario = _contexto.Usuario.Find(id);
            if (Usuario == null)
            {
                return NotFound();
            }
            return View(Usuario);
        }
        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Usuario = _contexto.Usuario.Find(id);
            if (Usuario == null)
            {
                return NotFound();
            }
            return View(Usuario);
        }
        [HttpPost]
        public async Task<IActionResult> eliminar(int? id)
        {
            var Usuario = await _contexto.Usuario.FindAsync(id);
            if (Usuario == null)
            {
                return RedirectToAction(nameof(Index)); // Redirige a la acción Index
            }
            _contexto.Usuario.Remove(Usuario);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}