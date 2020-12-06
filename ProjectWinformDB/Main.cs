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
        int productsForPages; //total products for page
        int numberPages; //totalNumberProducts / productsForPages + 1 
        int currentPage; //from 0 to (numberPages - 1)
        string language = "en";

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

        

        public MainForm()
        {
            InitializeComponent();

            numberProductsPage.SelectedIndex = 1;
            languageBox.SelectedIndex = 0;


        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            numPages.Text = "1 Page";
            
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //count products
                int totalproduct = connection.Query<int>(countTotal).FirstOrDefault();
                totalProducts.Text = $"{totalproduct} Products Found";

                List<string> categories = new List<string>();

                string sql2 = "select [Name] from Production.ProductCategory";
                categories = connection.Query<string>(sql2).ToList();

                foreach (var category in categories)
                {
                    categoryList.Items.Add(category);
                }

                nextButton.Enabled = false;
                previusButton.Enabled = false;

                List<string> subcategorys = new List<string>();

                string sql3 = "select [Name] from Production.ProductSubcategory";
                subcategorys = connection.Query<string>(sql3).ToList();

                foreach (var subcategory in subcategorys)
                {
                    subcategoryList.Items.Add(subcategory);
                }
            }

        }
        private void initializeListBox()
        {
            
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Product> products = new List<Product>();

                string sql1 = sql + $"WHERE ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID IS NOT NULL ORDER BY Product.Name";

                products = connection.Query<Product>(sql1).ToList();

                foreach (Product product in products)
                {
                    productsList.Items.Add(product.ToString());
                }
            }
        }

        private void categoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsList.Items.Clear();
            categoryChangeLanguage();
            
        }

        private void subcategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsList.Items.Clear();
            subCategoryChangeLanguage();
        }

        private void sizeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsList.Items.Clear();
            sizeProductsFilter();
        }

        private void productLineFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsList.Items.Clear();
            productLineProductsFilter();
        }

        private void classFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsList.Items.Clear();
            classProductsFilter(); 
        }

        private void styleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            productsList.Items.Clear();
            styleProductsFilter();
        }

        private void categoryChangeLanguage()
        {
            subcategoryList.Text = "";
            sizeFilter.Text = "";
            productLineFilter.Text = "";
            classFilter.Text = "";
            styleFilter.Text = "";
      
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Product> products = new List<Product>();

                string sql1 = sql + $"WHERE ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID IS NOT NULL AND ProductCategory.Name = '{categoryList.Text}' ORDER BY Product.Name";

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

        private void subCategoryChangeLanguage()
        {
            categoryList.Text = "";
            sizeFilter.Text = "";
            productLineFilter.Text = "";
            classFilter.Text = "";
            styleFilter.Text = "";
    
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Product> products = new List<Product>();

                string sql1 = sql + $"WHERE ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID IS NOT NULL AND ProductSubcategory.Name = '{subcategoryList.Text}' ORDER BY Product.Name";

                products = connection.Query<Product>(sql1).ToList();
                // count products for category
                string sqltotalproducts = countTotal + $" AND ProductSubcategory.Name = '{subcategoryList.Text}'";

                int totalproductCategory = connection.Query<int>(sqltotalproducts).FirstOrDefault();
                totalProducts.Text = $"{totalproductCategory} Products Found";

                // pagination
                //productsForPages = int.Parse(numberProductsPage.Text);
                //numberPages = totalproductCategory / productsForPages + 1;
                //currentPage = 0;
                //previusButton.Enabled = false;
                //nextButton.Enabled = true;

                foreach (Product product in products)
                {
                    productsList.Items.Add(product.ToString());
                }

            }
        }

        private void sizeProductsFilter()
        {
            categoryList.Text = "";
            subcategoryList.Text = "";
            productLineFilter.Text = "";
            classFilter.Text = "";
            styleFilter.Text = "";
        
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Product> products = new List<Product>();

                string sql1 = sql + $"WHERE ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID IS NOT NULL AND Product.Size = '{sizeFilter.Text}' ORDER BY Product.Name";

                products = connection.Query<Product>(sql1).ToList();
                // count products for category
                string sqltotalproducts = countTotal + $" AND Product.Size = '{sizeFilter.Text}'";

                int totalproductCategory = connection.Query<int>(sqltotalproducts).FirstOrDefault();
                totalProducts.Text = $"{totalproductCategory} Products Found";

                foreach (Product product in products)
                {
                    productsList.Items.Add(product.ToString());
                }

            }
        }

        private void productLineProductsFilter()
        {
            categoryList.Text = "";
            subcategoryList.Text = "";
            sizeFilter.Text = "";
            classFilter.Text = "";
            styleFilter.Text = "";
         

            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Product> products = new List<Product>();

                string sql1 = sql + $"WHERE ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID IS NOT NULL AND Product.ProductLine = '{productLineFilter.Text}' ORDER BY Product.Name";

                products = connection.Query<Product>(sql1).ToList();
                // count products for category
                string sqltotalproducts = countTotal + $" AND Product.ProductLine = '{productLineFilter.Text}'";

                int totalproductCategory = connection.Query<int>(sqltotalproducts).FirstOrDefault();
                totalProducts.Text = $"{totalproductCategory} Products Found";

                foreach (Product product in products)
                {
                    productsList.Items.Add(product.ToString());
                }

            }
        }

        private void classProductsFilter()
        {
            categoryList.Text = "";
            subcategoryList.Text = "";
            sizeFilter.Text = "";
            productLineFilter.Text = "";
            styleFilter.Text = "";
    

            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Product> products = new List<Product>();

                string sql1 = sql + $"WHERE ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID IS NOT NULL AND Product.Class = '{classFilter.Text}' ORDER BY Product.Name";

                products = connection.Query<Product>(sql1).ToList();
                // count products for category
                string sqltotalproducts = countTotal + $" AND Product.Class = '{classFilter.Text}'";

                int totalproductCategory = connection.Query<int>(sqltotalproducts).FirstOrDefault();
                totalProducts.Text = $"{totalproductCategory} Products Found";

                foreach (Product product in products)
                {
                    productsList.Items.Add(product.ToString());
                }

            }
        }

        private void styleProductsFilter()
        {
            categoryList.Text = "";
            subcategoryList.Text = "";
            sizeFilter.Text = "";
            productLineFilter.Text = "";
            classFilter.Text = "";

            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<Product> products = new List<Product>();

                string sql1 = sql + $"WHERE ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID IS NOT NULL AND Product.Style = '{styleFilter.Text}' ORDER BY Product.Name";

                products = connection.Query<Product>(sql1).ToList();
                // count products for category
                string sqltotalproducts = countTotal + $" AND Product.Style = '{styleFilter.Text}'";

                int totalproductCategory = connection.Query<int>(sqltotalproducts).FirstOrDefault();
                totalProducts.Text = $"{totalproductCategory} Products Found";

                foreach (Product product in products)
                {
                    productsList.Items.Add(product.ToString());
                }

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

        private void productsList_DoubleClick(object sender, EventArgs e)
        {
            string productSelected = productsList.SelectedItems[0].ToString();

            //string productModel = productSelected.Substring(0, productSelected.IndexOf(','));
            string productModel = productSelected.Split('/')[0];
            string productDescrition = productSelected.Split('/')[1];
            string productName = productSelected.Split('/')[2];
            string productNumber = productSelected.Split('/')[3];
            string productColor = productSelected.Split('/')[4];
            string productListPrice = productSelected.Split('/')[5];
            string productSize = productSelected.Split('/')[6];
            string productLine = productSelected.Split('/')[7];
            string productClass = productSelected.Split('/')[8];
            string productStyle = productSelected.Split('/')[9];
            string productCategory = productSelected.Split('/')[10];
            string productSubcategory = productSelected.Split('/')[11];

            ModifyProducts modifyProductsForm = new ModifyProducts(productModel, productDescrition, productName, productNumber, productColor, productListPrice, productSize, productLine, productClass, productStyle, productCategory, productSubcategory);
            modifyProductsForm.ShowDialog();
        }

        private void languageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (languageBox.Text == "fr")
            {
                language = "fr";
            }
            else
            {
                language = "en";
            }
            productsList.Items.Clear();

            if ((categoryList.Text=="")&&(subcategoryList.Text=="")&&(sizeFilter.Text=="")&&(productLineFilter.Text=="")&&(classFilter.Text=="")&&(styleFilter.Text==""))
            {
                initializeListBox();
            }
            else if(categoryList.Text != "")
            {
                categoryChangeLanguage();
            }
            else if (subcategoryList.Text != "")
            {
                subCategoryChangeLanguage();
            }
            else if (sizeFilter.Text != "")
            {
                sizeProductsFilter();
            }
            else if (productLineFilter.Text != "")
            {
                productLineProductsFilter();
            }
            else if (classFilter.Text != "")
            {
                classProductsFilter();
            }
            else
            {
                styleProductsFilter();
            }
            
            
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["AdventureWorks2016"].ConnectionString;
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                string sql1 = sql + $"WHERE ProductModelProductDescriptionCulture.CultureID = '{language}' AND Product.ProductModelID IS NOT NULL AND ProductModel.Name = '{searchBox.Text}' ORDER BY Product.Name";

                List<Product> products = new List<Product>();
                products = connection.Query<Product>(sql1).ToList();
                productsList.Items.Clear();

                if (searchBox.Text=="")
                {
                    initializeListBox();
                }

                foreach (Product product in products)
                {
                    productsList.Items.Add(product.ToString());
                }


            }
        }
    }
}
