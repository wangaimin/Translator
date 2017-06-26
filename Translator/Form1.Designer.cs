namespace Translator
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.页面翻译 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnSEO = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCookie_File = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSystemAreaByYouDao = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCookie_DB = new System.Windows.Forms.TextBox();
            this.btnSystemCategory = new System.Windows.Forms.Button();
            this.btnSupplierCategory = new System.Windows.Forms.Button();
            this.btnSystemArea = new System.Windows.Forms.Button();
            this.btnBidTool_TenderBidStatusItem = new System.Windows.Forms.Button();
            this.btnSystemOrganization = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDBConfig = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnGoogle = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.页面翻译.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // 页面翻译
            // 
            this.页面翻译.Controls.Add(this.tabPage1);
            this.页面翻译.Controls.Add(this.tabPage2);
            this.页面翻译.Controls.Add(this.tabPage3);
            this.页面翻译.Location = new System.Drawing.Point(12, 12);
            this.页面翻译.Name = "页面翻译";
            this.页面翻译.SelectedIndex = 0;
            this.页面翻译.Size = new System.Drawing.Size(2019, 1123);
            this.页面翻译.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnSEO);
            this.tabPage1.Controls.Add(this.btnMenu);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tbCookie_File);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(2011, 1091);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "页面翻译";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnSEO
            // 
            this.btnSEO.Location = new System.Drawing.Point(921, 362);
            this.btnSEO.Name = "btnSEO";
            this.btnSEO.Size = new System.Drawing.Size(161, 75);
            this.btnSEO.TabIndex = 30;
            this.btnSEO.Text = "SEOXML文件翻译(Bing)";
            this.btnSEO.UseVisualStyleBackColor = true;
            this.btnSEO.Click += new System.EventHandler(this.btnSEO_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(717, 362);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(161, 75);
            this.btnMenu.TabIndex = 29;
            this.btnMenu.Text = "菜单XML文件翻译(Bing)";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(27, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 30);
            this.label5.TabIndex = 28;
            this.label5.Text = "cookie：";
            // 
            // tbCookie_File
            // 
            this.tbCookie_File.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCookie_File.Location = new System.Drawing.Point(306, 47);
            this.tbCookie_File.Name = "tbCookie_File";
            this.tbCookie_File.Size = new System.Drawing.Size(802, 42);
            this.tbCookie_File.TabIndex = 27;
            this.tbCookie_File.Text = resources.GetString("tbCookie_File.Text");
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(526, 464);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(161, 75);
            this.button6.TabIndex = 25;
            this.button6.Text = "JSON文件翻译(YouDao)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(310, 464);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(161, 75);
            this.button7.TabIndex = 24;
            this.button7.Text = "XML文件翻译(YouDao)";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(526, 362);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(161, 75);
            this.button5.TabIndex = 23;
            this.button5.Text = "JSON文件翻译(Bing)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(310, 362);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(161, 75);
            this.button4.TabIndex = 22;
            this.button4.Text = "XML文件翻译(Bing)";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(306, 144);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(802, 174);
            this.textBox3.TabIndex = 21;
            this.textBox3.Text = "C:\\Users\\admin\\Gene\\CSCEC\\Mall\\03_Code\\BH_RS_MutiLanguage\\03_Portal\\Configuration" +
    "\\TextResources\\en-us\\WebHost\\Register";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(69, 247);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 71);
            this.button3.TabIndex = 20;
            this.button3.Text = "选择文件夹";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(-160, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 30);
            this.label1.TabIndex = 16;
            this.label1.Text = "结果：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSystemAreaByYouDao);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbCookie_DB);
            this.tabPage2.Controls.Add(this.btnSystemCategory);
            this.tabPage2.Controls.Add(this.btnSupplierCategory);
            this.tabPage2.Controls.Add(this.btnSystemArea);
            this.tabPage2.Controls.Add(this.btnBidTool_TenderBidStatusItem);
            this.tabPage2.Controls.Add(this.btnSystemOrganization);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.tbDBConfig);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(2011, 1091);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "数据库翻译";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSystemAreaByYouDao
            // 
            this.btnSystemAreaByYouDao.Location = new System.Drawing.Point(306, 320);
            this.btnSystemAreaByYouDao.Name = "btnSystemAreaByYouDao";
            this.btnSystemAreaByYouDao.Size = new System.Drawing.Size(198, 76);
            this.btnSystemAreaByYouDao.TabIndex = 28;
            this.btnSystemAreaByYouDao.Text = "有道翻译SystemArea";
            this.btnSystemAreaByYouDao.UseVisualStyleBackColor = true;
            this.btnSystemAreaByYouDao.Click += new System.EventHandler(this.btnSystemAreaByYouDao_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(36, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 30);
            this.label4.TabIndex = 27;
            this.label4.Text = "Cookie：";
            // 
            // tbCookie_DB
            // 
            this.tbCookie_DB.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbCookie_DB.Location = new System.Drawing.Point(249, 121);
            this.tbCookie_DB.Name = "tbCookie_DB";
            this.tbCookie_DB.Size = new System.Drawing.Size(1291, 42);
            this.tbCookie_DB.TabIndex = 26;
            this.tbCookie_DB.Text = resources.GetString("tbCookie_DB.Text");
            // 
            // btnSystemCategory
            // 
            this.btnSystemCategory.Location = new System.Drawing.Point(798, 194);
            this.btnSystemCategory.Name = "btnSystemCategory";
            this.btnSystemCategory.Size = new System.Drawing.Size(198, 76);
            this.btnSystemCategory.TabIndex = 25;
            this.btnSystemCategory.Text = "翻译SystemCategory";
            this.btnSystemCategory.UseVisualStyleBackColor = true;
            this.btnSystemCategory.Click += new System.EventHandler(this.btnSystemCategory_Click);
            // 
            // btnSupplierCategory
            // 
            this.btnSupplierCategory.Location = new System.Drawing.Point(1033, 194);
            this.btnSupplierCategory.Name = "btnSupplierCategory";
            this.btnSupplierCategory.Size = new System.Drawing.Size(198, 76);
            this.btnSupplierCategory.TabIndex = 24;
            this.btnSupplierCategory.Text = "翻译SupplierCategory";
            this.btnSupplierCategory.UseVisualStyleBackColor = true;
            this.btnSupplierCategory.Click += new System.EventHandler(this.btnSupplierCategory_Click);
            // 
            // btnSystemArea
            // 
            this.btnSystemArea.Location = new System.Drawing.Point(306, 194);
            this.btnSystemArea.Name = "btnSystemArea";
            this.btnSystemArea.Size = new System.Drawing.Size(198, 76);
            this.btnSystemArea.TabIndex = 23;
            this.btnSystemArea.Text = "翻译SystemArea";
            this.btnSystemArea.UseVisualStyleBackColor = true;
            this.btnSystemArea.Click += new System.EventHandler(this.btnSystemArea_Click);
            // 
            // btnBidTool_TenderBidStatusItem
            // 
            this.btnBidTool_TenderBidStatusItem.Location = new System.Drawing.Point(544, 194);
            this.btnBidTool_TenderBidStatusItem.Name = "btnBidTool_TenderBidStatusItem";
            this.btnBidTool_TenderBidStatusItem.Size = new System.Drawing.Size(198, 76);
            this.btnBidTool_TenderBidStatusItem.TabIndex = 22;
            this.btnBidTool_TenderBidStatusItem.Text = "翻译BidTool_TenderBidStatusItem";
            this.btnBidTool_TenderBidStatusItem.UseVisualStyleBackColor = true;
            this.btnBidTool_TenderBidStatusItem.Click += new System.EventHandler(this.btnBidTool_TenderBidStatusItem_Click);
            // 
            // btnSystemOrganization
            // 
            this.btnSystemOrganization.Location = new System.Drawing.Point(41, 194);
            this.btnSystemOrganization.Name = "btnSystemOrganization";
            this.btnSystemOrganization.Size = new System.Drawing.Size(198, 76);
            this.btnSystemOrganization.TabIndex = 21;
            this.btnSystemOrganization.Text = "翻译SystemOrganization";
            this.btnSystemOrganization.UseVisualStyleBackColor = true;
            this.btnSystemOrganization.Click += new System.EventHandler(this.btnSystemOrganization_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(36, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 30);
            this.label2.TabIndex = 20;
            this.label2.Text = "数据库地址：";
            // 
            // tbDBConfig
            // 
            this.tbDBConfig.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbDBConfig.Location = new System.Drawing.Point(249, 58);
            this.tbDBConfig.Name = "tbDBConfig";
            this.tbDBConfig.Size = new System.Drawing.Size(1291, 42);
            this.tbDBConfig.TabIndex = 19;
            this.tbDBConfig.Text = " data source=localhost;database=YZ_AuthCenter\r\n;user id=sa;password=yzw@123;Timeo" +
    "ut=30;";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnGoogle);
            this.tabPage3.Controls.Add(this.tbResult);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.tbQuery);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(2011, 1091);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "测试";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnGoogle
            // 
            this.btnGoogle.Location = new System.Drawing.Point(858, 331);
            this.btnGoogle.Name = "btnGoogle";
            this.btnGoogle.Size = new System.Drawing.Size(205, 81);
            this.btnGoogle.TabIndex = 32;
            this.btnGoogle.Text = "Google翻译";
            this.btnGoogle.UseVisualStyleBackColor = true;
            // 
            // tbResult
            // 
            this.tbResult.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbResult.Location = new System.Drawing.Point(331, 113);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(754, 174);
            this.tbResult.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(51, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 30);
            this.label3.TabIndex = 30;
            this.label3.Text = "需要翻译的文本：";
            // 
            // tbQuery
            // 
            this.tbQuery.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbQuery.Location = new System.Drawing.Point(331, 48);
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(754, 42);
            this.tbQuery.TabIndex = 29;
            this.tbQuery.Text = "我爱你，中国";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(570, 331);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(205, 81);
            this.button2.TabIndex = 28;
            this.button2.Text = "有道翻译";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(326, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(161, 75);
            this.button1.TabIndex = 27;
            this.button1.Text = "Bing翻译";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2043, 1138);
            this.Controls.Add(this.页面翻译);
            this.Name = "Form1";
            this.Text = "Form1";
            this.页面翻译.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl 页面翻译;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDBConfig;
        private System.Windows.Forms.Button btnSystemCategory;
        private System.Windows.Forms.Button btnSupplierCategory;
        private System.Windows.Forms.Button btnSystemArea;
        private System.Windows.Forms.Button btnBidTool_TenderBidStatusItem;
        private System.Windows.Forms.Button btnSystemOrganization;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbCookie_DB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCookie_File;
        private System.Windows.Forms.Button btnSystemAreaByYouDao;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnSEO;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnGoogle;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbQuery;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

