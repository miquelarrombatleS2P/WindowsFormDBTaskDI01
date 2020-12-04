
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
            this.SuspendLayout();
            // 
            // categoryList
            // 
            this.categoryList.FormattingEnabled = true;
            this.categoryList.Location = new System.Drawing.Point(12, 32);
            this.categoryList.Name = "categoryList";
            this.categoryList.Size = new System.Drawing.Size(233, 24);
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
            this.productsList.Location = new System.Drawing.Point(12, 92);
            this.productsList.Name = "productsList";
            this.productsList.Size = new System.Drawing.Size(784, 340);
            this.productsList.TabIndex = 1;
            this.productsList.SelectedIndexChanged += new System.EventHandler(this.productsList_SelectedIndexChanged);
            // 
            // numberProductsPage
            // 
            this.numberProductsPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numberProductsPage.FormattingEnabled = true;
            this.numberProductsPage.Items.AddRange(new object[] {
            "10",
            "20",
            "50"});
            this.numberProductsPage.Location = new System.Drawing.Point(670, 32);
            this.numberProductsPage.Name = "numberProductsPage";
            this.numberProductsPage.Size = new System.Drawing.Size(126, 24);
            this.numberProductsPage.TabIndex = 2;
            this.numberProductsPage.SelectedIndexChanged += new System.EventHandler(this.numberProductsPage_SelectedIndexChanged);
            // 
            // previusButton
            // 
            this.previusButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.previusButton.Location = new System.Drawing.Point(305, 444);
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
            this.nextButton.Location = new System.Drawing.Point(403, 444);
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
            this.totalProducts.Location = new System.Drawing.Point(266, 72);
            this.totalProducts.Name = "totalProducts";
            this.totalProducts.Size = new System.Drawing.Size(100, 17);
            this.totalProducts.TabIndex = 5;
            this.totalProducts.Text = "Total Products";
            // 
            // numPages
            // 
            this.numPages.AutoSize = true;
            this.numPages.Location = new System.Drawing.Point(432, 72);
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
            this.label2.Location = new System.Drawing.Point(618, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Choose Products For Page";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 485);
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
    }
}

