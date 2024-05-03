using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string CommentNameSurname { get; set; }
        public string CommentMail { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }

		public int MovieID { get; set; }
        public Movie Movie { get; set; }

	}
}
