﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SnailPass_Desktop.Model.Interfaces
{
    public interface ISymmetricCryptographer
    {
        public (string, string) Encrypt(string plaintext, string key, byte[]? nonce = null);
        public (string, string) Encrypt(SecureString plaintext, string key, byte[]? nonce = null);
        public string Decrypt(string encryptedData, string key, string nonce);
    }
}
