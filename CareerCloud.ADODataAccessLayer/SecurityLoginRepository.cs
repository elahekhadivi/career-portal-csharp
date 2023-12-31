﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityLoginRepository : BaseADORepository<SecurityLoginPoco>, IDataRepository<SecurityLoginPoco>
    {
        public void Add(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginPoco item in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Logins]
                                           ([Id]
                                           ,[Login]
                                           ,[Password]
                                           ,[Created_Date]
                                           ,[Password_Update_Date]
                                           ,[Agreement_Accepted_Date]
                                           ,[Is_Locked]
                                           ,[Is_Inactive]
                                           ,[Email_Address]
                                           ,[Phone_Number]
                                           ,[Full_Name]
                                           ,[Force_Change_Password]
                                           ,[Prefferred_Language])
                                     VALUES
                                           (@Id
                                           ,@Login
                                           ,@Password
                                           ,@Created_Date
                                           ,@Password_Update_Date
                                           ,@Agreement_Accepted_Date
                                           ,@Is_Locked
                                           ,@Is_Inactive
                                           ,@Email_Address
                                           ,@Phone_Number
                                           ,@Full_Name
                                           ,@Force_Change_Password
                                           ,@Prefferred_Language)";
                    cmd.Parameters.AddWithValue("@Id", item.Id);
                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

  
        public override IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                          ,[Login]
                                          ,[Password]
                                          ,[Created_Date]
                                          ,[Password_Update_Date]
                                          ,[Agreement_Accepted_Date]
                                          ,[Is_Locked]
                                          ,[Is_Inactive]
                                          ,[Email_Address]
                                          ,[Phone_Number]
                                          ,[Full_Name]
                                          ,[Force_Change_Password]
                                          ,[Prefferred_Language]
                                          ,[Time_Stamp]
                                      FROM [dbo].[Security_Logins]";

                conn.Open();

                int x = 0;
                SqlDataReader rdr = cmd.ExecuteReader();
                SecurityLoginPoco[] appPocos = new SecurityLoginPoco[1000];
                while (rdr.Read())
                {
                    SecurityLoginPoco poco = new SecurityLoginPoco();
                    poco.Id = rdr.GetGuid(0);
                    poco.Login = rdr.GetString(1);
                    poco.Password = rdr.GetString(2);
                    poco.Created = rdr.GetDateTime(3);
                    if (!Convert.IsDBNull(rdr[9]))
                    {
                        poco.PasswordUpdate = rdr.GetDateTime(4);
                    }
                    if (!Convert.IsDBNull(rdr[9]))
                    {
                        poco.AgreementAccepted = rdr.GetDateTime(5);
                    }
                    poco.IsLocked = (bool)rdr[6];
                    poco.IsInactive = (bool)rdr[7];
                    poco.EmailAddress = rdr.GetString(8);
                    if (!Convert.IsDBNull(rdr[9]))
                    {
                        poco.PhoneNumber = rdr.GetString(9);
                    }
                    poco.FullName = rdr.GetString(10);
                    poco.ForceChangePassword = (bool)rdr[11];
                    if (!Convert.IsDBNull(rdr[12]))
                    {
                        poco.PrefferredLanguage = rdr.GetString(12);
                    }
                    poco.TimeStamp = (byte[])rdr[13];

                    appPocos[x] = poco;
                    x++;
                }

                return appPocos.Where(a => a != null).ToList();
            }
        }


        public void Update(params SecurityLoginPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityLoginPoco item in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Security_Logins]
                                       SET [Login] = @Login
                                          ,[Password] = @Password
                                          ,[Created_Date] = @Created_Date
                                          ,[Password_Update_Date] = @Password_Update_Date
                                          ,[Agreement_Accepted_Date] = @Agreement_Accepted_Date
                                          ,[Is_Locked] = @Is_Locked
                                          ,[Is_Inactive] = @Is_Inactive
                                          ,[Email_Address] = @Email_Address
                                          ,[Phone_Number] = @Phone_Number
                                          ,[Full_Name] = @Full_Name
                                          ,[Force_Change_Password] = @Force_Change_Password
                                          ,[Prefferred_Language] = @Prefferred_Language
                                      WHERE [Id] = @Id";

                    cmd.Parameters.AddWithValue("@Login", item.Login);
                    cmd.Parameters.AddWithValue("@Password", item.Password);
                    cmd.Parameters.AddWithValue("@Created_Date", item.Created);
                    cmd.Parameters.AddWithValue("@Password_Update_Date", item.PasswordUpdate);
                    cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", item.AgreementAccepted);
                    cmd.Parameters.AddWithValue("@Is_Locked", item.IsLocked);
                    cmd.Parameters.AddWithValue("@Is_Inactive", item.IsInactive);
                    cmd.Parameters.AddWithValue("@Email_Address", item.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone_Number", item.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Full_Name", item.FullName);
                    cmd.Parameters.AddWithValue("@Force_Change_Password", item.ForceChangePassword);
                    cmd.Parameters.AddWithValue("@Prefferred_Language", item.PrefferredLanguage);
                    cmd.Parameters.AddWithValue("@Id", item.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
