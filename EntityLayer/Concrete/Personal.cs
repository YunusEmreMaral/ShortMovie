using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Personal
	{
        [Key]
        public int PersonalID { get; set; }
        public string PersonalName { get; set; }
        public string Subject  { get; set; }
        public string Content  { get; set; }
        public string Mail  { get; set; }
    }
}
