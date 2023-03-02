using System.Security.Cryptography;

namespace Lab1.Service
{
    class DigitalSignature
    {
        const int provRsaAes = 24;
        const bool persistKeyTrue = true;
        const bool persistKeyFalse = false;
        const bool privateParamsFalse = false;

        private RSACryptoServiceProvider provider;

        private SHA1 hashDocContent;
        private SHA512 hashPublicKey;

        public DigitalSignature()
        {
            hashDocContent = SHA1.Create();
            hashPublicKey = SHA512.Create();
        }

        public void CreateKeyContainer(string name)
        {
            provider = new RSACryptoServiceProvider(new CspParameters()
            {
                KeyContainerName = name,
                ProviderType = provRsaAes,
            })
            {
                PersistKeyInCsp = persistKeyTrue,
            };
        }

        public bool ExistKeyContainer(string containerName)
        {
            try
            {
                new RSACryptoServiceProvider(new CspParameters()
                {
                    KeyContainerName = containerName,
                    Flags = CspProviderFlags.UseExistingKey
                });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void DeleteKeyContainer(string containerName)
        {
            try
            {
                if (!ExistKeyContainer(containerName))
                {
                    return;
                }
                provider = new RSACryptoServiceProvider(new CspParameters()
                {
                    KeyContainerName = containerName,
                    ProviderType = provRsaAes,
                })
                {
                    PersistKeyInCsp = persistKeyFalse
                };
                provider.Clear();
            }
            catch {}
        }

        public byte[] SignDocContent(byte[] docContent)
        {
            return provider.SignData(docContent, hashDocContent);
        }

        public byte[] GetPublicKeyBlob()
        {
            return provider.ExportCspBlob(privateParamsFalse);
        }

        public byte[] SignPublicKeyBlob(byte[] publicKeyBlob)
        {
            return provider.SignData(publicKeyBlob, hashPublicKey);
        }

        public bool VerifySignContentDoc(byte[] contentDoc, byte[] signDoc, byte[] publicKeyBlob)
        {
            try
            {
                provider.ImportCspBlob(publicKeyBlob);
                return provider.VerifyData(contentDoc, hashDocContent, signDoc);
            }
            catch 
            {
                return false;
            }
        }

        public bool VerifySignPublicKey(byte[] publicKeyBlob, byte[] signPublicKey)
        {
            try
            {
                return provider.VerifyData(publicKeyBlob, hashPublicKey, signPublicKey);
            }
            catch
            {
                return false;
            }
        }
    }
}
