using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Director
    {
        [Key]
        public int DirectorID { get; set; }
        public string DirectorNameSurname { get; set; }
        public string DirectorImage { get; set; }

        public List<Movie> Movies { get; set; }

    }
}
