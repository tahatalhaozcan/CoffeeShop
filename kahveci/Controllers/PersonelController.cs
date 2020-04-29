using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace kahveci.Controllers
{
    public class PersonelController:ApiController
    {
        tutkunFastFoodEntities _ent = new tutkunFastFoodEntities();
        [HttpGet]
        public List<PersonelTip> PersonelleriGetir()
        {
            return _ent.personel.Select(a => new PersonelTip()
            {
                personelID = a.personelID,
                padsoyad = a.padsoyad,
                pkad = a.pkad,
                psfire = a.psfire
            }).ToList();
        }
        [HttpPost]
        public List<PersonelTip> YeniPersonel( personel kayit)
        {
            try
            {
                personel d = new personel();
                d.personelID = kayit.personelID;
                d.padsoyad = kayit.padsoyad;
                d.pkad = kayit.pkad;
                d.psfire = kayit.psfire;
                
                _ent.personel.Add(d);
                _ent.SaveChanges();
                return PersonelleriGetir();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet]
        public List<PersonelTip> PersonelSil (int personelID)
        {
            personel cikis = _ent.personel.Find(personelID);
            _ent.personel.Remove(cikis);
            _ent.SaveChanges();
            return PersonelleriGetir();

        }
        [HttpGet]
        public int PersonelGiris(string pka, string psifre)
        {
            personel d = _ent.personel.FirstOrDefault(p => p.pkad == pka && p.psfire == psifre);
            if (d == null)
            {
                return 0;
            }
            else
                return d.personelID;
        }

    }
    public class PersonelTip
    {
        public int personelID { get; set; }
        public string padsoyad { get; set; }
        public string pkad { get; set; }
        public string psfire { get; set; }
    }
}