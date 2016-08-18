using System;
using System.Collections.Generic;

namespace EBAlgorithms
{
    public class DocumentDistance
    {
        /// <summary>
        /// Finds the distance between two files, where the distance is how many words are shared between the files.
        /// Converts the files into vectors of words and returns the distance as the angle between the two using their dot product.
        /// </summary>
        /// <returns>Distance as a decimal ranging from 0 to pi/2.</returns>
        public double FindDistance(string fileName1, string fileName2) {
            var words1 = FileHelpers.SplitFileIntoWords(fileName1);
            var words2 = FileHelpers.SplitFileIntoWords(fileName2);

            var wordFrequencies1 = CountWordFrequencies(words1);
            var wordFrequencies2 = CountWordFrequencies(words2);

            return CalculateVectorAngle(wordFrequencies1, wordFrequencies2);
        }

        private long CalculateDotProduct(Dictionary<string, int> d1, Dictionary<string, int> d2) {
            // Dot product of d1 and d2 = a1 * b1 + a2 * b2 + ... + an * bn.
            long sum = 0;

            foreach (var entry1 in d1) {
                if (d2.ContainsKey(entry1.Key))
                    sum += entry1.Value * d2[entry1.Key];
            }

            return sum;
        }

        private double CalculateVectorAngle(Dictionary<string, int> d1, Dictionary<string, int> d2) {
            // Angle between two vectors: cos theta = (d1 * d2) / (|d1| * |d2|)
            // Magnitude of a vector: |d1| = sqroot(a1 ^ 2 + a2 ^ 2 + ... + an ^ 2)

            double product = CalculateDotProduct(d1, d2);
            double magnitudes = Math.Sqrt(CalculateDotProduct(d1, d1) * CalculateDotProduct(d2, d2));
                
            return Math.Acos(product / magnitudes);
        }

        private Dictionary<string, int> CountWordFrequencies(string[] words) {
            var wordFrequencies = new Dictionary<string, int>();

            foreach (var word in words) {
                if (wordFrequencies.ContainsKey(word)) {
                    wordFrequencies[word] = wordFrequencies[word] + 1;
                } else {
                    wordFrequencies[word] = 1;
                }
            }

            return wordFrequencies;
        }
    }
}
