using System.ComponentModel.DataAnnotations;

namespace Jewelry.Models
{
    public class StoneMst
    {
        [Key]
        public int StoneMstId { get; set; }


        [Required]
        [Display(Name = "ID Of Stone Quality")]
        public int ItemMstID { get; set; }
        public ItemMst ItemMst { get; set; }

        [Required]
        [Display(Name = "ID Of Stone Quality")]
        public int StoneQltyMstID { get; set; }
        public StoneQltyMst ItemQltyMst { get; set; }

        [Required]
        [Display(Name = "Weight Of Each Stone(Grams)")]
        public int Stone_Gm { get; set; }

        [Required]
        [Display(Name = "Total Pcs Of Stones In Item")]
        public int Stone_Pcs { get; set; }

        [Required]
        [Display(Name = "Carat Of Stone")]
        public int Stone_Crt { get; set; }

        [Required]
        [Display(Name = "Rate Of Each Stone")]
        public int Stone_Rate { get; set; }

        [Required]
        [Display(Name = "Total Amount Of Stones In Item")]
        public int Stone_Amt { get; set; }


    }
}
