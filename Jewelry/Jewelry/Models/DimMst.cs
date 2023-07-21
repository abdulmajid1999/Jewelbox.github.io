using System.ComponentModel.DataAnnotations;

namespace Jewelry.Models
{
    public class DimMst
    {
        [Key]
        public int DimMstId { get; set; }

        [Required]
        public int ItemMstID { get; set; }
        public ItemMst itemMst { get; set; }

        [Required]
        public int DimQltyMstID { get; set; }
        public DimQltyMst dimQltyMst { get; set; }

        [Required]
        public int DimQltySubMstID { get; set; }

        public DimQltySubMst dimQltySubMst { get;set; }

        [Required]
        [Display(Name = "Carat Of Diamond")]
        public int Dim_Crt { get; set; }

        [Required]
        [Display(Name = "Total Pcs Of Diamond In Item")]
        public int Dim_Pcs { get; set; }

        [Required]
        [Display(Name = "Weight Of Each Diamond(Grams)")]
        public int Dim_Gm { get; set; }

        [Required]
        [Display(Name = "Size Of Each Diamond")]

        public int Dim_Size { get; set; }

        [Required]
        [Display(Name = "Rate Of Each Diamond")]
        public int Dim_Rate { get; set; }

        [Required]
        [Display(Name = "Total Amount Of All Diamonds In Item")]
        public int Dim_Amt { get; set; }



    }
}
