using System;

namespace CatShelter
{
    class Program
    {
        static void Main(string[] args)
        {
            CatDetails catDetails = new CatDetails() ;
            
            bool continuteInTerminal = true ;
            bool isLoggedIn = false;

            if (isLoggedIn == false) {
                System.Console.WriteLine("Enter Your User Name");
                string username = Console.ReadLine();
                System.Console.WriteLine("Enter Your Password");
                string password = Console.ReadLine();
                Security sObj = new Security();
                
                bool loginResult = sObj.Login(username,password);
                if(loginResult == false) {   
                        System.Console.WriteLine("Invalid Credentials");
                } else {

                    isLoggedIn = true;

            
                    while(continuteInTerminal) {
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~") ;
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~") ;
                        Console.WriteLine("~~~~~~~~  Welcome to the Cat Shelter  ~~~~~~~~") ;
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~") ;
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~") ;
                        Console.WriteLine("1. Create New Cat Entry") ;
                        Console.WriteLine("2. Edit Previous Entry") ;
                        Console.WriteLine("3. Check Details") ;
                        Console.WriteLine("4. Delete An Entry") ;
                        Console.WriteLine("5. Logout of Terminal") ;
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~") ;
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~") ;
                        Console.WriteLine("~~~~~~~~   Please Select An Option   ~~~~~~~~") ;
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~") ;
                        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~") ;
                        int choice = Convert.ToInt32(Console.ReadLine()) ; 


                        switch(choice) {
                            case 1:
                                #region Add new cat entry
                                System.Console.WriteLine("Enter The Cats Name") ;
                                string cName = Console.ReadLine() ;
                                #region comments      
                                //bool a = false ;                              
                                // if(a == false) {
                                //     try {
                                //     //cName = Console.ReadLine() ;                                    
                                // } catch(Exception ex) {
                                //     System.Console.WriteLine(ex.Message) ;
                                //     a = true ;
                                // }
                                // }
                                // if(a == true) {
                                //     System.Console.WriteLine("Enter Valid name") ;
                                //     cName = Console.ReadLine() ;
                                // } else {
                                //     a = false ;
                                // }
                                #endregion

                                System.Console.WriteLine("Enter The Cats Color") ;
                                string cColor = Console.ReadLine() ;
                                System.Console.WriteLine("Enter The Cats Age") ;
                                string cAge = Console.ReadLine() ;
                                System.Console.WriteLine("Enter The Cats Weight") ;
                                string cWeight = Console.ReadLine() ;
                                System.Console.WriteLine("Enter The Cats Gender") ;
                                string cGender = Console.ReadLine() ;
                                System.Console.WriteLine("Enter The Cats Height") ;
                                string cHeight = Console.ReadLine() ;
                    

                                CatDetails newCat = new CatDetails() ;
                                newCat.cName = cName ;
                                newCat.cColor = cColor ;
                                newCat.cAge = cAge ;
                                newCat.cWeight = cWeight ;
                                newCat.cGender = cGender ;
                                newCat.cHeight = cHeight ;

                                System.Console.WriteLine(catDetails.addNewEntry(newCat)) ;

                                #endregion
                                break ;
                            case 2:
                                #region Edit cat entry with ID
                                System.Console.WriteLine("Enter Cat Id") ;
                                int id = Convert.ToInt32(Console.ReadLine()) ;
                                System.Console.WriteLine("Enter The Cats Age") ;
                                string cAge2 = Console.ReadLine() ;
                                System.Console.WriteLine("Enter The Cats Weight") ;
                                string cWeight2 = Console.ReadLine() ;
                                

                                CatDetails catChanges = new CatDetails() ;
                                catChanges.cAge = cAge2 ;
                                catChanges.cWeight = cWeight2 ;
                                catChanges.cId = id ;

                                System.Console.WriteLine(catDetails.editEntry(catChanges)) ; 
                                #endregion               
                                break ;
                            case 3:
                                #region Check entry details
                                System.Console.WriteLine("Enter cat id to check the entry") ;
                                int cid2 = Convert.ToInt32(Console.ReadLine()) ;
                                CatDetails cd = catDetails.getCatEntryById(cid2) ;
                                System.Console.WriteLine("Cat entry ID " + cd.cId) ;
                                System.Console.WriteLine("Cat entry name " + cd.cName) ;
                                System.Console.WriteLine("Cat entry color " + cd.cColor) ;
                                System.Console.WriteLine("Cat entry age " + cd.cAge) ;
                                System.Console.WriteLine("Cat entry weight " + cd.cWeight) ;
                                System.Console.WriteLine("Cat entry gender " + cd.cGender) ;
                                System.Console.WriteLine("Cat entry height " + cd.cHeight) ;

                                #endregion
                                break ;
                            case 4:
                                #region Delete entry
                                System.Console.WriteLine("Enter Entry Id to delete the entry") ;
                                int cid = Convert.ToInt32(Console.ReadLine()) ;

                                System.Console.WriteLine(catDetails.deleteCatEntry(cid)) ;

                                #endregion
                                break ;
                            case 5:
                                continuteInTerminal = false ;
                                Console.WriteLine("Thank You For Your Input!") ;
                                Console.WriteLine() ;
                                Console.WriteLine() ;

                                break ;

                            default:
                                Console.WriteLine("Please Enter A Correct Choice.") ;
                                break ;
                        }
                    }
                }//
            }//

        } //main method
    } //class
} //namespace
