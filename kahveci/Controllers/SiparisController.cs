using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace kahveci.Controllers
{
    public class SiparisController:ApiController
    {
        tutkunFastFoodEntities _ent = new tutkunFastFoodEntities();
        [HttpGet]
        public List<SiparisTip> MasaSiparisleriniGetir(int masaID)
        {
            return _ent.siparis.Where(p => p.masaID == masaID).Select(p => new SiparisTip()
            {
                urunad = p.urun.urunad,
                adet = p.adet,
                toplamFiyat = p.adet * p.urun.urunfiyat,
                personelID = p.personelID,
                masaID = p.masaID,
                siparisID = p.siparisID
                
            }).ToList();
        }
        [HttpPost]
        public List<SiparisTip> YeniSiparisEkle(SiparisTip veri)
        {
            try
            {

                siparis d = new siparis();
                d.masaID = veri.masaID;
                d.personelID = veri.personelID;
                d.urunID = veri.urunID;
                d.adet = veri.adet;
                _ent.siparis.Add(d);
                _ent.SaveChanges();
                return MasaSiparisleriniGetir(veri.masaID);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        [HttpGet]
        public List<SiparisTip> SiparisSil(int siparisID)
        {
            try
            {
                siparis d = _ent.siparis.Find(siparisID);
                int masaid = d.masaID;
                _ent.siparis.Remove(d);
                _ent.SaveChanges();
                return MasaSiparisleriniGetir(masaid);
            }
            catch (Exception ex)
            {
                return null;

            }

        }
    
    }
    public class SiparisTip
    {
        public int siparisID { get; set; }
        public int masaID { get; set; }
        public int urunID { get; set; }
        public string urunad { get; set; }
        public int personelID { get; set; }
        public decimal toplamFiyat { get; set; }
        public int adet { get; set; }
    }
}