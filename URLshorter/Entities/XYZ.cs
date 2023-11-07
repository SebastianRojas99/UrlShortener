using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace URLshorter.Entities
{
    [Table("MisURL")]
    public class XYZ
	{
        [Key]
        public int idURL { get; set; }
        public string? urlOG { get; set; }
        public string? urlShort { get; set; }
        public int VisitCount { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        public XYZ()
		{
            VisitCount = 0;
		}
	}
}
 