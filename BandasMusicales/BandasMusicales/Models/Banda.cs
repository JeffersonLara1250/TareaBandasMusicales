using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BandasMusicales.Models
{
    public class Banda
    {
        [Key]
        public int BandaId { get; set; }

        [Display(Name ="Nombre")]
        public string BandaName { get; set; }
    }
}
