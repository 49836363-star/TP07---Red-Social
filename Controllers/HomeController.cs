using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP07.Models;

namespace TP07.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string nombreUsuario, string contraseña)
    {
        Usuario usuario = BD.Login(nombreUsuario, contraseña);

        if (usuario != null)
        {
            HttpContext.Session.SetString("nombreUsuario", usuario.nombreUsuario);
            return RedirectToAction("CrearPublicacion");
        }
        else
        {
            ViewBag.Error = "El usuario o la contraseña son incorrectos.";
            return View("Index");
        }
    }

    public IActionResult CrearPublicacion()
    {
        string nombreUsuario = HttpContext.Session.GetString("nombreUsuario");

        if (string.IsNullOrEmpty(nombreUsuario))
        {
            return RedirectToAction("Index");
        }

        ViewBag.nombreUsuario = nombreUsuario;
        return View();
    }

    [HttpPost]
    public IActionResult CrearPublicacion(Publicacion publicacion)
    {
        string nombreUsuario = HttpContext.Session.GetString("nombreUsuario");

        if (string.IsNullOrEmpty(nombreUsuario))
        {
            return RedirectToAction("Index");
        }

        Usuario usuario = BD.ObtenerUsuario(nombreUsuario);

        if (usuario == null)
        {
            return RedirectToAction("Index");
        }

        if (string.IsNullOrWhiteSpace(publicacion.titulo) ||
            string.IsNullOrWhiteSpace(publicacion.descripcion) ||
            string.IsNullOrWhiteSpace(publicacion.imagen))
        {
            ViewBag.Error = "Todos los campos son obligatorios.";
            return View(publicacion);
        }

        publicacion.IdUsuario = usuario.Id;
        publicacion.fechaPublicacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        BD.CrearPublicacion(publicacion);

        ViewBag.Mensaje = "Publicación creada correctamente.";
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
