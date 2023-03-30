using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Practicle7
{
    //Solid principle demo
    //SRP demo(Single Responsibility Principle)
    //class have only one reason to change.
    //I take senario of E-commerce site for perform SRP demo.where E-commrce site have muliple classes
    //and that classes have multiple responsibities,
    //but one class always responsible for handle one type responsibility.

    
    //Validate_Data class is used to validate user inserted data in signup and signin form.
    //according that validate_info() overloaded method called and that method passed comaands to other related methods.
    internal class ValidateData
    {
        
        public bool ValidateInfo(string UserName, string Password)
        {
            bool Status = false;
            if (UserName!="" && Password!="")
            {
                Status = Login.Login_user(username, Password);

            }
            if (Status)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ValidateInfo(string UserName, string Pass, double Mobile, string Bdate, string Gender)
        {
            bool Status = false;
            if (UserName != "" && Pass != "" && Mobile != null && Bdate != "" && Gender !="")
            {
                Status = Register.RegisterUser(UserName, Pass, Mobile, Bdate, Gender);

            }
            if (Status)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    //Login class which have only responsibility to check user data in db and available then select.
    internal static class Login
    {
        public static bool LoginUser(string UserName, string Pass)
        {
            //code select user data from database
              Console.WriteLine($"Welcome! {UserName}");
               return true;
            
           
            
        }
        
    }

    //Register class which have only responsibility to inseer user data in db it's responible for validate user data.

    internal static class Register
    {
        public static bool RegisterUser(string UserName, string Pass, double Mobile, string Bdate, string Gender)
        {

            //insert user data and register it in to db.
            Console.WriteLine("user register");
            return true;

        }

    }

    
}
