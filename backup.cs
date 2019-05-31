// try
// {
//     SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
//     builder.DataSource = "eecs113-final.database.windows.net";
//     builder.UserID = "kd";
//     builder.Password = "116$I!1737LyF^YGxx5";
//     builder.InitialCatalog = "eecs113-final-db";

//     using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
//     {
//         connection.Open();
//         StringBuilder sb = new StringBuilder();
//         sb.Append("SELECT T.phlid, T.email ");
//         sb.Append("FROM Test T ");
//         String sql = sb.ToString();

//         using (SqlCommand command = new SqlCommand(sql, connection))
//         {
//             using (SqlDataReader reader = command.ExecuteReader())
//             {
//                 while (reader.Read())
//                 {
//                     await context.Response.WriteAsync($"{reader.GetString(0)} {reader.GetString(1)}\n");
//                 }
//             }
//         }
//     }
// }
// catch (SqlException e)
// {
//     await context.Response.WriteAsync(e.ToString());
// }