using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurityUsb.Service
{
    public class EncryptService
    {
        private String key = "key_1";
        private StorageService storageService;

        private EncryptService()
        {
            storageService = StorageService.InitialInstance();
        }

        public static EncryptService InitialInstance()
        {
            return new EncryptService();
        }

        private String GenerateKey(Aes aesAlg)
        {
            KeySizes[] keySizes = aesAlg.LegalKeySizes;
            int i = 0;
            int legalKeySize = key.Length > 16 ? 16 : 16 - key.Length;
            while (i < legalKeySize)
            {
                i++;
                key = key + 1;
            }
            return key;
        }

        public void EncryptFile(String inputFile, String outputFile)
        {
            using(Aes aesAlg = Aes.Create())
            {
          
                aesAlg.Key = Encoding.UTF8.GetBytes(GenerateKey(aesAlg));
                aesAlg.GenerateIV();
                using(FileStream fileInputStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (FileStream fileOutputStream = new FileStream(storageService.CombinePath(outputFile),
                    FileMode.Create, FileAccess.Write))
                using (ICryptoTransform encryptor = aesAlg.CreateEncryptor())
                using (CryptoStream cryptoStream = new CryptoStream(fileOutputStream, encryptor, CryptoStreamMode.Write))
                {
                    fileOutputStream.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    byte[] buffer = new byte[4096];
                    int byteRead;
                    while ((byteRead = fileInputStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        cryptoStream.Write(buffer, 0, byteRead);
                    }
                }
                if(File.Exists(inputFile))
                {
                    File.Delete(inputFile);
                }
            }

            MessageBox.Show("File has been encrypted");
        }

        public void EncryptCopy(String inputFile, String outputFile) 
        {
            
        }

        public void DecryptFile() 
        {
            
        }
    }
}
