using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPlayList.Data;
using MyPlayList.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MySpotify.Pages.Canciones
{
    public class EditModel : PageModel
    {
        private readonly ICancionesData cancionesData;
        private readonly IHtmlHelper htmlHelper;

        public IEnumerable<SelectListItem> Generos { get; set; }

        [BindProperty]
        public Cancion Cancion { get; set; }

        public EditModel(ICancionesData cancionesData, IHtmlHelper htmlHelper)
        {
            this.cancionesData = cancionesData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? cancionesId)
        {
            Generos = htmlHelper.GetEnumSelectList<TipoDeGenero>();

            if (cancionesId.HasValue)
            {
                Cancion = cancionesData.GetById(cancionesId.Value);
            }
            else
            {
                Cancion = new Cancion();
            }

            if (Cancion == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            
            
            if (!ModelState.IsValid)
            {
                Generos = htmlHelper.GetEnumSelectList<TipoDeGenero>();
                return Page();
            }

            if (Cancion.Id > 0)
            {
                Cancion = cancionesData.Update(Cancion);
            }
            else
            {
                cancionesData.Add(Cancion);
            }


            //int updatedCount = cancionesData.Commit();


            //if (updatedCount > 0)
            //{
            //    TempData["Message"] = $"Canción Guardada! ({updatedCount} actualizada(s))";
            //}
            //else
            //{
            //    TempData["Message"] = "No se realizaron cambios.";
            //}

            cancionesData.Commit();
            TempData["Message"] = "Cancion guardada";


            // Redirigir a la página de detalles con el ID de la canción editada
            return RedirectToPage("./Detail", new { cancionesId = Cancion.Id });
        }

    }
}
