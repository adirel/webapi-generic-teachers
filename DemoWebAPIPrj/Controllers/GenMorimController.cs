using DemoWebAPIPrj.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace DemoWebAPIPrj.Controllers
{
    public class GenMorimController : ApiController
    {
        private EntitiesModel db = new EntitiesModel();
        private List< MISROT> misrot = new List<MISROT>();
        public List<MISROT> Misrot { get => misrot; set => misrot = value; }

        //[HttpGet]
        //public GenericMorim GetMoreAndMisrot(int id)
        //{
        //    GenericMorim gm = null;
        //    MORIM more = db.MORIM.Find(id);
        //    List<MISROT> mis = new List<MISROT>();
        //    if (more == null)
        //    {
        //        return null;
        //    }

        //    using (EntitiesModel ctx = new EntitiesModel())
        //    {


        //        var resMisrot = from c in ctx.MISROT_LEMORIM where c.ZEHUT == more.ZEHUT
        //                  select c;


        //        //var article = db.MISROT.Where(b => b.KOD_MISRA.Equals(resMisrot)).FirstOrDefault();
        //        foreach (MISROT m in ctx.MISROT)
        //        {
        //            if (m.KOD_MISRA.Equals(resMisrot))
        //            {
        //                mis.Add(m);
        //            }
        //        }
        //        //foreach (MISROT m in ctx.MISROT.Where(u => u }.Contains(u.KOD_MISRA)))
        //        //{
        //        //    //Do stuff on each selected user;
        //        //}
        //        //for
        //        //var MisrotMore = from m in ctx.MISROT where m.KOD_MISRA in(resMisrot)


        //    }
        //    MISROT a = new MISROT();
        //    a.KOD_MISRA = 1;
        //    a.SHEM_MISRA = "koko";
        //    mis.Add(a);
        //    gm = new GenericMorim(more, mis);
        //    //MISROT misra = db.MISROT.Find( db.MISROT_LEMORIM.Find(more.ZEHUT));
        //    var ggg = gm;

        //    return (gm);
        //}

        [HttpGet]
        public IEnumerable<MISROT> getMisrotById(int id)
        {
            var a = from res in db.MISROT_LEMORIM where res.ZEHUT == id select res;
            if (a == null)
            {
                return null;
            }
            foreach(MISROT_LEMORIM m in a)
            {
                MISROT tmp = db.MISROT.Find(m.KOD_MISRA);
                Misrot.Add(tmp);
            }

            return Misrot;
        }
    }
}
