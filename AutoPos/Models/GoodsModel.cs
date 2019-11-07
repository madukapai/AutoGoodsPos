using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPos.Models
{
    public class GoodsModel
    {
        public class GoodsInfo
        {
            public int GoodsId { get; set; }
            public string GoodsCode { get; set; }
            public string GoodsName { get; set; }
            public decimal Price { get; set; }
        }
    }
}
