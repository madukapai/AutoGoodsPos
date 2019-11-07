using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
using System.IO;

namespace AutoPos.ClassLibrary
{
    public class CustomVisionLibary
    {
        public string PredictionKey { get; set; }
        public string EndPoint { get; set; }
        public Guid ClassifyProjectId { get; set; }
        public string ClassifyPublishName { get; set; }
        CustomVisionPredictionClient endpoint = null;

        /// <summary>
        /// Detect Object
        /// </summary>
public ImagePrediction DetectClassify(Stream image)
{
    if (endpoint == null)
        endpoint = new CustomVisionPredictionClient() { ApiKey = PredictionKey, Endpoint = EndPoint };

    image.Seek(0, SeekOrigin.Begin);

    // 先辨識類別
    return endpoint.ClassifyImageWithNoStore(ClassifyProjectId, ClassifyPublishName, image);
}

/// <summary>
/// 識別物件
/// </summary>
/// <param name="image"></param>
/// <returns></returns>
public ImagePrediction DetectObject(Stream image, string strClassify)
{
    if (endpoint == null)
        endpoint = new CustomVisionPredictionClient() { ApiKey = PredictionKey, Endpoint = EndPoint };

    image.Seek(0, SeekOrigin.Begin);

    string strProjectId = "", strPublishName = "";

    // 瓶裝飲料
    if (strClassify == "BottleDrink")
    {
        strProjectId = "dcf4cde9-dcf9-45e8-aed4-9181a5fbfcbe";
        strPublishName = "Iteration1";
    }

    // 鋁箔包飲料
    if (strClassify == "AluminumFoilDrink")
    {
        strProjectId = "326010c6-3ae2-4c1e-ae23-89a27f095f36";
        strPublishName = "Iteration1";
    }

    // 零食
    if (strClassify == "Snack")
    {
        strProjectId = "eee54449-a95a-4302-b88a-c3298fbc12ed";
        strPublishName = "Iteration1";
    }

    // 送到個別的DetectObject專案處理
    return endpoint.DetectImageWithNoStore(Guid.Parse(strProjectId), strPublishName, image);
}
    }
}
