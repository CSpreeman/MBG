using MITM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MITM.Services
{
    public class BlogService
    {

        public static List<Blog> GetBlogs()
        {
            List<Blog> blogList = new List<Blog>();
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Blog_GetAll", sqlConn))
                {
                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        int i = 0;

                        Blog b = new Blog();
                        b.Id = reader.GetInt32(i++);
                        b.Category = reader.GetString(i++);
                        b.Title = reader.GetString(i++);
                        b.Description = reader.GetString(i++);
                        b.ImageLocation = reader.GetString(i++);
                        b.CreatedDate = reader.GetDateTime(i++);
                        if (reader[i] == DBNull.Value)
                        {
                            b.ModifiedDate = null;
                        }
                        else
                        {
                            b.ModifiedDate = reader.GetDateTime(i++);
                        }

                        blogList.Add(b);
                    }
                }
            }
            return blogList;
        }

        public static Blog GetBlogById(int id)
        {
            Blog Blog = new Blog();
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Blog_GetById", sqlConn))
                {
                    sqlConn.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        int i = 0;

                        Blog b = new Blog();
                        b.Id = reader.GetInt32(i++);
                        b.Category = reader.GetString(i++);
                        b.Title = reader.GetString(i++);
                        b.Description = reader.GetString(i++);
                        b.ImageLocation = reader.GetString(i++);
                        b.CreatedDate = reader.GetDateTime(i++);
                        if (reader[i] == DBNull.Value)
                        {
                            b.ModifiedDate = null;
                        }
                        else
                        {
                            b.ModifiedDate = reader.GetDateTime(i++);
                        }

                        Blog = b;
                    }
                }
            }
            return Blog;
        }

        public static int PostSession(Blog payload)
        {
            int Id = 0;

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Blog_Post", sqlConn))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Category", payload.Category);
                    cmd.Parameters.AddWithValue("@Title", payload.Title);
                    cmd.Parameters.AddWithValue("@Description", payload.Description);
                    cmd.Parameters.AddWithValue("@ImageLocation", payload.ImageLocation);

                    SqlParameter outPut = cmd.Parameters.Add("@ID", SqlDbType.Int);
                    outPut.Direction = ParameterDirection.Output;

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();

                    Id = Convert.ToInt32(outPut.Value);

                }
                return Id;
            }
        }

        public static void DeleteBlog(int id)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Blog_Delete", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    sqlConn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}