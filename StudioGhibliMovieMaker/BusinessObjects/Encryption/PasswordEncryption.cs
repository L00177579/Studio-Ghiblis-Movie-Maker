using System.Security.Cryptography;
using System.Text;

namespace StudioGhibliMovieMaker.BusinessObjects.Encryption
{
    public class PasswordEncryption
    {
        public PasswordEncryption()
        {

        }

        /// <summary>
        /// Generate a salt as a Base64String.
        /// <para><paramref name="byteSize"/> refers to the size of the byte array that will be filled by the random number generator.</para>
        /// </summary>
        /// /// <param name="byteSize">The size of the byte array.</param>
        public string GenerateSalt(int byteSize)
        {
            byte[] bytes = new byte[byteSize];
            RandomNumberGenerator randomNumber = RandomNumberGenerator.Create();

            randomNumber.GetBytes(bytes);
            string salt = Convert.ToBase64String(bytes);

            return salt;
        }

        /// <summary>
        /// Generates a hash of a plain text password using SHA256 encryption and a supplied salt.
        /// <para><paramref name="password"/> is the users plain text password that will be hashed using the passed in salt.</para>
        /// <para><paramref name="salt"/> is the salt that will be used to hash the plaintext password.</para>
        /// </summary>
        /// <param name="password">The plain text password.</param>
        /// <param name="salt">The salt.</param>
        public string GeneratePasswordHash(string password, string salt)
        {
            byte[] passSaltBytes = Encoding.UTF8.GetBytes(password + salt);
            SHA256 sHA256 = SHA256.Create();

            byte[] hash = sHA256.ComputeHash(passSaltBytes);
            return Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Compares a plaintext password and a hashed password using the salt.
        /// <para><paramref name="plainTextPassword"/> is the users plain text password that will be hashed using the passed in salt.</para>
        /// <para><paramref name="hashedPassword"/> is the pre-hashed password.</para>
        /// <para><paramref name="salt"/> is the salt that will be used to hash the plaintext password</para>
        /// </summary>
        /// <param name="plainTextPassword">The plain text password.</param>
        /// <param name="hashedPassword">The hashed password.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>True if the plain text password when hashed is equivalent to the supplied hashed password. False otherwise.</returns>
        public bool ComparePassword(string plainTextPassword, string hashedPassword, string salt)
        {
            string hashConvert = GeneratePasswordHash(plainTextPassword, salt);

            return hashConvert.Equals(hashedPassword);
        }
    }
}
