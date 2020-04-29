using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace kahveci.Controllers
{
    public class UrunController:ApiController
    {
        tutkunFastFoodEntities _ent = new tutkunFastFoodEntities();
        [HttpGet]
        public List<UrunTip> UrunleriGetir()
        {
            return _ent.urun.Select(p => new UrunTip()
            {
                urunID = p.urunID,
                urunad = p.urunad,
                urunfiyat = p.urunfiyat
            }).ToList();

        }
    }
    public class UrunTip
    {
        public int urunID { get; set; }
        public string urunad { get; set; }
        public decimal urunfiyat { get; set; }
    }
}