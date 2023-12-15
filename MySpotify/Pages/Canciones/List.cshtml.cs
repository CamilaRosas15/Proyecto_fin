using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MyPlayList.Core;
using MyPlayList.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpotify.Pages.Canciones
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly ICancionesData cancionesData;

        public string? Message { get; set; }
        public IEnumerable<Cancion> Canciones { get; set; }
        [BindProperty(SupportsGet = true)]

        public string SearchTerm { get; set; }
        public ListModel(IConfiguration config, ICancionesData cancionesData)
        {
            this.config = config;
            this.cancionesData = cancionesData;

            // Inicializar la propiedad Canciones para evitar advertencias CS8618
            Canciones = new List<Cancion>();
        }

        public void OnGet()
        {
            Message = config["Message"];
            //string s = SearchTerm;
            //Canciones = cancionesData.GetAll();
            
            Canciones = cancionesData.GetCancionsByName(SearchTerm);
        }

        public IActionResult OnPost(int id) //ojo
        {
            cancionesData.Delete(id);
            cancionesData.Commit();
            return RedirectToPage(pageName: "./List");
        }
    }
}
