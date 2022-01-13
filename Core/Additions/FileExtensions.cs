using NiTiS.Core.Attributes;
using System;
using System.IO;

namespace NiTiS.Core.Additions
{
    [NiTiSCoreTypeInfo("1.6.0.0", "2.0.0.0")]
    public static class FileExtensions
    {
        /// <summary>
        /// Creates a directory on the given <paramref name="path"/> if it is not there
        /// </summary>
        /// <param name="path">path to the directory</param>
        /// <exception cref="IOException"></exception>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <returns>Return <see langword="true"></see> if a directory was created </returns>
        public static bool CreateDirectoryIfNotExists(this string path)
        {
            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Creates a file at the given <paramref name="path"/> if it is not there
        /// </summary>
        /// <param name="path">path to the file</param>
        /// <exception cref="UnauthorizedAccessException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="PathTooLongException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="NotSupportedException"></exception> 
        /// <returns>Return <see langword="true"></see> if a file was created </returns>
        public static bool CreateFileIfNotExists(this string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
