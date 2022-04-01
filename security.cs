using System;
using System.Data.SqlClient;

namespace CatShelter
{
    class Security
    {
           public bool Login(string uName,string pwd)
          {
             SqlConnection con = new SqlConnection(@"server=LAPTOP-LS52TP6C\TRAINERSINSTANCE;database=catDB;integrated security=true; User ID=sa; Password=Electricity8*;") ;
             SqlCommand cmd_login = new SqlCommand("select count(*) from loginprompt where cName=@cName and cPassword=@cPassword",con);

             cmd_login.Parameters.AddWithValue("@cName",uName);
             cmd_login.Parameters.AddWithValue("@cPassword",pwd);

             try
             {
                 con.Open();
                 int credential_count =(int) cmd_login.ExecuteScalar();
                 if (credential_count > 0)
                 {
                     return true;
                 }
                 else
                 {
                     return false;
                 }
             }
             catch (System.Exception es)
             {                 
                 throw new Exception(es.Message);
             }
             finally
             {
                 con.Close();
             }
        }
    }
}