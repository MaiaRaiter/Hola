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
         
        

        private static string _connectionString = @"Server=127.0.0.1; 
        Database=RedPe;Trusted_Connection=True;";//CAMBIAR EL NUMERO DE LA COMPU

       public static void  AgregarReseña(Reseña Res)
    {
        
        string sql = "INSERT INTO Reseñas (IdReseña,NombreDelUsuario,CantLikes,Contenido,Foto) VALUES (@pIdReseña, @pNombreDelUsuario,  @pCantLikes, @pContenido, @pFoto)";
        using(SqlConnection db = new SqlConnection(_connectionString))
        {
            //crea un nuevo jugador en la base de datos con los valores de jug
            db.Execute(sql, new {  pIdReseña = Res.IdReseña, pNombreDelUsuario = Res.NombreDelUsuario, pCantLikes = Res.CantLikes, pContenido = Res.Contenido, pFoto = Res.Foto});
        } 
       
    }
       public static List<Pelicula> ListarPeliculas(int IdPelicula)
    {

       using (SqlConnection db = new SqlConnection(_connectionString))
       {
        string sql = "SELECT * FROM Peliculas where IdPelicula=@IdPelicula";
        _ListadoPelicula =db.Query<Pelicula>(sql,new{pidPelicula=IdPelicula}).ToList();
       
       }
       return _ListadoPelicula;

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