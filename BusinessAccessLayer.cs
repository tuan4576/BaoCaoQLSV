using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSinhVien
{
    //
    public class BusinessAccessLayer
    {
        private DatabaseHelper dbHelper;

        public BusinessAccessLayer()
        {
            dbHelper = new DatabaseHelper();
        }

        public bool Login(string studentCode, string password, out int roleId)
        {
            int? result = dbHelper.CheckLogin(studentCode, password);
            if (result != null)
            {
                roleId = result.Value;
                return true;
            }
            else
            {
                roleId = 0;
                return false;
            }
        }

        public MySqlDataReader GetAllCustomers()
        {
            return dbHelper.GetCustomerData();
        }
    }
}
