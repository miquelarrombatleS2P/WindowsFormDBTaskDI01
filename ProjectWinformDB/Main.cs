using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace ProjectWinformDB
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        public string sql = $"SELECT "
                       + $"Production.ProductModel.Name AS ProductModel, Production.ProductDescription.Description, "
                       + $"Production.Product.Name, Production.Product.ProductNumber, Production.Product.Color, Production.Product.ListPrice, "
                       + $"Production.Product.Size, Production.Product.ProductLine, Production.Product.Class, Production.Product.Style, "
                       + $"Production.ProductCategory.Name AS ProductCategory, Production.ProductSubcategory.Name AS ProductSubcategory "
                       + $"FROM "
                       + $"Production.Product "
                       + $"INNER JOIN Production.ProductSubcategory on Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID "
                       + $"INNER JOIN Production.ProductCategory on Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID "
                       + $"INNER JOIN Production.ProductModel on Production.Product.ProductModelID = Production.ProductModel.ProductModelID "
                       + $"INNER JOIN Production.ProductModelProductDescriptionCulture on Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID "
                       + $"INNER JOIN Production.ProductDescription on Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID ";

        public string countTotal = $"SELECT COUNT(*) "
                       + $"FROM "
                       + $"Production.Product "
                       + $"INNER JOIN Production.ProductSubcategory on Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID "
                       + $"INNER JOIN Production.ProductCategory on Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID "
                       + $"INNER JOIN Production.ProductModel on Production.Product.ProductModelID = Production.ProductModel.ProductModelID "
                       + $"INNER JOIN Production.ProductModelProductDescriptionCulture on Production.ProductModel.ProductModelID = Production.ProductModelProductDescriptionCulture.ProductModelID "
                       + $"INNER JOIN Production.ProductDescription on Production.ProductModelProductDescriptionCulture.ProductDescriptionID = Production.ProductDescription.ProductDescriptionID "
                       + $"WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL";

        int productsForPages; //total products for page
        int numberPages; //totalNumberProducts / productsForPages + 1 
        int currentPage; //from 0 to (numberPages - 1)

        public MainForm()
        {
            InitializeComponent();

            numberProductsPage.SelectedIndex = 1;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            numPages.Text = "1 Page";

            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Product> products = new List<Product>();

                string sql1 = sql + $"WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL ORDER BY Product.Name";

                products = connection.Query<Product>(sql1).ToList();
                //count products
                int totalproduct = connection.Query<int>(countTotal).FirstOrDefault();
                totalProducts.Text = $"{totalproduct} Products Found";

                foreach (Product product in products)
                {
                    productsList.Items.Add(product.ToString());
                }

                List<string> categories = new List<string>();

                string sql2 = "select [Name] from Production.ProductCategory";
                categories = connection.Query<string>(sql2).ToList();

                foreach (var category in categories)
                {
                    categoryList.Items.Add(category);
                }

                nextButton.Enabled = false;
                previusButton.Enabled = false;

            }

        }

        private void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsList.Items.Clear();
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Product> products = new List<Product>();

                string sql1 = sql + $"WHERE ProductModelProductDescriptionCulture.CultureID = 'en' AND Product.ProductModelID IS NOT NULL AND ProductCategory.Name = '{categoryList.Text}' ORDER BY Product.Name";

                products = connection.Query<Product>(sql1).ToList();
                // count products for category
                string sqltotalproducts = countTotal + $" AND ProductCategory.Name = '{categoryList.Text}'";
                
                int totalproductCategory = connection.Query<int>(sqltotalproducts).FirstOrDefault();
                totalProducts.Text = $"{totalproductCategory} Products Found";

                // pagination
                productsForPages = int.Parse(numberProductsPage.Text);
                numberPages = totalproductCategory / productsForPages + 1;
                currentPage = 0;
                previusButton.Enabled = false;
                nextButton.Enabled = true;
             
                foreach (Product product in products)
                {
                    productsList.Items.Add(product.ToString());
                }

                updatateProductsList();
            }
        }
        private void updatateProductsList()
        {
            numPages.Text = (currentPage + 1) + " of " + numberPages + "pages";
            
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                string sqlUpdateListProducts = sql + $"WHERE ProductModelProductDescriptionCulture.CultureID = 'en' " +
                    $"AND Product.ProductModelID IS NOT NULL " +
                    $"AND ProductCategory.Name = '{categoryList.Text}' " +
                    $"ORDER BY Product.Name " +
                    $"OFFSET {currentPage * productsForPages} ROWS FETCH NEXT {productsForPages} ROWS ONLY ";

                List<Product> products = new List<Product>();
                products = connection.Query<Product>(sqlUpdateListProducts).ToList();
                productsList.Items.Clear();
                foreach (Product product in products)
                {
                    productsList.Items.Add(product.ToString());
                }


            }
        }

        private void numberProductsPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsForPages = int.Parse(numberProductsPage.Text);
            int lastSelectItem = categoryList.SelectedIndex;
            categoryList.SelectedIndex = -1;
            categoryList.SelectedIndex = lastSelectItem;
        }
        
        private void nextButton_Click(object sender, EventArgs e)
        {
            currentPage++;
            if (currentPage == numberPages - 1)
            {
                nextButton.Enabled = false;
            }
            previusButton.Enabled = true;
            updatateProductsList();
        }

        private void previusButton_Click(object sender, EventArgs e)
        {
            currentPage--;
            if (currentPage == 0)
            {
                previusButton.Enabled = false;
            }
            nextButton.Enabled = true;
            updatateProductsList();

        }

        private void productsList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
