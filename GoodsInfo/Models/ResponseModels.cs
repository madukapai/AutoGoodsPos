using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodsInfo.Models
{
    public class ResponseModels
    {
        public class GetGoodsResult
        {
            public int GoodsId { get; set; }
            public string GoodsCode { get; set; }
            public string GoodsName { get; set; }
            public decimal Price { get; set; }
        }
    }
}