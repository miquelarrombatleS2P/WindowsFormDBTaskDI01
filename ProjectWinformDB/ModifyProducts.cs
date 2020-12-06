using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectWinformDB
{
    public partial class ModifyProducts : Form
    {
        public ModifyProducts()
        {
            InitializeComponent();
        }

        public ModifyProducts(string ProductModel, string Description, string Name, string ProductNumber, string Color, string ListPrice, string Size, string ProductLine, string Class, string Style, string ProductCategory, string ProductSubcategory)
        {
            InitializeComponent();
            modelText.AppendText(ProductModel);
            descriptionText.AppendText(Description);
            nameText.AppendText(Name);
            numberText.AppendText(ProductNumber);
            colorText.AppendText(Color);
            listPriceText.AppendText(ListPrice);
            sizeText.AppendText(Size);
            productLineText.AppendText(ProductLine);
            classText.AppendText(Class);
            styleText.AppendText(Style);
            categoryText.AppendText(ProductCategory);
            subcategoryText.AppendText(ProductSubcategory);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string updateModel = $"update Production.ProductModel "
                                   + $"set ProductModel.Name = '{modelText.Text}' "
                                   + $"from Production.ProductModel "
                                   + $"Inner join Production.Product "
                                   + $"on Production.Product.ProductModelID = Production.ProductModel.ProductModelID";
                    string updateDescription = $"update Production.ProductDescription "
                                             + $"set ProductDescription.Description = '{descriptionText.Text}' "
                                             + $"from Production.ProductDescription "
                                             + $"Inner join Production.ProductModelProductDescriptionCulture "
                                             + $"on Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID";
                }
                catch (SqlException)
                {
                    throw new Exception("Error syntax sql");
                }


            }
        }
    }
}
