using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.ComponentModel;
using System.Data.SqlClient;
using Garouqqqbot.Model;
using MySql.Data.MySqlClient;
using System.Drawing;
using Garouqqqbot.InterFace;

namespace Garouqqqbot.Controller
{
	public static class ControllerDB
	{
		public static string connectionString = Config.DBPath;
		public async static Task<bool> InsertUser(UserModel user)
		{
			string zaproc;
			bool result = false;
			await Task.Run(async () =>
			{
				try
				{
					using (SqlConnection conn = new SqlConnection())
					{
						conn.ConnectionString = connectionString;
						conn.Open();
						zaproc = "dbo.insertUser";
						SqlCommand cmd = new SqlCommand(zaproc);
						cmd.CommandTimeout = 60000;
						cmd.Connection = conn;
						cmd.CommandType = System.Data.CommandType.StoredProcedure;
						cmd.Parameters.AddWithValue("@UserId", user.UserId);
						cmd.Parameters.AddWithValue("@UserName", user.UserName);
						cmd.Parameters.AddWithValue("@FerstName", user.FerstName);
						cmd.Parameters.AddWithValue("@UserLang", user.UserLang);
						cmd.ExecuteNonQuery();
						result = true;
					}
				}
				catch (Exception ex)
				{

					await Logs.Erorr($"{ex.Message},{ex.StackTrace}");

				}
			});

			return result;
		}
		public static async Task UpdateUserLocalization(byte lang, long UserId)
		{
			try
			{
				await Task.Run(() =>
				{
					using (SqlConnection conn = new SqlConnection())
					{
						conn.ConnectionString = connectionString;
						conn.Open();
						string queryString = $"UPDATE TelegramBotGarouqqqBot.dbo.[User] SET User_Lang  =  {lang} Where UserId = {UserId} ";
						using (SqlCommand com = new SqlCommand(queryString, conn))
						{
							com.ExecuteNonQuery();
						}

					}

				});
			}
			catch (Exception ex)
			{
				await Logs.Erorr($"{ex.Message},{ex.StackTrace}");
			}
			

		}
		public static async Task<UserModel> GetUserById(long userId)
		{
			UserModel model = new UserModel();
			try
			{
				await Task.Run(() =>
				{
					using (SqlConnection conn = new SqlConnection())
					{

						conn.ConnectionString = connectionString;
						conn.Open();
						string queryString = $"select * from [User] Where UserId = {userId}";
						SqlCommand cmd = new SqlCommand(queryString);
						cmd.CommandTimeout = 60000;
						cmd.Connection = conn;


						using (SqlDataReader a = cmd.ExecuteReader())
						{
							while (a.Read())
							{
								model.UserId = a.GetInt64(0);
								model.UserName = a.GetString(1);
								model.LastName = a.IsDBNull(2) ? "" : a.GetString(2);
								model.FerstName = a.IsDBNull(3) ? "" : a.GetString(3);
								model.UserLang = a.IsDBNull(4) ? Localization.ru : (Localization)a.GetInt32(4);
							}

						}
					}

				});

			}
			catch (Exception ex)
			{
				await Logs.Erorr($"{ex.Message},{ex.StackTrace}");
			}
			return model;
		}
		public static async Task<List<UserModel>> GetUser()
		{
			List<UserModel> models = new List<UserModel>();
			try
			{
				await Task.Run(() =>
				{
					using (SqlConnection conn = new SqlConnection())
					{

						conn.ConnectionString = connectionString;
						conn.Open();
						string queryString = $"Select UserId,UserName,LastName,FerstName,User_Lang from TelegramBotGarouqqqBot.dbo.[User]";
						SqlCommand cmd = new SqlCommand(queryString);
						cmd.CommandTimeout = 60000;
						cmd.Connection = conn;


						using (SqlDataReader a = cmd.ExecuteReader())
						{
							while (a.Read())
							{
								UserModel model = new UserModel();
								model.UserId = a.GetInt64(0);
								model.UserName = a.GetString(1);
								model.LastName = a.IsDBNull(2) ? "" : a.GetString(2);
								model.FerstName = a.IsDBNull(3) ? "" : a.GetString(3);
								model.UserLang = a.IsDBNull(4) ? Localization.ru : (Localization)a.GetInt32(4);
								models.Add(model);
							}

						}
					}

				});

			}
			catch (Exception ex)
			{
				await Logs.Erorr($"{ex.Message},{ex.StackTrace}");
			}
			return models;
		}
	}
}
