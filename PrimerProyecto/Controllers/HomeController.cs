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
 public IActionResult IrEventos()
    {
        
        return View("Eventos");
    }
     public IActionResult IrPopular()
    {
        
        return View("Popular");
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
        ViewBag.DatosReseña = BD.VerInfoReseña(IdPelicula);
        return View("VerInfoPelicula");
    }
    //     public IActionResult VerInfoReseña(int IdReseña)
    // {
    //     ViewBag.ListaR = BD.ListarReseña();
    //     ViewBag.DatosReseña = BD.VerInfoPelicula(IdReseña);
        
    //     return View("VerInfoPelicula");
    // }

     public IActionResult AgregarReseña(int IdPelicula)
    {
        
        ViewBag.IdPelicula = IdPelicula;
        return View("AgregarReseña");
    }
     public IActionResult EliminarReseña(int IdReseña, int IdPelicula)
    {
       BD.EliminarReseña(IdReseña);
       return RedirectToAction("VerDetallePelicula", new {IdPelicula=IdPelicula});
    }


     //form
    [HttpPost]
    public IActionResult GuardarResena(int IdReseña, string NombreDelUsuario, string Titulo,int CantLikes,string Contenido,IFormFile Foto,int IdPelicula)
     {
         
        

        //crea un nuevo jugador con los datos pasados por parametros EN JUG
        Reseña Res= new Reseña(IdReseña, NombreDelUsuario, Titulo,CantLikes,Contenido,(""+ Foto.FileName),IdPelicula);
        //manda al jugador Jug a la base de datos
        BD.AgregarReseña(Res);
         //Redirecciona a VerDetalleEquipo para ver al jugador en la tabla y pasa el IdEquipo
        return RedirectToAction("VerDetallePelicula", "Home", new {IdPelicula = IdPelicula});

       
     }

}