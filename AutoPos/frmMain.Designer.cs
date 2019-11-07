namespace AutoPos
{
    partial class frmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnDetect = new System.Windows.Forms.Button();
            this.lbxGoods = new System.Windows.Forms.ListBox();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnObjectDetect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.Location = new System.Drawing.Point(22, 22);
            this.picImage.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(1268, 878);
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // btnDetect
            // 
            this.btnDetect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetect.Location = new System.Drawing.Point(1294, 160);
            this.btnDetect.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(245, 130);
            this.btnDetect.TabIndex = 1;
            this.btnDetect.Text = "商品辨識";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.BtnDetect_Click);
            // 
            // lbxGoods
            // 
            this.lbxGoods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxGoods.FormattingEnabled = true;
            this.lbxGoods.ItemHeight = 24;
            this.lbxGoods.Location = new System.Drawing.Point(1294, 442);
            this.lbxGoods.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.lbxGoods.Name = "lbxGoods";
            this.lbxGoods.Size = new System.Drawing.Size(240, 292);
            this.lbxGoods.TabIndex = 2;
            // 
            // btnPayment
            // 
            this.btnPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayment.Enabled = false;
            this.btnPayment.Location = new System.Drawing.Point(1294, 746);
            this.btnPayment.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(245, 154);
            this.btnPayment.TabIndex = 1;
            this.btnPayment.Text = "結帳";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.BtnPayment_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(1294, 22);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(245, 130);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "重來";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // btnObjectDetect
            // 
            this.btnObjectDetect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnObjectDetect.Location = new System.Drawing.Point(1294, 298);
            this.btnObjectDetect.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnObjectDetect.Name = "btnObjectDetect";
            this.btnObjectDetect.Size = new System.Drawing.Size(245, 130);
            this.btnObjectDetect.TabIndex = 1;
            this.btnObjectDetect.Text = "單一物品辨識";
            this.btnObjectDetect.UseVisualStyleBackColor = true;
            this.btnObjectDetect.Click += new System.EventHandler(this.btnObjectDetect_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1560, 922);
            this.Controls.Add(this.lbxGoods);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnObjectDetect);
            this.Controls.Add(this.btnDetect);
            this.Controls.Add(this.picImage);
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.Name = "frmMain";
            this.Text = "AutoPos";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.ListBox lbxGoods;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnObjectDetect;
    }
}

