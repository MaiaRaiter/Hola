using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RedPe.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace RedPe.Controllers;

public class HomeController : Controller
{
  private IWebHostEnvironment Environment;

    private readonly ILogger<HomeController> _logger;

    public HomeController(IWebHostEnvironment environment)
    {
        Environment=environment;
    }
    

  public IActionResult Index()
    {
        ViewBag.Lista = BD.ListarPeliculas();
        return View();
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


    public IActionResult VerDetallePelicula(int IdPelicula)
    {
        ViewBag.DatosPelicula = BD.VerInfoPelicula(IdPelicula);
        
        return View("Pelicula");
    }

     public IActionResult AgregarReseña(int IdReseña)
    {
        ViewBag.IdReseña = IdReseña;

        return View("AgregarReseña");
    }
     public IActionResult EliminarReseña(int IdReseña)
    {
       BD.EliminarReseña(IdReseña);
       return RedirectToAction("Pelicula", new {IdReseña=IdReseña});
    }


     //form
    [HttpPost]
    public IActionResult GuardarReseña(int IdReseña, string NombreDelUsuario, string titulo,int CantLikes,string Contenido,IFormFile Foto,int IdPelicula)
     {
        if(Foto.Length>0)
        { 
            string wwwRootLocal= this.Environment.ContentRootPath + @"\wwwroot\" + Foto.FileName;
            using(var stream=System.IO.File.Create(wwwRootLocal))
            {
                Foto.CopyToAsync(stream);
            }
        }

        //crea un nuevo jugador con los datos pasados por parametros EN JUG
        Reseña Res= new Reseña(IdReseña, NombreDelUsuario, titulo,CantLikes,Contenido,(""+ Foto.FileName),IdPelicula);
        //manda al jugador Jug a la base de datos
        BD.AgregarReseña(Res);
         //Redirecciona a VerDetalleEquipo para ver al jugador en la tabla y pasa el IdEquipo
        return RedirectToAction("Pelicula", "Home", new {IdPelicula = IdPelicula});

       
     }

}