using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlayList.Core
{
    public class Cancion
    {
        public int Id { get; set; }
        [Required, StringLength(80)]

        public string? Title { get; set; }
        [Required, StringLength(255)]

        public string? ArtistName { get; set; }

        public double Duration { get; set; }
        public TipoDeGenero genero { get; set; }

        public bool IsUpdated { get; set; }
    }
}


