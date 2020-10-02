using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject
{
    public class PasswordActions
    {


        public string PasswordDecryption(byte[] password)
        {
            string decrypted = "";
            for (int i = 0; i < password.Length; i++)
            {
                decrypted += Convert.ToString(Convert.ToChar(password[i]));
            }
            return decrypted;
        }



        public byte[] PasswordEncryption(string decrypted)
        {
            byte[] password = new byte[decrypted.Length];
            for (int i = 0; i <= decrypted.Length - 1; i++)
            {
                password[i] = Convert.ToByte(decrypted[i]);
            }
            return password;
        }

    }
}