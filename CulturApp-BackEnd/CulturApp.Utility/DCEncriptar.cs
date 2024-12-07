using System;
using System.Security.Cryptography;
using System.Text;

namespace CulturApp.Utility.Seguridad.Criptografia
{
    public class DCEncriptar
    {
        public enum AlgoritmoEncriptacion
        {
            MD5 = 0,
            SHA1 = 1,
            SHA256 = 2,
            SHA384 = 3,
            SHA512 = 4
        }

        public DCEncriptar() { }

        public string Encriptar(string Text, AlgoritmoEncriptacion hash, string Key)
        {
            string HashPassword = string.Empty;

            switch (hash)
            {
                case AlgoritmoEncriptacion.MD5:
                    HashPassword = string.Empty;
                    break;
                case AlgoritmoEncriptacion.SHA1:
                    HashPassword = string.Empty;
                    break;
                case AlgoritmoEncriptacion.SHA256:
                    HashPassword = string.Empty;
                    break;
                case AlgoritmoEncriptacion.SHA384:
                    HashPassword = string.Empty;
                    break;
                case AlgoritmoEncriptacion.SHA512:
                    HashPassword = CreateSHA512(Text, Key);
                    break;
            }

            return HashPassword;
        }

        public string CreateSHA512(string Text, string Key)
        {
            SHA512 HashTool = SHA512.Create();
            Byte[] HashAsByte = Encoding.UTF8.GetBytes(string.Concat(Text, Key));
            Byte[] EncryptedBytes = HashTool.ComputeHash(HashAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(EncryptedBytes);
        }
    }
}
