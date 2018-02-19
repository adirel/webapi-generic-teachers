using DemoWebAPIPrj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace DemoWebAPIPrj.Controllers
{
    public class GenericMorimController : ApiController
    {

        public GenericMorim genericMorim = new GenericMorim();
        private EntitiesModel db = new EntitiesModel();
        private List<MISROT> misrot = new List<MISROT>();
        private List<ResponseModel> obj;

        public List<MISROT> Misrot { get => misrot; set => misrot = value; }


        [HttpGet]
        public IEnumerable<ResponseModel> GetMore(int id)
        {
            MORIM more = db.MORIM.Find(id);
            if (more == null)
            {
                return null;
            }
            //var a = from res in db.MISROT_LEMORIM where res.ZEHUT == id select res;
            var codeMisra = from res in db.MISROT_LEMORIM where res.ZEHUT == id select res;

            foreach (MISROT_LEMORIM mis in codeMisra)
            {
                try
                {
                    Misrot.Add(db.MISROT.Find(mis.KOD_MISRA));
                }
                catch (Exception e)
                {

                }
            }
            genericMorim = new GenericMorim(more, Misrot);
            ResponseModel _objResponseModel = new ResponseModel();
            _objResponseModel.Data = genericMorim;
            _objResponseModel.Status = true;
            _objResponseModel.Message = "Data Received successfully";

            //IEnumerable<ResponseModel> ff = new IEnumerable<ResponseModel>();
            obj = new List<ResponseModel>();
            obj.Add(_objResponseModel);
            return obj.AsEnumerable();
        }

    }
}
