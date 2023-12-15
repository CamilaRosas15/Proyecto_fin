using MyPlayList.Core;
using System.Collections.Generic;

namespace MyPlayList.Data
{
    public interface ICancionesData
    {
        IEnumerable<Cancion> GetAll();

        Cancion GetById(int id);

        Cancion Update(Cancion updateCancion);

        Cancion Add(Cancion newCancion);

        IEnumerable<Cancion> GetCancionsByName(string name);

        void Delete(int id);
        int Commit();  // Cambiado para devolver el número de canciones actualizadas
    }
}
