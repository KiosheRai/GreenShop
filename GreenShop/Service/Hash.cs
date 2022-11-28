using System.Text;
using System.Security.Cryptography;

namespace GreenShop.Service
{
    public class Hash
    {
        public static string Generate(string str)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(str));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
