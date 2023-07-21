using System.ComponentModel.DataAnnotations;

namespace Jewelry.Models
{
    public class Addtoshop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string pName { get; set; }

        public int quantity { get; set; }

        public int price { get; set; }

        public int totalprice { get; set; }

    }
}
