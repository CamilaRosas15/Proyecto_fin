using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPlayList.Data;
using MyPlayList.Core;

namespace MySpotify.Pages.Canciones
{
    public class DetailModel : PageModel
    {
        private readonly ICancionesData cancionesData;

        [TempData]

        public string? Message { get; set; }
        
        public Cancion cancion { get; set; }
        public DetailModel(ICancionesData cancionesData)
        {
            this.cancionesData = cancionesData;
        }

        //funcion creada a mano no por defecto
        public IActionResult OnGet(int cancionesId)
        {
            //cancion = cancionesData.GetById(2);
            cancion = cancionesData.GetById(cancionesId);
            if (cancion == null)
            {
                return RedirectToPage(pageName:"./NotFound");
            }
            return Page();
        }
    }
}
