using System.Configuration;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Runtime.Remoting.Messaging;
using global::System;
using global::System.Collections.Generic;
using global::System.Data.SqlClient;
using global::System.Linq;
using global::System.Threading.Tasks;
using global::System.Web;
using InventoryManagement.Models;
using Microsoft.Ajax.Utilities;

namespace InventoryManagement.Models
{
    public class AdoInventoryDbContext
    {
        private readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["InventoryDbContext"].ConnectionString;

        //CRUD for Category
        public async Task<IEnumerable<Category>> RetrieveAllCategoriesAsync()
        {
            var categories = new List<Category>();
            var connection = new SqlConnection(_connectionString);
            using (connection)
            {
                var cmd = new SqlCommand("spGetAllCategories", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                var sdr = await cmd.ExecuteReaderAsync();
                while (sdr.Read())
                {
                    var category = new Category
                    {
                        Id = (int)sdr["Id"],
                        Name = (string)sdr["Name"],
                        IsActive = (bool)sdr["IsActive"]
                    };
                    categories.Add(category);
                }

                connection.Close();
            }

            return categories;
        }

        public async Task AddCategoryAsync(Category category)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandText = "spAddNewCategory",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };
                cmd.Parameters.AddWithValue("@CategoryName", category.Name);
                cmd.Parameters.AddWithValue("@IsActive", category.IsActive);

                await connection.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = new Category();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spGetCategoryById",
                    Connection = connection
                };

                cmd.Parameters.AddWithValue("@CategoryId", id);
                await connection.OpenAsync();
                var dataReader = await cmd.ExecuteReaderAsync();
                while (await dataReader.ReadAsync())
                {
                    category.Id = (int)dataReader["Id"];
                    category.Name = (string)dataReader["Name"];
                    category.IsActive = (bool)dataReader["IsActive"];
                }
                connection.Close();
            }

            return category;
        }

        public async Task EditCategoryAsync(Category category)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spUpdateCategory",
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@CategoryId", category.Id);
                cmd.Parameters.AddWithValue("@CategoryName", category.Name);
                cmd.Parameters.AddWithValue("@IsActive", category.IsActive);
                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
        }

        public async Task DeleteCategoryFromDbAsync(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandText = "spDeleteCategory",
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };

                cmd.Parameters.AddWithValue("@CategoryId", id);

                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                con.Close();

            }
        }


        //CRUD For Products
        public async Task<IEnumerable<Product>> RetrieveAllProductsAsync()
        {
            var products = new List<Product>();
            var connection = new SqlConnection(_connectionString);
            using (connection)
            {
                var cmd = new SqlCommand("spGetAllProducts", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                var sdr = await cmd.ExecuteReaderAsync();
                while (await sdr.ReadAsync())
                {
                    var product = new Product
                    {
                        Id = (int)sdr["Id"],
                        Name = (string)sdr["Name"],
                        IsActive = (bool)sdr["IsActive"]
                    };
                    products.Add(product);
                }

                connection.Close();
            }

            return products;
        }

        public async Task AddProductAsync(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandText = "spAddNewProduct",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };
                cmd.Parameters.AddWithValue("@ProductName", product.Name);
                cmd.Parameters.AddWithValue("@IsActive", product.IsActive);

                await connection.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = new Product();
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spGetProductById",
                    Connection = connection
                };

                cmd.Parameters.AddWithValue("@ProductId", id);
                await connection.OpenAsync();
                var dataReader = await cmd.ExecuteReaderAsync();
                while (await dataReader.ReadAsync())
                {
                    product.Id = (int)dataReader["Id"];
                    product.Name = (string)dataReader["Name"];
                    product.IsActive = (bool)dataReader["IsActive"];
                }
                connection.Close();
            }

            return product;
        }

        public async Task EditProductAsync(Product product)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spUpdateProduct",
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@ProductId", product.Id);
                cmd.Parameters.AddWithValue("@ProductName", product.Name);
                cmd.Parameters.AddWithValue("@IsActive", product.IsActive);
                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
        }

        public async Task DeleteProductFromDbByIdAsync(int id)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandText = "spDeleteProduct",
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };

                cmd.Parameters.AddWithValue("@ProductId", id);

                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                con.Close();

            }
        }


        //Operations on both products and categories 
        public async Task ActivateCategoryAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var cmdEdit = new SqlCommand()
                {
                    CommandText = "spActivateCategoryById",
                    CommandType = CommandType.StoredProcedure,
                    Connection = connection
                };
                cmdEdit.Parameters.AddWithValue("@CategoryId", id);
                await cmdEdit.ExecuteNonQueryAsync();

                connection.Close();
            }
        }

        public async Task DeActivateCategoryAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spDeActivateCategoryById",
                    Connection = connection
                };
                cmd.Parameters.AddWithValue("@CategoryId", id);
                await connection.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                connection.Close();
            }
        }

        public async Task<IEnumerable<Product>> ProductsListNotInCategoryAsync(int categoryId)
        {
            var products = new List<Product>();
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandText = "spGetAllProductsNotInCategory",
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };

                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                await con.OpenAsync();
                var rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    var newProduct = new Product();
                    newProduct.Id = (int)rdr["Id"];
                    newProduct.Name = (string)rdr["Name"];
                    newProduct.IsActive = (bool)rdr["IsActive"];
                    products.Add(newProduct);
                }
                con.Close();
            }

            return products;
        }

        public async Task AddProductToCategoryAsync(int productId, int categoryId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "spAddProductToCategory",
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.Parameters.AddWithValue("@CategoryId",categoryId);
                cmd.Parameters.AddWithValue("@IsActive", true);
                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
        }

        public async Task<ProductCategories> GetProductCategoryAsync(int categoryId)
        {
            var pc = new ProductCategories();
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandText = "spGetProductCategoryByCategoryIdInJunction",
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                await con.OpenAsync();
                var rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    pc.IsActive = (bool)rdr["IsActive"];
                    pc.CategoryId = (int)rdr["CategoryId"];
                    pc.ProductId = (int)rdr["ProductId"];
                }
                con.Close();
                return pc;
            }
        }

        public async Task<IEnumerable<Product>> GetAllProductInCategoryAsync(int categoryId)
        {
            var products = new List<Product>();
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandText = "spGetAllProductsByCategories",
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                await con.OpenAsync();
                var rdr = await cmd.ExecuteReaderAsync();
                while (rdr.Read())
                {
                    var product = new Product();
                    product.Id = (int)rdr["pId"];
                    product.Name = (string)rdr["pName"];
                    product.IsActive = (bool)rdr["pIsActive"];
                    products.Add(product);
                }

                con.Close();
            }

            return products;
        }

        public async Task RemoveProductFromCategory(int productId, int categoryId)
        {
            using (var con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand()
                {
                    CommandText = "spDeleteProductFromCategory",
                    CommandType = CommandType.StoredProcedure,
                    Connection = con
                };
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                await con.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
                con.Close();
            }
        }
    }

}
