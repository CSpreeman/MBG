using MITM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MITM.Services
{
    public class CommentService
    {

        public static List<Comment> GetAllComments()
        {
            List<Comment> commentList = new List<Comment>();
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Select_AllComments", sqlConn))
                {
                    sqlConn.Open();

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        int i = 0;

                        Comment c = new Comment();
                        c.ID = reader.GetInt32(i++);
                        c.BlogId = reader.GetInt32(i++);
                        c.Name = reader.GetString(i++);
                        c.Subject = reader.GetString(i++);
                        c.Message = reader.GetString(i++);
                        c.DateCreated = reader.GetDateTime(i++);
                        if (reader[i] == DBNull.Value)
                        {
                            c.ParentCommentId = null;
                        }
                        else
                        {
                            c.ParentCommentId = reader.GetInt32(i++);
                        }

                        commentList.Add(c);
                    }
                }
            }
            return commentList;
        }

        public static List<Comment> GetCommentByBlogId(int id)
        {
            List<Comment> commentList = new List<Comment>();
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Select_CommentsByBlogId", sqlConn))
                {
                    sqlConn.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        int i = 0;

                        Comment c = new Comment();
                        c.ID = reader.GetInt32(i++);
                        c.BlogId = reader.GetInt32(i++);
                        c.Name = reader.GetString(i++);
                        c.Subject = reader.GetString(i++);
                        c.Message = reader.GetString(i++);
                        c.DateCreated = reader.GetDateTime(i++);
                        if (reader[i] == DBNull.Value)
                        {
                            c.ParentCommentId = null;
                        }
                        else
                        {
                            c.ParentCommentId = reader.GetInt32(i++);
                        }

                        commentList.Add(c);
                    }
                }
            }
            return commentList;
        }

        public static int PostComment(Comment payload)
        {
            int Id = 0;

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Comment_Insert", sqlConn))
                {

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BlogId", payload.BlogId);
                    cmd.Parameters.AddWithValue("@Name", payload.Name);
                    cmd.Parameters.AddWithValue("@Subject", payload.Subject);
                    cmd.Parameters.AddWithValue("@Message", payload.Message);
                    if (payload.ParentCommentId == null)
                    {
                        cmd.Parameters.AddWithValue("@ParentCommentId", DBNull.Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ParentCommentId", payload.ParentCommentId);
                    }

                    SqlParameter outPut = cmd.Parameters.Add("@ID", SqlDbType.Int);
                    outPut.Direction = ParameterDirection.Output;

                    sqlConn.Open();
                    cmd.ExecuteNonQuery();

                    Id = Convert.ToInt32(outPut.Value);

                }
                return Id;
            }
        }

        public static void deleteComment(int id)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("Comment_Delete", sqlConn))
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