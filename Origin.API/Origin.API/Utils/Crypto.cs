using System.Security.Cryptography;
using System.Text;

namespace Origin.API.Utils
{
    public class Crypto
    {
        private AesCryptoServiceProvider _aes = new AesCryptoServiceProvider();

        byte[] _key;
        byte[] _iv;

        public Crypto(string key)
        {
            _key = Encoding.ASCII.GetBytes(key);
            _iv = Encoding.ASCII.GetBytes("ORIGIN*123456");

            int keySize = 32;
            int ivSize = 16;
            Array.Resize(ref _key, keySize);
            Array.Resize(ref _iv, ivSize);
        }

        public string Encript(string inputText)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(inputText);
            byte[] encripted;

            RijndaelManaged cripto = new RijndaelManaged();

            using (MemoryStream ms = new MemoryStream(inputBytes.Length))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(_key, _iv), CryptoStreamMode.Write))
                {
                    objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    objCryptoStream.FlushFinalBlock();
                    objCryptoStream.Close();
                }

                encripted = ms.ToArray();
            }

            return Convert.ToBase64String(encripted);
        }

        public string Desencript(string inputText)
        {
            byte[] inputBytes = Convert.FromBase64String(inputText);
            byte[] resultBytes = new byte[inputBytes.Length];
            string textoLimpio = String.Empty;

            RijndaelManaged cripto = new RijndaelManaged();

            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(_key, _iv), CryptoStreamMode.Read))
                {

                    using (StreamReader sr = new StreamReader(objCryptoStream, true))
                    {
                        textoLimpio = sr.ReadToEnd();
                    }
                }
            }

            return textoLimpio;
        }
    }
}
