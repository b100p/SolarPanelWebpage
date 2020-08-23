﻿using System;
using System.IO;                    // MemoryStream
using System.Security.Cryptography; // used by aes
using System.Text;                  // used by Encoding
using Microsoft.Win32;              // used by Registry
using System.Diagnostics;           // used by Process
namespace ProjectPage.Classes
{
    public class Encrypt
    {
    
    public string Encrypts(string strData)
    {

        return Convert.ToBase64String(Encrypts(Encoding.UTF8.GetBytes(strData)));
        // reference https://msdn.microsoft.com/en-us/library/ds4kkd55(v=vs.110).aspx

    }


    // decoding
    public string Decrypt(string strData)
    {
        return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strData)));
        // reference https://msdn.microsoft.com/en-us/library/system.convert.frombase64string(v=vs.110).aspx

    }

        // encrypt
        public static byte[] Encrypts(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(Global.strPermutation,
            new byte[] { Global.bytePermutation1,
                         Global.bytePermutation2,
                         Global.bytePermutation3,
                         Global.bytePermutation4
            });

            MemoryStream memstream = new MemoryStream();
            Aes aes = new AesManaged();
            aes.Key = passbytes.GetBytes(aes.KeySize / 8);
            aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

            CryptoStream cryptostream = new CryptoStream(memstream,
            aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptostream.Write(strData, 0, strData.Length);
            cryptostream.Close();
            return memstream.ToArray();
        }

        // decrypt
        public static byte[] Decrypt(byte[] strData)
    {
        PasswordDeriveBytes passbytes =
        new PasswordDeriveBytes(Global.strPermutation,
        new byte[] { Global.bytePermutation1,
                         Global.bytePermutation2,
                         Global.bytePermutation3,
                         Global.bytePermutation4
        });

        MemoryStream memstream = new MemoryStream();
        Aes aes = new AesManaged();
        aes.Key = passbytes.GetBytes(aes.KeySize / 8);
        aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

        CryptoStream cryptostream = new CryptoStream(memstream,
        aes.CreateDecryptor(), CryptoStreamMode.Write);
        cryptostream.Write(strData, 0, strData.Length);
        cryptostream.Close();
        return memstream.ToArray();
    }
    public static class Global
    {
        // Set password
        public const string strPassword = "LetMeIn99$";

        // set permutations
        public const String strPermutation = "ouiveyxaqtd";
        public const Int32 bytePermutation1 = 0x19;
        public const Int32 bytePermutation2 = 0x59;
        public const Int32 bytePermutation3 = 0x17;
        public const Int32 bytePermutation4 = 0x41;
    }
}
}