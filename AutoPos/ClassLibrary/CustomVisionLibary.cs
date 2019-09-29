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
        public Guid ProjectId { get; set; }
        public string PublishName { get; set; }
        CustomVisionPredictionClient endpoint = null;

        /// <summary>
        /// Detect Object
        /// </summary>
        public ImagePrediction DetectObject(Stream image)
        {
            if (endpoint == null)
                endpoint = new CustomVisionPredictionClient() { ApiKey = PredictionKey, Endpoint = EndPoint };

            image.Seek(0, SeekOrigin.Begin);
            return endpoint.ClassifyImage(ProjectId, PublishName, image);
        }
    }
}
