using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
namespace RedPe.Models
{

    public static class BD
    {
        private static List<Pelicula> _ListadoPelicula= new List<Pelicula>(); 
         private static List<Reseña> _ListadoReseña= new List<Reseña>(); 
         
        

        private static string _connectionString =      @"Server=LAPTOP-N12IUOD8\SQLEXPRESS;DataBase=RedPe;Trusted_Connection=True;";

       public static void  AgregarReseña(Reseña Res) 
        {
        
        string sql = "INSERT INTO Reseñas (NombreDelUsuario,CantLikes,Contenido,Foto,Titulo,IdPelicula) VALUES ( @pNombreDelUsuario,  @pCantLikes, @pContenido, @pFoto, @pTitulo, @pIdPelicula)";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {  
            //crea un nuevo jugador en la base de datos con los valores de jug
            db.Execute(sql, new {  pTitulo = Res.Titulo, pNombreDelUsuario = Res.NombreDelUsuario, pCantLikes = Res.CantLikes, pContenido = Res.Contenido, pFoto = Res.Foto, pIdPelicula = Res.IdPelicula});
        } 
       
        }
       public static List<Pelicula> ListarPeliculas()
        {
            
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Pelicula";
            return db.Query<Pelicula>(sql).ToList();
        
            }   
        }
        public static List<Reseña> ListarReseña()
    {
            
       using (SqlConnection db = new SqlConnection(_connectionString))
       {
        string sql = "SELECT * FROM Reseñas";
        return db.Query<Reseña>(sql).ToList();
       
       }
    }

   
   public static Pelicula VerInfoPelicula(int IdPelicula)
    {
        Pelicula MiPelicula;
       using (SqlConnection db = new SqlConnection(_connectionString))
       {
        string sql = "SELECT * FROM Pelicula WHERE IdPelicula=@pIdPelicula ";
       MiPelicula= db.QueryFirstOrDefault<Pelicula>(sql,new {pIdPelicula=IdPelicula});
       
       }
        return MiPelicula;
    }
  public static List<Reseña> VerInfoReseña(int IdPelicula)
    {
       List<Reseña> ListaReseñas = new List<Reseña>();
       using (SqlConnection db = new SqlConnection(_connectionString))
       {
        string sql = "SELECT * FROM Reseñas WHERE IdPelicula=@pId ";
       ListaReseñas= db.Query<Reseña>(sql, new {pId=IdPelicula}).ToList();
       
       }
        return ListaReseñas;
    }

    public static int EliminarReseña(int IdReseña)
    {
        
        string sql = "DELETE FROM Reseñas WHERE IdReseña = @pIdReseña";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            return db.Execute(sql, new { pIdReseña = IdReseña });
        }
    }

}

}
