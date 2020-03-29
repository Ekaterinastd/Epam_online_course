﻿using System.IO;
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
            char[] charArray;
            // TODO: step 1. Use StreamReader to read entire file in string
            using (var reader = new StreamReader(sourcePath, Encoding.UTF8))
            {
                byte[] res;
                var text = reader.ReadToEnd();
                // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class
                var byteArray = Encoding.UTF8.GetBytes(text);
                // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)
                using (var memoryStream = new MemoryStream())
                {
                    res = new byte[byteArray.Length];
                    for (int i = 0; i < byteArray.Length; i++)
                    {
                        memoryStream.WriteByte(byteArray[i]);
                        // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array
                        memoryStream.Position = i;
                        res[i] = (byte)memoryStream.ReadByte();
                    }
                }

                // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content
                charArray = Encoding.UTF8.GetChars(res);
            }

            // TODO: step 6. Use StreamWriter here to write char array content in new file
            using (var writer = new StreamWriter(destinationPath, false, Encoding.UTF8))
            {
                writer.Write(charArray);
            }
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
            byte[] buffer = new byte[4096];
            using (var reader = new FileStream(sourcePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite, 4096))
            {
                using (var writer = new FileStream(destinationPath, FileMode.Create))
                {
                    reader.Read(buffer, 0, buffer.Length);
                    writer.Write(buffer, 0, buffer.Length);
                }

                length = (int)reader.Length;
            }
            return length;
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        /// <summary>
        ///Копирование содержимого одного тествового файла в другой с 
        ///использованием класса MemoryStream в качестве потока с резервным хранилищем
        /// </summary>
        /// <param name="sourcePath">Файл из которого копируют данные</param>
        /// <param name="destinationPath">Файл в который копируют данные</param>
        /// <returns>Количество записанных байт</returns>
        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            // TODO: Use InMemoryByByteCopy method's approach     
            char[] charArray;
            int count;
            using (var reader = new StreamReader(sourcePath, Encoding.UTF8))
            {
                var text = reader.ReadToEnd();
                var byteArray = Encoding.UTF8.GetBytes(text);
                using (var memoryStream = new MemoryStream())
                {
                    memoryStream.Write(byteArray, 0, byteArray.Length);
                    var res = new byte[byteArray.Length];
                    memoryStream.Position = 0;
                    count = memoryStream.Read(res, 0, res.Length);
                    charArray = Encoding.UTF8.GetChars(res);
                }
            }
            using (var writer = new StreamWriter(destinationPath, false, Encoding.UTF8))
            {
                writer.Write(charArray);
            }
            return count;
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        /// <summary>
        ///Копирование содержимого одного тествового файла в другой, используя
        ///возможности класса-декоратора потоков BufferedStream
        /// </summary>
        /// <param name="sourcePath">Файл из которого копируют данные</param>
        /// <param name="destinationPath">Файл в который копируют данные</param>
        /// <returns>Количество записанных байт</returns>
        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            byte[] byteArray;
            using (var reader = File.OpenRead(sourcePath))
            {
                using (var bufferedStream = new BufferedStream(reader, 20000))
                {
                    byteArray = new byte[reader.Length];
                    var charArray = byteArray;
                    for (var i = 0; i < byteArray.Length; i++)
                    {
                        byteArray[i] = (byte)bufferedStream.ReadByte();//считывание байта из потока reader
                    }
                    using (var writer = new FileStream(destinationPath, FileMode.Create))
                    {
                        writer.Write(byteArray, 0, byteArray.Length);
                    }
                }
                return byteArray.Length;
            }
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        /// <summary>
        /// Построчное копирование содержимого одного тествового файла в другой
        /// </summary>
        /// <param name="sourcePath">Файл из которого копируют данные</param>
        /// <param name="destinationPath">Файл в который копируют данные</param>
        /// <returns>Количество записанных строк</returns>
        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            var count = 0;
            using (var reader = new FileStream(sourcePath, FileMode.Open))
            {
                using (var reader2 = new StreamReader(reader))
                {
                    using(var writer = new StreamWriter(destinationPath))
                    {
                        while (!reader2.EndOfStream)
                        {
                            writer.WriteLine(reader2.ReadLine());// чтение строки символов из потока и запись в выходной файл
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            string t1, t2;
            using (var st1 = new StreamReader(sourcePath))
            {
                t1 = st1.ReadToEnd();
            }
            using (var st2 = new StreamReader(sourcePath))
            {
                t2 = st2.ReadToEnd();
            }
            return t1 == t2;
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
