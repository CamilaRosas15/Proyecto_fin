using MyPlayList.Core;
using System.Collections.Generic;
using System.Linq;

namespace MyPlayList.Data
{
    public class InMemoryCancionesData : ICancionesData
    {
        private readonly List<Cancion> canciones;

        public InMemoryCancionesData()
        {
            canciones = new List<Cancion>()
            {
                new Cancion { Id = 1, Title = "hello", ArtistName = "Adele", Duration = 5, genero = TipoDeGenero.Pop },
                new Cancion { Id = 2, Title = "Tarot", ArtistName = "Bad Bunny", Duration = 3, genero = TipoDeGenero.Latino },
                new Cancion { Id = 3, Title = "Bachata", ArtistName = "Manuel Turizo", Duration = 4.20, genero = TipoDeGenero.Bachata },
                new Cancion { Id = 4, Title = "Shape of You", ArtistName = "Ed Sheeran", Duration = 4.23, genero = TipoDeGenero.Pop },
                new Cancion { Id = 5, Title = "Dákiti", ArtistName = "Bad Bunny, Jhay Cortez", Duration = 3.25, genero = TipoDeGenero.Latino },
                new Cancion { Id = 6, Title = "Te Boté", ArtistName = "Nio García, Darell, Ozuna", Duration = 4.50, genero = TipoDeGenero.Reggaeton },
                new Cancion { Id = 7, Title = "Vivir Mi Vida", ArtistName = "Marc Anthony", Duration = 4.15, genero = TipoDeGenero.Salsa },
                new Cancion { Id = 8, Title = "Bohemian Rhapsody", ArtistName = "Queen", Duration = 5.55, genero = TipoDeGenero.Rock },
                new Cancion { Id = 9, Title = "La Modelo", ArtistName = "Ozuna, Cardi B", Duration = 4.15, genero = TipoDeGenero.Latino },
                new Cancion { Id = 10, Title = "Dance Monkey", ArtistName = "Tones and I", Duration = 3.30, genero = TipoDeGenero.Pop },

            };
        }

        public IEnumerable<Cancion> GetAll()
        {
            return canciones.OrderBy(s => s.Title);
        }

        public Cancion GetById(int id)
        {
            //return canciones.Find(s => s.Id == id);
            return canciones.SingleOrDefault(s => s.Id == id);
        }

        public Cancion Update(Cancion updateCancion)
        {
            var cancion = canciones.Find(s => s.Id == updateCancion.Id);
            //Cancion cancion = canciones.SingleOrDefault(s => s.Id == updateCancion.Id);
            //Console.WriteLine("original");
            //Console.WriteLine(cancion.genero);
            
            //Console.WriteLine("nuevo");
            //Console.WriteLine(updateCancion.genero);

            if (cancion != null)
            {
                cancion.Title = updateCancion.Title;
                cancion.ArtistName = updateCancion.ArtistName;
                cancion.Duration = updateCancion.Duration;
                cancion.genero = updateCancion.genero;
            }
            else//
            {
                // Manejar el caso cuando no se encuentra la canción
                throw new InvalidOperationException($"No se encontró ninguna canción con Id {updateCancion.Id}");
                // O puedes elegir devolver null o realizar otra lógica según tus necesidades
            }
            return cancion;
        }
        /*Princial
        public Cancion Add(Cancion newCancion)
        {
            canciones.Add(newCancion);
            newCancion.Id = canciones.Max(s => s.Id) + 1;
            return newCancion;
        }*/

        public Cancion Add(Cancion newCancion)
        {
            // Asignar un nuevo ID de manera segura
            newCancion.Id = canciones.Count > 0 ? canciones.Max(s => s.Id) + 1 : 1;

            canciones.Add(newCancion);

            // Devolver la canción recién agregada
            return newCancion;
        }


        public IEnumerable<Cancion> GetCancionsByName(string name)
        {
            return from s in canciones
                   where string.IsNullOrEmpty(name) || s.Title.StartsWith(name)
                   orderby s.Title
                   select s;
        }
        /*principal
        public void Delete(int id)
        {
            canciones.RemoveAll(match:x => x.Id == id);
        }*/
        public void Delete(int id)
        {
            var cancion = canciones.SingleOrDefault(s => s.Id == id);

            if (cancion != null)
            {
                canciones.Remove(cancion);
            }
            else
            {
                // Manejar el caso cuando no se encuentra la canción
                throw new InvalidOperationException($"No se encontró ninguna canción con Id {id}");
            }
        }
        public int Commit()
        {
            return canciones.Count;  // Actualizado para devolver la cantidad total de canciones
            //return 0;
        }
    }
}
