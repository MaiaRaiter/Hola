using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace RedPe.Models
{
 
    public class Reseña
    {
        private int _idReseña;
        private string _nombreDelUsuario;
         private string _titulo;
        private int _cantLikes;
        private string _contenido;
         private string _foto;
         
         private int _idPelicula;
        

        public Reseña( int pIdReseña, string pNombreDelUsuario, string pTitulo, int pCantLikes ,string pContenido, string pFoto,int pIdPelicula)
        {
         
            _idReseña = pIdReseña;
            _nombreDelUsuario = pNombreDelUsuario;
            _titulo=pTitulo;
            _cantLikes=pCantLikes;
            _contenido=pContenido;
            _foto=pFoto;
            _idPelicula=pIdPelicula;
        }

        public Reseña()
        {
            _idReseña = 0;
            _nombreDelUsuario = "";
            _titulo="";
            _cantLikes=0;
            _contenido="";
            _foto="";
            _idPelicula=0;

        }



        public int IdReseña
        {
        
          get {return _idReseña;}
          set {_idReseña=value;}

        }
        public string NombreDelUsuario
        {
        
          get {return _nombreDelUsuario;}
          set {_nombreDelUsuario=value;}

        }
         public string Titulo
        {
        
          get {return _titulo;}
          set {_titulo=value;}

        }
        public int CantLikes
        {
        
          get {return _cantLikes;}
          set {_cantLikes=value;}

        }
          public string Contenido
        {
        
          get {return _contenido;}
          set {_contenido=value;}

        }
          public string Foto
        {
        
          get {return _foto;}
          set {_foto=value;}

        }

         public int IdPelicula
        {
        
          get {return _idPelicula;}
          set {_idPelicula=value;}

        }
       
    }
}