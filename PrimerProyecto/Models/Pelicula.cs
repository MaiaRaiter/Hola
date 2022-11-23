using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace RedPe.Models
{
 
    public class Pelicula
    {
        private int _idPelicula;
        private string _nombre;
        private string _foto;
        private string _director;
        private int _cantLikes;
        private int _cantViews;
        private string _sintesis;
        private string _trailer;
        

        public Pelicula( int pIdPelicula, string pNombre, string pFoto,string pDirector,string pSintesis,string pTrailer, int pCantLikes, int pCantViews)
        {
         
            _idPelicula = pIdPelicula;
            _nombre = pNombre;
            _foto=pFoto;
            _director=pDirector;
            _sintesis=pSintesis;
            _trailer=pTrailer;
            _cantLikes = pCantLikes;
            _cantViews = pCantViews;
        }

        public Pelicula()
        {
            _idPelicula = 0;
            _nombre = "";
            _foto="";
            _director="";
            _sintesis="";
            _trailer="";
            _cantLikes = 0;
            _cantViews = 0;
        }


        public int CantLikes
         {
        
          get {return _cantLikes;}
          set {_cantLikes=value;}

        }
        public int CantViews
         {
        
          get {return _cantViews;}
          set {_cantViews=value;}

        }
        public int IdPelicula
        {
        
          get {return _idPelicula;}
          set {_idPelicula=value;}

        }
        public string Nombre
        {
        
          get {return _nombre;}
          set {_nombre=value;}

        }
         public string Foto
        {
        
          get {return _foto;}
          set {_foto=value;}

        }
        public string Director
        {
        
          get {return _director;}

          set {_director=value;}

        }
    
        public string Sintesis
        {
        
          get {return _sintesis;}
          set {_sintesis=value;}

        }
        public string Trailer
        {
        
          get {return _trailer;}
          set {_trailer=value;}

        }
       
    }
}