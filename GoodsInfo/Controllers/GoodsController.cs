using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GoodsInfo.Controllers
{
    public class GoodsController : ApiController
    {
        Models.madukaDbEntities db = new Models.madukaDbEntities();

        /// <summary>
        /// 取得商品的資訊
        /// </summary>
        /// <param name="GoodsName"></param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetGoods")]
        public Models.ResponseModels.GetGoodsResult GetGoods(string GoodsName)
        {
            Models.ResponseModels.GetGoodsResult result = new Models.ResponseModels.GetGoodsResult();

            result = db.NetConf_Goods.Where(x => x.GoodsName == GoodsName)
                   .Select(c => new Models.ResponseModels.GetGoodsResult()
                   {
                       GoodsCode = c.GoodsCode,
                       GoodsId = c.GoodsId,
                       GoodsName = c.GoodsName,
                       Price = c.Price,
                   })
                   .FirstOrDefault();

            return result;
        }
    }
}
