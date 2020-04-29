using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace kahveci.Controllers
{
    public class MasaController:ApiController
    {
        tutkunFastFoodEntities _ent = new tutkunFastFoodEntities();
        [HttpGet]
        public List<MasaTip> MasalariGetir()
        {
            return _ent.masa.Select(p => new MasaTip()
            {
                masaID = p.masaID,
                masaNo = p.masaNo


            }).ToList();
        }

    }
    public class MasaTip
    {
        public int masaID { get; set; }
        public string masaNo { get; set; }
    }
}