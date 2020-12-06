
namespace ProjectWinformDB
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.categoryList = new System.Windows.Forms.ComboBox();
            this.productsList = new System.Windows.Forms.ListBox();
            this.numberProductsPage = new System.Windows.Forms.ComboBox();
            this.previusButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.totalProducts = new System.Windows.Forms.Label();
            this.numPages = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.languageBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subcategoryList = new System.Windows.Forms.ComboBox();
            this.sizeFilter = new System.Windows.Forms.ComboBox();
            this.productLineFilter = new System.Windows.Forms.ComboBox();
            this.classFilter = new System.Windows.Forms.ComboBox();
            this.styleFilter = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // categoryList
            // 
            this.categoryList.FormattingEnabled = true;
            this.categoryList.Location = new System.Drawing.Point(12, 31);
            this.categoryList.Name = "categoryList";
            this.categoryList.Size = new System.Drawing.Size(117, 24);
            this.categoryList.TabIndex = 0;
            this.categoryList.SelectedIndexChanged += new System.EventHandler(this.categoryList_SelectedIndexChanged);
            // 
            // productsList
            // 
            this.productsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productsList.FormattingEnabled = true;
            this.productsList.ItemHeight = 16;
            this.productsList.Location = new System.Drawing.Point(12, 124);
            this.productsList.Name = "productsList";
            this.productsList.Size = new System.Drawing.Size(1093, 452);
            this.productsList.TabIndex = 1;
            this.productsList.DoubleClick += new System.EventHandler(this.productsList_DoubleClick);
            // 
            // numberProductsPage
            // 
            this.numberProductsPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numberProductsPage.FormattingEnabled = true;
            this.numberProductsPage.Items.AddRange(new object[] {
            "10",
            "20",
            "50"});
            this.numberProductsPage.Location = new System.Drawing.Point(979, 32);
            this.numberProductsPage.Name = "numberProductsPage";
            this.numberProductsPage.Size = new System.Drawing.Size(126, 24);
            this.numberProductsPage.TabIndex = 2;
            this.numberProductsPage.SelectedIndexChanged += new System.EventHandler(this.numberProductsPage_SelectedIndexChanged);
            // 
            // previusButton
            // 
            this.previusButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.previusButton.Location = new System.Drawing.Point(459, 598);
            this.previusButton.Name = "previusButton";
            this.previusButton.Size = new System.Drawing.Size(92, 35);
            this.previusButton.TabIndex = 3;
            this.previusButton.Text = "Previus";
            this.previusButton.UseVisualStyleBackColor = true;
            this.previusButton.Click += new System.EventHandler(this.previusButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.nextButton.Location = new System.Drawing.Point(557, 598);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(88, 35);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // totalProducts
            // 
            this.totalProducts.AutoSize = true;
            this.totalProducts.Location = new System.Drawing.Point(586, 101);
            this.totalProducts.Name = "totalProducts";
            this.totalProducts.Size = new System.Drawing.Size(100, 17);
            this.totalProducts.TabIndex = 5;
            this.totalProducts.Text = "Total Products";
            // 
            // numPages
            // 
            this.numPages.AutoSize = true;
            this.numPages.Location = new System.Drawing.Point(782, 101);
            this.numPages.Name = "numPages";
            this.numPages.Size = new System.Drawing.Size(48, 17);
            this.numPages.TabIndex = 6;
            this.numPages.Text = "Pages";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Choose Category";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(927, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Choose Products For Page";
            // 
            // languageBox
            // 
            this.languageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.languageBox.FormattingEnabled = true;
            this.languageBox.Items.AddRange(new object[] {
            "en",
            "fr"});
            this.languageBox.Location = new System.Drawing.Point(979, 94);
            this.languageBox.Name = "languageBox";
            this.languageBox.Size = new System.Drawing.Size(126, 24);
            this.languageBox.TabIndex = 9;
            this.languageBox.SelectedIndexChanged += new System.EventHandler(this.languageBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(979, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Choose Language";
            // 
            // subcategoryList
            // 
            this.subcategoryList.FormattingEnabled = true;
            this.subcategoryList.Location = new System.Drawing.Point(135, 31);
            this.subcategoryList.Name = "subcategoryList";
            this.subcategoryList.Size = new System.Drawing.Size(141, 24);
            this.subcategoryList.TabIndex = 11;
            this.subcategoryList.SelectedIndexChanged += new System.EventHandler(this.subcategoryList_SelectedIndexChanged);
            // 
            // sizeFilter
            // 
            this.sizeFilter.FormattingEnabled = true;
            this.sizeFilter.Items.AddRange(new object[] {
            "38",
            "40",
            "42",
            "44",
            "46",
            "48",
            "50",
            "52",
            "54",
            "56",
            "58",
            "60",
            "62",
            "70",
            "S",
            "M",
            "L",
            "XL"});
            this.sizeFilter.Location = new System.Drawing.Point(327, 31);
            this.sizeFilter.Name = "sizeFilter";
            this.sizeFilter.Size = new System.Drawing.Size(67, 24);
            this.sizeFilter.TabIndex = 12;
            this.sizeFilter.SelectedIndexChanged += new System.EventHandler(this.sizeFilter_SelectedIndexChanged);
            // 
            // productLineFilter
            // 
            this.productLineFilter.FormattingEnabled = true;
            this.productLineFilter.Items.AddRange(new object[] {
            "M",
            "R",
            "S",
            "T"});
            this.productLineFilter.Location = new System.Drawing.Point(434, 31);
            this.productLineFilter.Name = "productLineFilter";
            this.productLineFilter.Size = new System.Drawing.Size(117, 24);
            this.productLineFilter.TabIndex = 13;
            this.productLineFilter.SelectedIndexChanged += new System.EventHandler(this.productLineFilter_SelectedIndexChanged);
            // 
            // classFilter
            // 
            this.classFilter.FormattingEnabled = true;
            this.classFilter.Items.AddRange(new object[] {
            "H",
            "L",
            "M"});
            this.classFilter.Location = new System.Drawing.Point(557, 30);
            this.classFilter.Name = "classFilter";
            this.classFilter.Size = new System.Drawing.Size(117, 24);
            this.classFilter.TabIndex = 14;
            this.classFilter.SelectedIndexChanged += new System.EventHandler(this.classFilter_SelectedIndexChanged);
            // 
            // styleFilter
            // 
            this.styleFilter.FormattingEnabled = true;
            this.styleFilter.Items.AddRange(new object[] {
            "M",
            "U",
            "W"});
            this.styleFilter.Location = new System.Drawing.Point(680, 31);
            this.styleFilter.Name = "styleFilter";
            this.styleFilter.Size = new System.Drawing.Size(117, 24);
            this.styleFilter.TabIndex = 15;
            this.styleFilter.SelectedIndexChanged += new System.EventHandler(this.styleFilter_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Choose Subcategory";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(434, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "ProductLine";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(557, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Class";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(680, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 17);
            this.label8.TabIndex = 21;
            this.label8.Text = "Style";
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(13, 94);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(263, 22);
            this.searchBox.TabIndex = 22;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 17);
            this.label9.TabIndex = 23;
            this.label9.Text = "Choose for Model Name";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 639);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.styleFilter);
            this.Controls.Add(this.classFilter);
            this.Controls.Add(this.productLineFilter);
            this.Controls.Add(this.sizeFilter);
            this.Controls.Add(this.subcategoryList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.languageBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numPages);
            this.Controls.Add(this.totalProducts);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.previusButton);
            this.Controls.Add(this.numberProductsPage);
            this.Controls.Add(this.productsList);
            this.Controls.Add(this.categoryList);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox categoryList;
        private System.Windows.Forms.ListBox productsList;
        private System.Windows.Forms.ComboBox numberProductsPage;
        private System.Windows.Forms.Button previusButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label totalProducts;
        private System.Windows.Forms.Label numPages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox languageBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox subcategoryList;
        private System.Windows.Forms.ComboBox sizeFilter;
        private System.Windows.Forms.ComboBox productLineFilter;
        private System.Windows.Forms.ComboBox classFilter;
        private System.Windows.Forms.ComboBox styleFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label9;
    }
}

