using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {

        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        /// <summary>
        /// Побайтовое копирование содержимого одного тествового файла в другой 
        ///с использованием класса FileStream в качестве потока с резервным хранилищем
        /// </summary>
        /// <param name="sourcePath">Файл из которого копируют данные</param>
        /// <param name="destinationPath">Файл в который копируют данные</param>
        /// <returns>Количество записанных байт</returns>
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            int length;
            using (var reader = new FileStream(sourcePath, FileMode.Open))
            {
                using (var writer = new FileStream(destinationPath, FileMode.Create))
                {
                    while (reader.Position < reader.Length)
                    {
                        writer.WriteByte((byte)reader.ReadByte());
                    }
                }

                length = (int)reader.Length;
            }
            return length;
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        /// <summary>
        /// Побайтовое копирование содержимого одного тествового файла в другой 
        ///с использованием класса MemoryStream в качестве потока с резервным хранилищем
        /// </summary>
        /// <param name="sourcePath">Файл из которого копируют данные</param>
        /// <param name="destinationPath">Файл в который копируют данные</param>
        /// <returns>Количество записанных байт</returns>
        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            // TODO: step 1. Use StreamReader to read entire file in string
            var reader = new StreamReader(sourcePath);
            var text = reader.ReadToEnd();
            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class
            var byteArray = Encoding.UTF8.GetBytes(text);
            // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)
            var memoryStream = new MemoryStream();
            var res = new byte[byteArray.Length];
            for (int i = 0; i < byteArray.Length; i++)
            {
                memoryStream.WriteByte((byte)i);
                // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array
                res[i] = (byte)memoryStream.ReadByte();
            }
            // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content
            var charArray = Encoding.UTF8.GetChars(res);
            // TODO: step 6. Use StreamWriter here to write char array content in new file
            var writer = new StreamWriter(destinationPath);
            writer.Write(charArray);
            return charArray.Length;
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        /// <summary>
        /// Копирование содержимого одного тествового файла в другой, 
        ///используя возможности буферизации класса FileStream
        /// </summary>
        /// <param name="sourcePath">Файл из которого копируют данные</param>
        /// <param name="destinationPath">Файл в который копируют данные</param>
        /// <returns>Количество записанных байт</returns>
        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            int length;
            using (var reader = new FileStream(sourcePath, FileMode.Open))
            {
                using (var writer = new FileStream(destinationPath, FileMode.Create))
                {
                    while (reader.Position < reader.Length)
                    {
                        writer.WriteByte((byte)reader.ReadByte());
                    }
                }

                length = (int)reader.Length;
            }
            return length;
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            // TODO: Use InMemoryByByteCopy method's approach
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {

        }

        #endregion

        #endregion

    }
}
