using System.Security.Cryptography;
using System.Text;

namespace StudioGhibliMovieMaker.BusinessObjects.Encryption
{
    public class PasswordEncryption
    {
        public PasswordEncryption()
        {

        }

        public string GenerateSalt(int byteSize)
        {
            byte[] bytes = new byte[byteSize];
            RandomNumberGenerator randomNumber = RandomNumberGenerator.Create();

            randomNumber.GetBytes(bytes);
            string salt = Convert.ToBase64String(bytes);

            return salt;
        }

        public string GeneratePasswordHash(string password, string salt)
        {
            byte[] passSaltBytes = Encoding.UTF8.GetBytes(password + salt);
            SHA256 sHA256 = SHA256.Create();

            byte[] hash = sHA256.ComputeHash(passSaltBytes);
            return Convert.ToBase64String(hash);
        }

        public bool ComparePassword(string plainTextPassword, string hashedPassword, string salt)
        {
            string hashConvert = GeneratePasswordHash(plainTextPassword, salt);

            return hashConvert.Equals(hashedPassword);
        }
    }
}
