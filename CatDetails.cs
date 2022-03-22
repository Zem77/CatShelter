using System ;
using System.Data.SqlClient ;

namespace CatShelter {

    class CatDetails {

        #region Cat Properties

            public int cId { get; set; }

            public string cName { get; set; }

            public string cColor { get; set; }

            public int cAge { get; set; }

            public int cWeight { get; set; }

            public string cGender { get; set; }

            public string cHeight { get; set; }


        #endregion

        SqlConnection con = new SqlConnection(@"server=LAPTOP-LS52TP6C\TRAINEDINSTANCE;database=catDB;integrated security=true;") ;

        //#region Cat Functions

        public string addNewEntry(CatDetails newCat) {

            SqlCommand cmd_addCatEntry = new SqlCommand("insert into CatDetails values(@cName,@cColor,@cAge,@cWeight,@cGender,@cHeight)", con) ;
            //cmd_addCatEntry.Parameters.AddWithValue("@cId", newCat.cId) ;
            cmd_addCatEntry.Parameters.AddWithValue("@cName", newCat.cName) ;
            cmd_addCatEntry.Parameters.AddWithValue("@cColor", newCat.cColor) ;
            cmd_addCatEntry.Parameters.AddWithValue("@cAge", newCat.cAge) ;
            cmd_addCatEntry.Parameters.AddWithValue("@cWeight", newCat.cWeight) ;
            cmd_addCatEntry.Parameters.AddWithValue("@cGender", newCat.cGender) ;
            cmd_addCatEntry.Parameters.AddWithValue("@cHeight", newCat.cHeight) ;

            try {
                con.Open() ;
                cmd_addCatEntry.ExecuteNonQuery() ;
            } catch(SqlException ex) {
                System.Console.WriteLine(ex.Message) ;
            } finally {
                con.Close() ;
            }
            

            return "Cat Added Succesfully" ;

        }

        public string deleteCatEntry(int id) {
            SqlCommand cmd_deleteCatEntry = new SqlCommand("delete from CatDetails where cId=@cId", con) ;
            cmd_deleteCatEntry.Parameters.AddWithValue("@cid", id) ;
            try {
                con.Open() ;
                cmd_deleteCatEntry.ExecuteNonQuery() ;
            } catch(System.Exception ex) {
                System.Console.WriteLine(ex.Message) ;
            } finally {
                con.Close() ;
            }

            return "Cat entry deleted" ;
        }


        public string editEntry(CatDetails catDetails) {

             SqlCommand cmd_update = new SqlCommand("update CatDetails set cAge = @newcAge, cWeight = @newcWeight where cId = @cId",con) ;
             cmd_update.Parameters.AddWithValue("@newcAge", catDetails.cAge) ;
             cmd_update.Parameters.AddWithValue("@newcWeight", catDetails.cWeight) ;
             cmd_update.Parameters.AddWithValue("@cId", catDetails.cId) ;

             try {
                 con.Open() ;
                 cmd_update.ExecuteNonQuery() ;
             } catch(System.Exception ex) {
                 System.Console.WriteLine(ex.Message) ;
             } finally {
                 con.Close() ;
             }

             return "Cat Entry updated" ;
        }


        public CatDetails getCatEntryById(int id) {
            CatDetails cd = null ;
            SqlCommand cmd_search = new SqlCommand("select * from catdetails where cId = @cId", con) ;
            cmd_search.Parameters.AddWithValue("@cId", id) ;
            SqlDataReader _read ;
            try {
                con.Open() ;
                _read = cmd_search.ExecuteReader() ;

                _read.Read() ;
                
                if(_read.Read()) {
                    cd.cId = id ;
                    cd.cName = Convert.ToString(_read[1]) ;
                    cd.cColor = Convert.ToString(_read[2]) ;
                    cd.cAge = Convert.ToInt32(_read[3]) ;
                    cd.cWeight = Convert.ToInt32(_read[4]) ;
                    cd.cGender = Convert.ToString(_read[5]) ;
                    cd.cHeight = Convert.ToString(_read[6]) ;

                    return cd ;
                }
                
            } catch (System.Exception ex) {
                System.Console.WriteLine(ex.Message) ;
            } finally {
                con.Close() ;
            }
            return cd ;
        }



        //#endregion

        //outside region

    }


}