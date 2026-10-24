using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


public class clsUsers
  {
       public  enum Mode { AddNew = 1, Update }

            public int UserID { get; set; }
           public int PersonID { get; set; }
           public string UserName { get; set; }
          public string Password { get; set; }
         public bool IsActive { get; set; }
             public Mode _Mode = Mode.AddNew;
              
       public clsUsers()
       {
        this.UserID = -1;
        this.PersonID = -1;
        this.UserName = "";
        this.Password = "";
        this.IsActive = false;
        this._Mode = Mode.AddNew;
 
       }


    public bool _AddNewUser()
    {
        this.UserID = clsUsersDAL.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);
        return (this.UserID != -1);
    }

    private bool _UpdateUser()
    {
        return clsUsersDAL.UpdateUser(this.UserID,this.PersonID,this.UserName,this.Password, this.IsActive);
    }
    private clsUsers(int UserID,int PersonID, string UserName, string Password, bool IsActive )
    {

        this.UserID=UserID;
        this.PersonID = PersonID;
        this.UserName=UserName;
        this.Password=Password;
        this.IsActive=IsActive;
        _Mode = Mode.Update;
    }


     public static clsUsers FindByUserName(string UserName)
    {

        int PersonID = -1;
        int UserID = -1;
       
        string Password = "";
        bool IsActive = false;

        if(clsUsersDAL.GetUserByName( ref UserID, ref PersonID, UserName,ref  Password, ref IsActive))
        {
            return new clsUsers(UserID,PersonID,UserName,Password,IsActive);
        }
        else
        {
            return null;
        }

    }

    public static clsUsers Find(int UserID)
    {

        int PersonID = -1;
        string UserName="";
        string Password = "";
        bool IsActive = false;

        if(clsUsersDAL.GetUserByID( UserID, ref PersonID, ref UserName,ref  Password, ref IsActive))
        {
            return new clsUsers(UserID,PersonID,UserName,Password,IsActive);
        }
        else
        {
            return null;
        }

    }

    public static bool IsUserExist(int UserId)
    {
        return clsUsersDAL.IsUserByUserIDExist(UserId);
    }
     public static bool CheckUserExistForLogin(string UserName,string PassWord)
    { 

    
        return clsUsersDAL.IsUserByUserNameAndPasswordExistForLogin(UserName,PassWord);
    }

     public static bool DeleteUser(int UserId)
    {
        return clsUsersDAL.DeleteUserByID(UserId);
    }

    public static DataTable AllUsers()
    {
        return clsUsersDAL.GetAllUsers();
    }
    public bool Save()
    {
        switch (_Mode)
        {
            case Mode.AddNew:
                if (_AddNewUser())
                {
                    _Mode = Mode.Update;
                    return true;

                }
                else
                {
                    return false;

                }
                break;
            case Mode.Update:

                this._Mode = Mode.Update;
                 return _UpdateUser();

                break;
            default:
                break;
        }

        return false;
    }
}  

