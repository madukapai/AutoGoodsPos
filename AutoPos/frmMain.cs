using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using AutoPos.ClassLibrary;
using System.Configuration;

namespace AutoPos
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        WebCam oWebCam = new WebCam() { DeviceID = 0};
        CustomVisionLibary customVision = null;
        List<Models.GoodsModel.GoodsInfo> objGoods = new List<Models.GoodsModel.GoodsInfo>();

        /// <summary>
        /// 頁面載入的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            // 啟動攝影機
            oWebCam.Container = picImage;
            oWebCam.Container.Height = picImage.Height;
            oWebCam.Container.Width = picImage.Width;
            oWebCam.OpenConnection();

            // 指定影像辨識的設定值
            customVision = new CustomVisionLibary()
            {
                EndPoint = ConfigurationManager.AppSettings["EndPoint"].ToString(),
                PredictionKey = ConfigurationManager.AppSettings["PredictionKey"].ToString(),
                ProjectId = Guid.Parse(ConfigurationManager.AppSettings["ProjectId"].ToString()),
                PublishName = ConfigurationManager.AppSettings["PublishName"].ToString(),
            };
        }

        /// <summary>
        /// 商品辨識的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDetect_Click(object sender, EventArgs e)
        {
            Image objImage = oWebCam.CaptureImage();
            var ms = new MemoryStream();
            objImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            // 送出辨識的動作
            var result = customVision.DetectObject(ms);

            // 顯示在品項上
            bool blIsDetect = false;
            if (result.Predictions.Count > 0)
            {
                var item = result.Predictions.OrderByDescending(o => o.Probability).FirstOrDefault();

                if (item.Probability > 0.7)
                {
                    blIsDetect = true;
                    btnPayment.Enabled = true;

                    Models.GoodsModel.GoodsInfo goods = new GoodsInfo().GetGoodsInfo(item.TagName);
                    if (goods != null)
                    {
                        objGoods.Add(goods);
                        lbxGoods.Items.Add(goods.GoodsName + "(" + goods.Price + ")");
                    }
                }
            }

            if (!blIsDetect)
            {
                var confirm = MessageBox.Show("辨識失敗，請確認商品有正確擺放", "辨識失敗", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (confirm == DialogResult.OK)
                    BtnDetect_Click(sender, e);
            }

            // 計算總金額
            decimal diTotal = 0;
            for (int i=0; i<objGoods.Count; i++)
                diTotal += objGoods[i].Price;
            btnPayment.Text = $"總金額:{diTotal}\r\n結帳";
        }

        /// <summary>
        /// 重來的功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            lbxGoods.Items.Clear();
            btnPayment.Text = "結帳";
            btnPayment.Enabled = false;
        }

        /// <summary>
        /// 點選結帳的動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPayment_Click(object sender, EventArgs e)
        {
            MessageBox.Show("請選擇付款方式，悠遊卡、信用卡或是LinePay支付", "結帳", MessageBoxButtons.OK, MessageBoxIcon.Information);
            BtnReset_Click(sender, e);
        }
    }
}
