using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBAlgorithms {
    public class FileHelpers {
        /// <summary>
        /// Returns a string containing the contents of the given file.
        /// </summary>
        public static string ReadFileContents(string fileName, Encoding encoding) {
            var file = File.Open(fileName, FileMode.Open);
            string content = "";
            using (StreamReader reader = new StreamReader(file, encoding)) {
                content = reader.ReadToEnd();
            }
            return content;
        }

        /// <summary>
        /// Returns an array of words from the given file.
        /// </summary>
        public static string[] SplitFileIntoWords(string fileName) {
            return SplitFileIntoWords(fileName, Encoding.UTF8);
        }

        public static string[] SplitFileIntoWords(string fileName, Encoding encoding) {
            var fileContents = ReadFileContents(fileName, encoding);

            // Convert non-alphanumeric characters into spaces.
            var characters = fileContents.ToCharArray();

            for (int i = 0; i < characters.Length; i++) {
                if (!Char.IsLetterOrDigit(characters[i])) {
                    characters[i] = ' ';
                }
            }

            return new String(characters).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
