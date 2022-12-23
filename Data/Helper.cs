using System.Data.SqlClient;
using System.Xml.Linq;
using E_Commerce_Project.Models.Products;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Routing;

namespace E_Commerce_Project.Data
{
    public static class Helper
    {
        //public static List<SelectListItem> brandsList = new List<SelectListItem>();
        //public static SqlConnection dbConnection()
        //{
        //    //IWebHostEnvironment _hostEnvironment;
        //    string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=e-commerce_db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    // D:\Ecommerce1512\E-Commerce Project\E-Commerce Project\wwwroot\e-commerce_db.mdf
        //    //string connectionString = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_hostEnvironment.ContentRootPath.ToString()}/e-commerce_db.mdf;Integrated Security=True";



        //    SqlConnection sqlConnection = new SqlConnection(connectionString);
        //    try
        //    {
        //        Console.WriteLine($"\nConnexion à la base ...");

        //        //open connection
        //        sqlConnection.Open();

        //        Console.WriteLine("Connexion réussie!\n");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine($"*** Erreur de connexion :\n{e.Message}");
        //        return null;
        //    }

        //    return sqlConnection;
        //}

        ////public static void getListFromDB<T>(SqlConnection sqlConnection, System.Type type, List<T> genericList)
        ////{
        ////    string selectCommandString = $"select * from {type}";
        ////    //List<T> objectsList = new List<T>();
        ////    using (SqlCommand selectCommand = new SqlCommand(selectCommandString, sqlConnection))
        ////    {
        ////        if (type == typeof(Brands))
        ////        {
        ////            SqlDataReader sqlDataReader = selectCommand.ExecuteReader();
        ////            while (sqlDataReader.Read())
        ////            {
        ////                genericList.Add(new Object(
        ////                    Convert.ToInt32(sqlDataReader["Id"]),
        ////                    sqlDataReader["name"].ToString()));


        ////            }
        ////            //**/objectsList = brandsList;
        ////        }
        ////    }
        ////}

        //public static void getAllBrands(SqlConnection sqlConnection, List<SelectListItem> brandsList)
        //{
        //    string selectCommandString = $"select Id, name from Brand";
        //    //List<T> objectsList = new List<T>();
        //    using (SqlCommand selectCommand = new SqlCommand(selectCommandString, sqlConnection))
        //    {
        //        //if (type == typeof(Brands))
        //        //{
        //        SqlDataReader sqlDataReader = selectCommand.ExecuteReader();
        //        while (sqlDataReader.Read())
        //        {
        //            brandsList.Add(new SelectListItem
        //            {
        //                Value = sqlDataReader["Id"].ToString(),
        //                Text = sqlDataReader["name"].ToString()
        //            });
        //        }
        //        //**/objectsList = brandsList;
        //        //}
        //    }
        //}

        //public static string getBrandName(int id)
        //{
        //    getAllBrands(dbConnection(), brandsList);
        //    return brandsList.ToList().FirstOrDefault(b => b.Value == id.ToString()).Text;
        //}

        //public static void uploadImage(Product product, IWebHostEnvironment _hostEnvironment)
        //{
        //    string wwwRootPath = _hostEnvironment.WebRootPath;
        //    string fileName = Path.GetFileNameWithoutExtension(product.image.formFile.FileName);
        //    string extension = Path.GetExtension(product.image.formFile.FileName);
        //    product.image.name = product.name + /*product.productDetails.productBrand.name +*/ extension;
        //    string path = Path.Combine(wwwRootPath + "/Content/" + product.image.name);
        //    using (FileStream fileStream = new FileStream(path, FileMode.Create))
        //    {
        //        product.image.formFile.CopyTo(fileStream);
        //    }
        //}

        //public static int insertImgToDB(Product product, SqlConnection connection)
        //{
        //    int idImgProduct;
        //    StringBuilder strBuilder = new StringBuilder();
        //    strBuilder.Append(
        //        "INSERT INTO [Image] " +
        //        "([name]) output INSERTED.ID " +
        //        "VALUES ");
        //    //foreach (Category Element in productDetails.)
        //    //{
        //    strBuilder.Append(
        //        //$"(N'{product.image.name.Replace("'", "''")}', " +
        //        //$"N{product.image.title}, " +
        //        $"(N'{product.image.name.Replace("'", "''")}')");
        //    //}
        //    string insertQuery = strBuilder.ToString();
        //    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
        //    {
        //        //idImgProduct = (int)insertCommand.ExecuteScalar();
        //        idImgProduct = (int)insertCommand.ExecuteScalar();
        //        //if (type == typeof(Brands))
        //        //{
        //        //insertCommand.ExecuteNonQuery();
        //        //int idChildProduct = (int)insertCommand.ExecuteScalar();
        //        //**/objectsList = brandsList;
        //        //}
        //    }
        //    return idImgProduct;
        //}

        //public static int addImageToDB(Product product, IWebHostEnvironment _hostEnvironment, SqlConnection connection)
        //{
        //    uploadImage(product, _hostEnvironment);
        //    return insertImgToDB(product, connection);
        //}

        //public static Product addNewProductToDb(Product product, IWebHostEnvironment _hostEnvironment)
        //{
        //    ProductDetails productDetails = product.productDetails;
        //    SqlConnection connection = dbConnection();
        //    int idChildProduct = insertProdDetailsToDb(connection, productDetails);
        //    int idImgProd = addImageToDB(product, _hostEnvironment, connection);
        //    return insertProdToDb(product, connection, idChildProduct, idImgProd);
        //}
        //public static Product insertProdToDb(Product product, SqlConnection sqlConnection, int idChildProduct, int idImgProd)
        //{
        //    string specificBrandName = getBrandName(product.productDetails.productBrandId);
        //    Product addedProduct;
        //    StringBuilder strBuilder = new StringBuilder();
        //    strBuilder.Append(
        //        "INSERT INTO [Product] " +
        //        "([name], [price], [productDetailsId], [imageId]) output INSERTED.ID " +
        //        "VALUES ");
        //    //foreach (Category Element in productDetails.)
        //    //{
        //    strBuilder.Append(
        //        $"(N'{product.name.Replace("'", "''")}', " +
        //        $"{product.price}, " +
        //        $"{idChildProduct}, " +
        //        $"{idImgProd})");
        //    //}
        //    string insertQuery = strBuilder.ToString();
        //    using (SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection))
        //    {
        //        //if (type == typeof(Brands))
        //        //{
        //        int productId = (int)insertCommand.ExecuteScalar();
        //        addedProduct = new Product()
        //        {
        //            id = Convert.ToInt32(productId),
        //            name = product.name,
        //            productDetails = new ProductDetails
        //            {
        //                imageLink = product.productDetails.imageLink,
        //                productBrand = new Brand
        //                {
        //                    id = Convert.ToInt32(product.productDetails.productBrandId),
        //                    name = specificBrandName.ToString()
        //                }
        //            },
        //            image = new Image
        //            {
        //                id = Convert.ToInt32(idImgProd),
        //                name = product.image.name.ToString()
        //            },
        //            price = Convert.ToDouble(product.price)
        //        };
        //        return addedProduct;
        //        //int idChildProduct = (int)insertCommand.ExecuteScalar();
        //        //**/objectsList = brandsList;
        //        //}
        //    }
        //}

        //public static int insertProdDetailsToDb(SqlConnection sqlConnection, ProductDetails productDetails)
        //{
        //    int idChildProduct;
        //    StringBuilder strBuilder = new StringBuilder();
        //    strBuilder.Append(
        //        "INSERT INTO [Details] " +
        //        "([imageLink], [resolution], [zoomOptic], [video], [stabilisator], [isoMax], [idBrand]) output INSERTED.ID " +
        //        "VALUES ");
        //    //foreach (Category Element in productDetails.)
        //    //{
        //    strBuilder.Append(
        //        $"(N'{productDetails.imageLink.Replace("'", "''")}', " +
        //        $"{productDetails.resolution}, " +
        //        $"{productDetails.zoomOptic}, " +
        //        $"{productDetails.video}, " +
        //        $"{(productDetails.stabilisator ? 1 : 1)}, " +
        //        $"{productDetails.isoMax}, " +
        //        $"{productDetails.productBrandId})");
        //    //}
        //    string insertQuery = strBuilder.ToString();
        //    using (SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection))
        //    {
        //        //if (type == typeof(Brands))
        //        //{

        //        //int numOfAffectedRow = insertCommand.ExecuteNonQuery();
        //        idChildProduct = (int)insertCommand.ExecuteScalar();

        //        //**/objectsList = brandsList;
        //        //}
        //    }
        //    return idChildProduct;
        //}

        //public static List<Product> getAllProducts()
        //{
        //    SqlConnection connection = dbConnection();
        //    string selectCommandString = $"select p.Id, p.name as productName, p.price, d.imageLink, b.name as productBrand, img.name as imageName from Product p inner join Details d on p.productDetailsId = d.Id inner join Brand b on d.idBrand = b.Id inner join Image img on img.Id = p.imageId";
        //    List<Product> productsList = new List<Product>();
        //    ProductDetails prodDetails = new ProductDetails();
        //    using (SqlCommand selectCommand = new SqlCommand(selectCommandString, connection))
        //    {
        //        //if (type == typeof(Brands))
        //        //{
        //        SqlDataReader sqlDataReader = selectCommand.ExecuteReader();
        //        while (sqlDataReader.Read())
        //        {
        //            productsList.Add(new Product
        //            {
        //                id = Convert.ToInt32(sqlDataReader["Id"]),
        //                name = sqlDataReader["productName"].ToString(),
        //                productDetails = new ProductDetails
        //                {
        //                    imageLink = sqlDataReader["imageLink"].ToString(),
        //                    productBrand = new Brand
        //                    {
        //                        name = sqlDataReader["productBrand"].ToString()
        //                    }
        //                },
        //                image = new Image
        //                {
        //                    name = sqlDataReader["imageName"].ToString()
        //                },
        //                price = Convert.ToDouble(sqlDataReader["price"])

        //            });
        //        }
        //        //**/objectsList = brandsList;
        //        //}
        //    }
        //    return productsList;
        //}
    }
}
