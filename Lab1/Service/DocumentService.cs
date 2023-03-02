using System;
using System.IO;
using System.Text;

namespace Lab1.Service
{
    struct DocumentPayload
    {
        public string filename;
        public string username;
        public string text;
    }

    struct PublicKeyPayload
    {
        public string filename;
        public string username;
    }

    class DocumentService
    {
        const string pathPrefixKeyFolder = "PK";
        const string extValPublicKey = ".pub";
        const string extValDescPublicKey = "Открытый ключ|*.pub";
        const string extValDescDocument = "Подписанный документ|*.sd";

        private DigitalSignature signature;
        private Encoding encoding;

        public DocumentService()
        {
            signature = new DigitalSignature();
            encoding = Encoding.Default;
        }

        public void CreateUserContainer(string username)
        {
            signature.CreateKeyContainer(username);
        }

        public bool ExistUserContainer(string username)
        {
            return signature.ExistKeyContainer(username);
        }

        public void SaveDocument(DocumentPayload payload)
        {
            const string errPrefix = "Не удалось сохранить документ:";

            try
            {
                byte[] bytesUsername = encoding.GetBytes(payload.username);
                byte[] content = encoding.GetBytes(payload.text);
                byte[] signContent = signature.SignDocContent(content);
                //
                // Структура подписанного документа
                // 
                // Длина имени подписывающего пользователя	
                // Длина подписи	
                // Имя подписывающего пользователя	
                // Электронная подпись	
                // Текст документа
                //
                using (var writer = new BinaryWriter(File.Open(payload.filename, FileMode.Create)))
                {
                    writer.Write(bytesUsername.Length);
                    writer.Write(signContent.Length);
                    writer.Write(bytesUsername);
                    writer.Write(signContent);
                    writer.Write(content);
                }
            }
            catch
            {
                throw new Exception($"{errPrefix} документ поврежден");
            }
        }

        public DocumentPayload LoadDocument(DocumentPayload payload)
        {
            const string errPrefix = "Не удалось загрузить документ:";

            string documentUsername;
            byte[] signContent;
            byte[] content;

            try
            {
                using (var reader = new BinaryReader(File.Open(payload.filename, FileMode.Open)))
                {
                    // Структура подписанного документа
                    // 
                    // Длина имени подписывающего пользователя	
                    // Длина подписи	
                    // Имя подписывающего пользователя	
                    // Электронная подпись	
                    // Текст документа
                    //
                    int lenghtUsername = reader.ReadInt32();
                    int lenghtSignContent = reader.ReadInt32();
                    documentUsername = encoding.GetString(reader.ReadBytes(lenghtUsername));
                    signContent = reader.ReadBytes(lenghtSignContent);
                    int lenghtContent = (int)(reader.BaseStream.Length - reader.BaseStream.Position);
                    content = reader.ReadBytes(lenghtContent);
                }
            }
            catch
            {
                throw new Exception($"{errPrefix} документ поврежден");
            }

            var sb = new StringBuilder();

            sb.Append(pathPrefixKeyFolder);
            sb.Append(Path.DirectorySeparatorChar);
            sb.Append(payload.username);
            sb.Append(Path.DirectorySeparatorChar);
            sb.Append(documentUsername);
            sb.Append(extValPublicKey);

            string pathPublicKey = sb.ToString();

            if (!File.Exists(pathPublicKey)) 
            {
                throw new Exception($"{errPrefix} открытый ключ не найден");
            }

            try
            {
                byte[] publicKeyBlob;
                byte[] signPublicKey;

                using (var reader = new BinaryReader(File.Open(pathPublicKey, FileMode.Open)))
                {
                    // Формат подписанного открытого ключа 
                    //
                    // Длина имени владельца открытого ключа
                    // Длина блоба с открытым ключом	
                    // Имя владельца открытого ключа	
                    // Блоб с открытым ключом	
                    // Электронная подпись
                    //
                    int lenghtUsername = reader.ReadInt32();
                    int lenghtPublicKeyBlob = reader.ReadInt32();
                    string publicKeyUsername = encoding.GetString(reader.ReadBytes(lenghtUsername));
                    publicKeyBlob = reader.ReadBytes(lenghtPublicKeyBlob);
                    int lenghtSignPublicKey = (int)(reader.BaseStream.Length - reader.BaseStream.Position);
                    signPublicKey = reader.ReadBytes(lenghtSignPublicKey);
                }

                // Проверка подписи открытого ключа
                if (!signature.VerifySignPublicKey(publicKeyBlob, signPublicKey))
                {
                    throw new Exception($"{errPrefix} электронная подпись открытого ключа автора документа не подтверждена");
                }

                // Проверка подписи автора под документом
                if (!signature.VerifySignContentDoc(content, signContent, publicKeyBlob))
                {
                    throw new Exception($"{errPrefix} электронная подпись документа не подтверждена");
                }

                string documentText = encoding.GetString(content);

                return new DocumentPayload()
                {
                    filename = payload.filename,
                    username = documentUsername,
                    text = documentText,
                };
            }
            catch (Exception)
            {
                throw new Exception($"{errPrefix} файл с открытым ключом поврежден");
            }
        }

        public void ExportPublicKey(PublicKeyPayload payload)
        {
            const string errPrefix = "Не удалось экспортировать открытый ключ:";

            try
            {
                byte[] bytesUsername = encoding.GetBytes(payload.username);
                byte[] publicKeyBlob = signature.GetPublicKeyBlob();
                //
                // Формат открытого ключа
                //
                // Длина имени владельца открытого ключа	
                // Длина блоба с открытым ключом	
                // Имя владельца открытого ключа	
                // Блоб с открытым ключом
                //
                using (BinaryWriter writer = new BinaryWriter(File.Open(payload.filename, FileMode.Create)))
                {
                    writer.Write(bytesUsername.Length);
                    writer.Write(publicKeyBlob.Length);
                    writer.Write(bytesUsername); 
                    writer.Write(publicKeyBlob);
                }
            }
            catch
            {
                throw new Exception($"{errPrefix} открытый ключ поврежден");
            }
        }

        public void ImportPublicKey(PublicKeyPayload payload)
        {
            const string errPrefix = "Не удалось импортировать открытый ключ:";

            string publicKeyUsername;
            byte[] publicKeyBlob;

            try
            {
                using (var reader = new BinaryReader(File.Open(payload.filename, FileMode.Open)))
                {
                    // Формат подписанного открытого ключа 
                    //
                    // Длина имени владельца открытого ключа
                    // Длина блоба с открытым ключом	
                    // Имя владельца открытого ключа	
                    // Блоб с открытым ключом	
                    // Электронная подпись
                    //
                    int lenghtUsername = reader.ReadInt32();
                    int lenghtPublicKeyBlob = reader.ReadInt32();
                    publicKeyUsername = encoding.GetString(reader.ReadBytes(lenghtUsername));
                    publicKeyBlob = reader.ReadBytes(lenghtPublicKeyBlob);
                }
            }
            catch
            {
                throw new Exception($"{errPrefix} открытый ключ поврежден");
            }

            var sb = new StringBuilder();

            sb.Append(pathPrefixKeyFolder);
            sb.Append(Path.DirectorySeparatorChar);
            sb.Append(payload.username);

            string pathPublicKeyDir = sb.ToString();   

            if (!Directory.Exists(pathPublicKeyDir))
            {
                Directory.CreateDirectory(pathPublicKeyDir);
            }

            sb.Append(Path.DirectorySeparatorChar); 
            sb.Append(publicKeyUsername);
            sb.Append(extValPublicKey);

            string pathPublicKeyFile = sb.ToString();   

            try
            {
                byte[] bytesUsername = encoding.GetBytes(publicKeyUsername);
                byte[] signPublicKey = signature.SignPublicKeyBlob(publicKeyBlob);
                //
                // Сохранение подписанного открытого ключа
                // в папке-хранилище открытых ключей участников электронного документооборота 
                //
                using (var writer = new BinaryWriter(File.Open(pathPublicKeyFile, FileMode.Create)))
                {
                    writer.Write(bytesUsername.Length);
                    writer.Write(publicKeyBlob.Length);
                    writer.Write(bytesUsername);
                    writer.Write(publicKeyBlob);
                    writer.Write(signPublicKey);
                }
            }
            catch
            {
                throw new Exception($"{errPrefix} открытый ключ поврежден");
            }
        }

        public void DeleteKeyPair(string username)
        {
            signature.DeleteKeyContainer(username);
        }

        public static string GetPathPrefixKeyFolder() => pathPrefixKeyFolder;

        public static string GetPublicKeyExtension() => extValPublicKey;

        public static string GetDocumentExtensionDesc() => extValDescDocument;

        public static string GetPublicKeyExtensionDesc() => extValDescPublicKey;

        public static string StripFileName(string filename) => Path.GetFileName(filename);
    }
}
