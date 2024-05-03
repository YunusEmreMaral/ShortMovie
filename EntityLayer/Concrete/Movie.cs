using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MovieLink { get; set; }
        
        public string MovieDescription { get; set; }
        public int MovieTime { get; set; }
        public DateTime MovieDate { get; set; }
        public string MovieImage { get; set; }
        public  bool MoviePrize { get; set; }
        public  bool MovieAdvice { get; set; }
        public  int MovieLike { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int DirectorID { get; set; }
        public Director Director { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
