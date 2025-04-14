using System.Security.Cryptography;
using System.Text;


namespace RSPGApplication
{
    public static class PasswordHelper
    {
        private const int SaltSize = 16; // Size of the salt in bytes
        private const int HashSize = 20; // Size of the hash in bytes
        private const int Iterations = 10000; // The number of iterations (higher = more secure)

        // Method to hash the password
        public static string HashPassword(string password)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                // Generate a random salt
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);

                using (var newPass = new Rfc2898DeriveBytes(password, salt, Iterations))
                {
                    byte[] hash = newPass.GetBytes(HashSize);

                    // Combine the salt and hash
                    byte[] hashBytes = new byte[SaltSize + HashSize];
                    Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                    Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

                    return Convert.ToBase64String(hashBytes); // Store this as the hashed password
                }
            }
        }

        //Method to verify that the password entered is correct
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Convert the stored hash back from Base64
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // The first 16 bytes are the salt
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // The rest is the hash
            byte[] storedHashValue = new byte[HashSize];
            Array.Copy(hashBytes, SaltSize, storedHashValue, 0, HashSize);

            using (var ConfirmPass = new Rfc2898DeriveBytes(enteredPassword, salt, Iterations))
            {
                byte[] hash = ConfirmPass.GetBytes(HashSize);

                // Compare the computed hash with the stored hash
                return hash.SequenceEqual(storedHashValue);
            }
        }
    }
}
