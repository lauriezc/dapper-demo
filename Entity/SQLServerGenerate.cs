﻿

/// <summary>
/// Generated by T4 Template.DO NOT EDIT!
/// </summmary>
namespace Entity.test 
{
	using System;
	using System.Configuration;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using Dapper;
	
	public class Pager
	{
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
		public int Total { get; set; }
		public int PageCount { get { return (int)Math.Ceiling((double)Total/(double)PageSize); } }
		public object Data { get; set; }
	}
	public class all_t
	{
		#region property
		public int id { get; set; }
		public string name { get; set; }
		#endregion property
		
	}
	public static class all_tExten
	{
		private static string _connectionString = ConfigurationManager.ConnectionStrings["test"].ToString();
		
		public static all_t GetModel(string where, string orderByField)
		{
			string sql = string.Format("SELECT * FROM [dbo].[all_t] WHERE {0} ORDER BY {1};", where, orderByField);		
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					return con.QueryFirst<all_t>(sql);
				}
				catch(Exception e)
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return null;
				}
			}
		}
		
		public static List<all_t> GetList(string where)
		{
			string sql = string.Format("SELECT * FROM [dbo].[all_t] WHERE {0};", where);		
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					return con.Query<all_t>(sql).AsList<all_t>();
				}
				catch(Exception e)
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return null;
				}
			}
		}

		public static Pager GetPageList(int pageIndex, int pageSize, string where="1=1", string orderField="id DESC")
		{
			string sql=string.Format("SELECT TOP {0} * FROM [dbo].[all_t] WHERE {1} AND id NOT IN (SELECT TOP {2} id FROM [dbo].[all_t] WHERE {1}) ORDER BY {3};", pageSize, where, (pageIndex-1)*pageSize, orderField);
			string countSql=string.Format("SELECT COUNT(0) FROM [dbo].[all_t] WHERE {0};", where);
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					var count = con.ExecuteScalar<int>(countSql);
					var list = con.Query<all_t>(sql).AsList<all_t>();
					return new Pager()
					{
						PageIndex = pageIndex,
						PageSize = pageSize,
						Total = count,
						Data = list
					};
				}
				catch(Exception e)
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return null;
				}
			}
		}
    }
	public class t
	{
		#region property
		public int id { get; set; }
		public string name { get; set; }
		public Nullable<DateTime> Time { get; set; }
		#endregion property
		
	}
	public static class tExten
	{
		private static string _connectionString = ConfigurationManager.ConnectionStrings["test"].ToString();

		public static int Insert(this t entity)
		{
			string sql="INSERT INTO [dbo].[t] (name,Time)VALUES(@name,@Time);";
			DynamicParameters para =new DynamicParameters();
				para.Add("@name", entity.name);
				para.Add("@Time", entity.Time);
							
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					return con.Execute(sql, para);
				}
				catch(Exception e)
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return -1;
				}
			}
		}

		public static int Insert(this List<t> list)
		{
			string sql="INSERT INTO [dbo].[t] (name,Time)VALUES(@name,@Time);";
			DynamicParameters[] para =new DynamicParameters[list.Count];
			for(var p =0;p < para.Length; p++)
			{
				para[p]=new DynamicParameters();
					para[p].Add("@name", list[p].name);
					para[p].Add("@Time", list[p].Time);
			
			}				
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					return con.Execute(sql, para);
				}
				catch(Exception e)
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return -1;
				}
			}
		}


		public static int Update(this t entity)
		{
			string sql="UPDATE [dbo].[t] SET name=@name,Time=@Time WHERE id=@id;";
			DynamicParameters para =new DynamicParameters();
				para.Add("@name", entity.name);
				para.Add("@Time", entity.Time);
		
			para.Add("@id", entity.id);	
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					return con.Execute(sql, para);
				}
				catch
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return -1;
				}
			}
		}

		public static int Delete(this t entity)
		{
			string sql="DELETE FROM [dbo].[t] WHERE id=@id;";
			DynamicParameters para =new DynamicParameters();
			para.Add("@id", entity.id);	
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					return con.Execute(sql, para);
				}
				catch
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return -1;
				}
			}
		}

		public static int Update(this List<t> list)
		{
			string sql="UPDATE [dbo].[t] SET name=@name,Time=@Time WHERE id=@id;";
			DynamicParameters[] para =new DynamicParameters[list.Count];
			for(var p =0;p < para.Length; p++)
			{
				para[p]=new DynamicParameters();
				para[p].Add("@name", list[p].name);
				para[p].Add("@Time", list[p].Time);
			
				para[p].Add("@id", list[p].id);
			}				
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					return con.Execute(sql, para);
				}
				catch(Exception e)
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return -1;
				}
			}
		}

		public static int Delete(this List<t> list)
		{
			string sql="DELETE FROM [dbo].[t] WHERE id=@id;";
			DynamicParameters[] para =new DynamicParameters[list.Count];
			for(var p =0;p < para.Length; p++)
			{
				para[p]=new DynamicParameters();
				para[p].Add("@id", list[p].id);
			}				
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					return con.Execute(sql, para);
				}
				catch(Exception e)
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return -1;
				}
			}
		}

		
		public static int Delete(int[] primaryKeyArray)
		{
			string sql="DELETE FROM [dbo].[t] WHERE id=@id;";
			DynamicParameters[] para =new DynamicParameters[primaryKeyArray.Length];
			for(var p =0;p < para.Length; p++)
			{
				para[p]=new DynamicParameters();
				para[p].Add("@id", primaryKeyArray[p]);
			}				
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					return con.Execute(sql, para);
				}
				catch(Exception e)
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return -1;
				}
			}
		}

		public static int Delete(int primaryKey)
		{
			string sql="DELETE FROM [dbo].[t] WHERE id=@id;";
			DynamicParameters para =new DynamicParameters();
		    para.Add("@id", primaryKey);
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					return con.Execute(sql, para);
				}
				catch(Exception e)
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return -1;
				}
			}
		}


		public static t GetModel(object primaryKey)
		{
			string sql = string.Format("SELECT * FROM [dbo].[t] WHERE id=@id;");		
			DynamicParameters para =new DynamicParameters();
		    para.Add("@id", primaryKey);
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					return con.QueryFirst<t>(sql, para);
				}
				catch(Exception e)
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return null;
				}
			}
		}
		
		public static t GetModel(string where, string orderByField)
		{
			string sql = string.Format("SELECT * FROM [dbo].[t] WHERE {0} ORDER BY {1};", where, orderByField);		
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					return con.QueryFirst<t>(sql);
				}
				catch(Exception e)
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return null;
				}
			}
		}
		
		public static List<t> GetList(string where)
		{
			string sql = string.Format("SELECT * FROM [dbo].[t] WHERE {0};", where);		
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					return con.Query<t>(sql).AsList<t>();
				}
				catch(Exception e)
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return null;
				}
			}
		}

		public static Pager GetPageList(int pageIndex, int pageSize, string where="1=1", string orderField="id DESC")
		{
			string sql=string.Format("SELECT TOP {0} * FROM [dbo].[t] WHERE {1} AND id NOT IN (SELECT TOP {2} id FROM [dbo].[t] WHERE {1}) ORDER BY {3};", pageSize, where, (pageIndex-1)*pageSize, orderField);
			string countSql=string.Format("SELECT COUNT(0) FROM [dbo].[t] WHERE {0};", where);
			using(var con = new SqlConnection(_connectionString))
			{
				try {
					var count = con.ExecuteScalar<int>(countSql);
					var list = con.Query<t>(sql).AsList<t>();
					return new Pager()
					{
						PageIndex = pageIndex,
						PageSize = pageSize,
						Total = count,
						Data = list
					};
				}
				catch(Exception e)
				{
					if(con.State != ConnectionState.Closed)
					{
						con.Close();
					}
					return null;
				}
			}
		}
    }
}


