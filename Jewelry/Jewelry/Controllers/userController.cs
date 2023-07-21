using Jewelry.Data;
using Jewelry.Migrations;
using Jewelry.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace Jewelry.Controllers
{
    public class userController : Controller
    {
        readonly JewelryContext dbg;
        public userController(JewelryContext dbc)
        {
            dbg = dbc;
        }

        //List<Addtoshop> li = new List<Addtoshop>();
        public IActionResult Index(string kk = null)
        {
            var items = dbg.itemDetails.Include(i => i.catMst).Include(i => i.brandMst).Include(i => i.prodMst).ToList();

            if (!string.IsNullOrEmpty(kk))
            {
                items = items.Where(x => x.catMst.Cat_Name == kk || x.brandMst.Brand_Type == kk || x.prodMst.Prod_Type == kk).ToList();
            }

            var categories = dbg.catMsts.ToList();
            var brands = dbg.brandMsts.ToList();
            var products = dbg.prodMsts.Take(3).ToList(); // Retrieve only the first three products

            ViewBag.Categories = categories;
            ViewBag.Brands = brands;
            ViewBag.Products = products;

            return View(items);
        }



        //public IActionResult shop()
        //{
        //    return View();
        //}
        //public IActionResult shop(string cs = null)
        //{
        //    var p = dbg.itemDetails.Include(i => i.catMst).ToList();
        //    if (!string.IsNullOrEmpty(cs))
        //    {
        //        p = p.Where(x => x.prodName == cs).ToList();
        //    }


        //    return View(p);
        //}

        //public IActionResult shop(string cs = null)
        //{
        //    var items = dbg.itemDetails.Include(i => i.catMst).ToList();

        //    if (!string.IsNullOrEmpty(cs))
        //    {
        //        items = items.Where(x => x.catMst.Cat_Name == cs).ToList();
        //    }

        //    var categories = dbg.catMsts.ToList();

        //    ViewBag.Categories = categories;

        //    return View(items);
        //}

        //public IActionResult shop(string cs = null, string brand = null)
        //{
        //    var items = dbg.itemDetails.Include(i => i.catMst).Include(i => i.brandMst).ToList();

        //    if (!string.IsNullOrEmpty(cs))
        //    {
        //        items = items.Where(x => x.catMst.Cat_Name == cs).ToList();
        //    }

        //    if (!string.IsNullOrEmpty(brand))
        //    {
        //        items = items.Where(x => x.brandMst.Brand_Type == brand).ToList();
        //    }

        //    var categories = dbg.catMsts.ToList();
        //    var brands = dbg.brandMsts.ToList();

        //    ViewBag.Categories = categories;
        //    ViewBag.Brands = brands;

        //    return View(items);


        //}

        //public IActionResult shop(string cs = null )
        //{
        //    var items = dbg.itemDetails.Include(i => i.catMst).Include(i => i.brandMst).ToList();

        //    if (!string.IsNullOrEmpty(cs))
        //    {
        //        items = items.Where(x => x.catMst.Cat_Name == cs || x.brandMst.Brand_Type == cs).ToList();
        //    }


        //    var categories = dbg.catMsts.ToList();
        //    var brands = dbg.brandMsts.ToList();

        //    ViewBag.Categories = categories;
        //    ViewBag.Brands = brands;

        //    return View(items);


        //}


        //public IActionResult shop(string cs = null)
        //{
        //    var items = dbg.itemDetails.Include(i => i.catMst).Include(i => i.brandMst).Include(i => i.prodMst).ToList();

        //    if (!string.IsNullOrEmpty(cs))
        //    {
        //        items = items.Where(x => x.catMst.Cat_Name == cs || x.brandMst.Brand_Type == cs || x.prodMst.Prod_Type == cs).ToList();
        //    }


        //    var categories = dbg.catMsts.ToList();
        //    var brands = dbg.brandMsts.ToList();
        //    var products = dbg.prodMsts.ToList();


        //    ViewBag.Categories = categories;
        //    ViewBag.Brands = brands;
        //    ViewBag.Products = products;

        //    return View(items);


        //}

        public IActionResult shop(string cs = null, string searchQuery = null)
        {
            var items = dbg.itemDetails.Include(i => i.catMst).Include(i => i.brandMst).Include(i => i.prodMst).ToList();

            if (!string.IsNullOrEmpty(cs))
            {
                items = items.Where(x => x.catMst.Cat_Name == cs || x.brandMst.Brand_Type == cs || x.prodMst.Prod_Type == cs).ToList();
            }

            if (!string.IsNullOrEmpty(searchQuery))
            {
                items = items.Where(x => x.catMst.Cat_Name.Contains(searchQuery)).ToList();
            }



            var categories = dbg.catMsts.ToList();
            var brands = dbg.brandMsts.ToList();
            var products = dbg.prodMsts.ToList();


            ViewBag.Categories = categories;
            ViewBag.Brands = brands;
            ViewBag.Products = products;

            return View(items);


        }


        //public async Task<IActionResult> singleshop(int? id)
        //{
        //    if (id == null || dbg.itemDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    var itemDetails = await dbg.itemDetails
        //        .Include(i => i.brandMst)
        //        .Include(i => i.catMst)
        //        .Include(i => i.certifyMst)
        //        .Include(i => i.goldKrtMst)
        //        .Include(i => i.prodMst)
        //        .FirstOrDefaultAsync(m => m.ItemMstID == id);
        //    if (itemDetails == null)
        //    {

        //        return NotFound();
        //    }

        //    return View(itemDetails);


        //}

        //public async Task<IActionResult> singleshop(int? id)
        //{
        //    if (id == null || dbg.itemDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    var itemDetails = await dbg.itemDetails
        //        .Include(i => i.brandMst)
        //        .Include(i => i.catMst)
        //        .Include(i => i.certifyMst)
        //        .Include(i => i.goldKrtMst)
        //        .Include(i => i.prodMst)
        //        .Where(m => m.ItemMstID == id)
        //        .ToListAsync();

        //    if (itemDetails.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return View(itemDetails);
        //}

        // singleshop controller
        public async Task<IActionResult> Singleshop(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemDetails = await dbg.itemDetails
                .Include(i => i.brandMst)
                .Include(i => i.catMst)
                .Include(i => i.certifyMst)
                .Include(i => i.goldKrtMst)
                .Include(i => i.prodMst)
                .FirstOrDefaultAsync(m => m.ItemMstID == id);

            if (itemDetails == null)
            {
                return NotFound();
            }

            return View(itemDetails);
        }



        public IActionResult About()
        {
            return View();

        }


        public IActionResult Contact()
        {
            return View();

        }

        //[HttpPost]
        //public ActionResult SingleShop(int id, int qty)
        //{
        //    ItemDetails item = dbg.itemDetails.FirstOrDefault(x => x.ItemMstID == id);

        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    Addtoshop cartItem = new Addtoshop();


        //    cartItem.Id = id;
        //    cartItem.pName = item.prodName;
        //    cartItem.quantity = qty;
        //    cartItem.price = item.MRP;
        //    cartItem.totalprice = item.MRP * qty;


        //    List<Addtoshop> cartItems = TempData["cart"] as List<Addtoshop>;

        //    if (cartItems == null)
        //    {
        //        cartItems = new List<Addtoshop>();
        //    }

        //    cartItems.Add(cartItem);
        //    TempData["cart"] = cartItems;

        //    TempData.Keep();

        //    return RedirectToAction("shop");
        //}

        //[HttpPost]
        //public ActionResult SingleShop(int id, int qty)
        //{
        //    ItemDetails item = dbg.itemDetails.FirstOrDefault(x => x.ItemMstID == id);

        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    Addtoshop cartItem = new Addtoshop()
        //    {
        //        Id = id,
        //        pName = item.prodName,
        //        quantity = qty,
        //        price = item.MRP,
        //        totalprice = item.MRP * qty
        //    };

        //    List<Addtoshop> cartItems = TempData["cart"] as List<Addtoshop>;

        //    if (cartItems == null)
        //    {
        //        cartItems = new List<Addtoshop>();
        //    }

        //    bool itemExists = false;
        //    foreach (var it in cartItems)
        //    {
        //        if (it.Id == cartItem.Id)
        //        {
        //            it.quantity += cartItem.quantity;
        //            it.price += cartItem.price;
        //            it.totalprice += cartItem.totalprice;
        //            itemExists = true;
        //            break;
        //        }
        //    }

        //    if (!itemExists)
        //    {
        //        cartItems.Add(cartItem);
        //    }

        //    TempData["cart"] = JsonConvert.SerializeObject(cartItems);

        //    return RedirectToAction("Checkout");
        //}

        //[HttpPost]
        //public ActionResult SingleShop(int id, int qty)
        //{
        //    ItemDetails item = dbg.itemDetails.FirstOrDefault(x => x.ItemMstID == id);

        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    Addtoshop cartItem = new Addtoshop()
        //    {
        //        Id = id,
        //        pName = item.prodName,
        //        quantity = qty,
        //        price = item.MRP,
        //        totalprice = item.MRP * qty
        //    };

        //    List<Addtoshop> cartItems = TempData["cart"] as List<Addtoshop>;

        //    if (cartItems == null)
        //    {
        //        cartItems = new List<Addtoshop>();
        //    }
        //    else
        //    {
        //        bool itemExists = false;
        //        for (int i = 0; i < cartItems.Count; i++)
        //        {
        //            if (cartItems[i].Id == cartItem.Id)
        //            {
        //                cartItems[i].quantity += cartItem.quantity;
        //                cartItems[i].price += cartItem.price;
        //                cartItems[i].totalprice += cartItem.totalprice;
        //                itemExists = true;
        //                break;
        //            }
        //        }

        //        if (!itemExists)
        //        {
        //            cartItems.Add(cartItem);
        //        }
        //    }

        //    TempData["cart"] = JsonConvert.SerializeObject(cartItems);

        //    return RedirectToAction("Checkout");
        //    }


        //public ActionResult Checkout()
        //{
        //    string serializedCartItems = TempData["cart"] as string;

        //    if (serializedCartItems != null)
        //    {
        //        List<Addtoshop> cartItems = JsonConvert.DeserializeObject<List<Addtoshop>>(serializedCartItems);
        //        return View(cartItems);
        //    }

        //    return View(new List<Addtoshop>());
        //}


        //public ActionResult Checkout()
        //{
        //    TempData.Keep();
        //    return View();
        //}

        //-----

        //[HttpPost]
        //public ActionResult SingleShop(int id, int qty)
        //{
        //    ItemDetails item = dbg.itemDetails.FirstOrDefault(x => x.ItemMstID == id);

        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    Addtoshop cartItem = new Addtoshop()
        //    {
        //        Id = id,
        //        pName = item.prodName,
        //        quantity = qty,
        //        price = item.MRP,
        //        totalprice = item.MRP * qty
        //    };

        //    List<Addtoshop> cartItems = TempData["cart"] as List<Addtoshop>;

        //    if (cartItems == null)
        //    {
        //        cartItems = new List<Addtoshop>();
        //    }
        //    else
        //    {
        //        List<Addtoshop> li2 = TempData["cart"] as List<Addtoshop>;
        //        int flag = 0;
        //        foreach (var it in li2)
        //        {
        //            if (it.Id == cartItem.Id)
        //            {
        //                it.quantity += cartItem.quantity;
        //                it.price += cartItem.price;
        //                flag = 1;
        //            }
        //        }

        //        if (flag == 0)
        //        {
        //            li2.Add(cartItem);
        //        }
        //        TempData["cart"] = li2;
        //    }

        //    string serializedCartItems = JsonConvert.SerializeObject(cartItems);
        //    TempData["cart"] = serializedCartItems;

        //    TempData.Keep();

        //    return RedirectToAction("Checkout");
        //}



        //[HttpPost]

        //public ActionResult Checkout(string contact,string address)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        List<Addtoshop> li2 = TempData["Cart"] as List<Addtoshop>;
        //        invoice iv = new invoice();

        //        string userId = HttpContext.Session.GetString("uid");
        //        if (!string.IsNullOrEmpty(userId))
        //        {
        //            iv.Id = int.Parse(userId);
        //            iv.invdate = System.DateTime.Now;
        //            iv.bill = (int)TempData["total"];


        //        }


        //    }


        //}






        //public IActionResult shop(string cs = null)
        //{
        //    var p = dbg.itemDetails.ToList();
        //    if (!string.IsNullOrEmpty(cs))
        //    {
        //        p = p.Where(predicate: x => x.prodName == cs).ToList();
        //    }
        //    return View(p);
        //}


    }
    }

