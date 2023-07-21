using System.ComponentModel.DataAnnotations;

namespace Jewelry.Models
{
    public class ItemMst
    {
        [Key] 
        public int ItemMstID { get; set; }

        [Required]
        [Display(Name = "Pairs Of Product")]
        public int Pairs { get; set; }

        [Required]
        [Display(Name = "ID Of Particular Brand")]
        public int BrandMstID { get; set; }
        public BrandMst brandMst { get; set; }

        [Required]
        [Display(Name = "Available Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "ID Of Category")]
        public int CatMstId { get; set; }
        public CatMst catMst { get; set; }

        [Required]
        [Display(Name = "Quality Of Product")]
        public string Prod_Quality { get; set; }

        [Required]
        [Display(Name = "ID Of Certification")]
        public int CertifyMstID { get; set; }
        public CertifyMst certifyMst { get; set; }

        [Required]
        [Display(Name = "Product ID")]
        public int ProdMstID { get; set; }
        public ProdMst prodMst { get; set; }

        [Required]
        [Display(Name = "Cart of Gold")]
        public int GoldKrtMstID { get; set; }
        public GoldKrtMst goldKrtMst { get; set; }

        [Required]
        [Display(Name = "Weight Of Gold")]
        public int Gold_Wt { get; set; }

        [Required]
        [Display(Name = "Weight Of Stone")]
        public int Stone_Wt { get; set; }

        [Required]
        [Display(Name = "Net Gold")]
        public int Net_Gold { get; set; }

        [Required]
        [Display(Name = "Wastage In Percentage")]
        public int Wstg_Per { get; set; }

        [Required]
        [Display(Name = "Wastage")]
        public int Wstg { get; set; }

        [Required]
        [Display(Name = "Total Gross Weight")]
        public int Tot_Gross_Wt { get; set; }

        [Required]
        [Display(Name = "Rate Of Gold")]
        public int Gold_Rate { get; set; }

        [Required]
        [Display(Name = "Amount Of Gold In Item")]
        public int Gold_Amt { get; set; }

        [Required]
        [Display(Name = "Gold Making Charges")]
        public int Gold_Making { get; set; }

        [Required]
        [Display(Name = "Stone Making Charges")]
        public int Stone_Making { get; set; }

        [Required]
        [Display(Name = "Other Making Charges")]
        public int Other_Making { get; set; }

        [Required]
        [Display(Name = "Total Making Charges")]
        public int Tot_Making { get; set; }

        [Required]
        [Display(Name = "MRP Of Product")]
        public int MRP { get; set; }




    }
}
