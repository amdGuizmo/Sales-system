using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Sales_system.Library
{
    public class Encrypt
    {
        private static RijndaelManaged rm = new RijndaelManaged();

        public static void encrypt()
        {
            //Modo funcionamiento
            rm.Mode = CipherMode.CBC;
            //Modo de relleno
            rm.Padding = PaddingMode.PKCS7;
            //bits para la operacion
            rm.BlockSize = 0x80;
            //bits para la clave secreta
            rm.KeySize = 0x80;
        }

        public static string EncryptData(string textData, string EncryptionKey)
        {
            encrypt();

            byte[] passBytes = Encoding.UTF8.GetBytes(EncryptionKey);
            //Vector de inicializacion (IV) para el algoritmo simetrico
            byte[] EncryptionKeyBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
                , 0x00, 0x00, 0x00, 0x00, 0x00, 0x00};
            int len = passBytes.Length;
            if(len > EncryptionKeyBytes.Length)
            {
                len = EncryptionKeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionKeyBytes, len);
            rm.Key = EncryptionKeyBytes;
            rm.IV = EncryptionKeyBytes;
            //Crea un objeto AES simetrico con la clave actual y el vector de inicializacion IV
            ICryptoTransform objtransform = rm.CreateEncryptor();
            byte[] textDataByte = Encoding.UTF8.GetBytes(textData);

            return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        }

        public static string DecryptData(string EncryptedText, string EncryptionKey)
        {
            encrypt();

            byte[] encryptedTextByte = Convert.FromBase64String(EncryptedText);
            byte[] passBytes = Encoding.UTF8.GetBytes(EncryptionKey);
            //Vector de inicializacion (IV) para el algoritmo simetrico
            byte[] EncryptionKeyBytes = new byte[0x10];
            int len = passBytes.Length;
            if (len > EncryptionKeyBytes.Length)
            {
                len = EncryptionKeyBytes.Length;
            }
            Array.Copy(passBytes, EncryptionKeyBytes, len);
            rm.Key = EncryptionKeyBytes;
            rm.IV = EncryptionKeyBytes;
            byte[] TextByte = rm.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);

            return Encoding.UTF8.GetString(TextByte);
        }
    }
}
