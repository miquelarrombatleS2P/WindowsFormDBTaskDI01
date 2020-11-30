
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
            this.SuspendLayout();
            // 
            // categoryList
            // 
            this.categoryList.FormattingEnabled = true;
            this.categoryList.Location = new System.Drawing.Point(12, 32);
            this.categoryList.Name = "categoryList";
            this.categoryList.Size = new System.Drawing.Size(233, 24);
            this.categoryList.TabIndex = 0;
            // 
            // productsList
            // 
            this.productsList.FormattingEnabled = true;
            this.productsList.ItemHeight = 16;
            this.productsList.Location = new System.Drawing.Point(12, 92);
            this.productsList.Name = "productsList";
            this.productsList.Size = new System.Drawing.Size(784, 356);
            this.productsList.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 459);
            this.Controls.Add(this.productsList);
            this.Controls.Add(this.categoryList);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox categoryList;
        private System.Windows.Forms.ListBox productsList;
    }
}

