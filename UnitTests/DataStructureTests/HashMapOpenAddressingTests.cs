using Xunit;
using EBAlgorithms.DataStructures;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class HashMapOpenAddressingTests {
        private List<string> englishNumbers = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
        private List<string> spanishNumbers = new List<string> { "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez" };

        private HashMap<string, string> numberMap = new HashMap<string, string>();

        public HashMapOpenAddressingTests() {
            for (var i = 0; i < englishNumbers.Count; i++) {
                numberMap.Put(englishNumbers[i], spanishNumbers[i]);
            }
        }

        [Fact]
        public void HashMapOpenAddressing_Put() {
            Assert.Equal(englishNumbers.Count, numberMap.Count);

            for (var i = 0; i < englishNumbers.Count; i++) {
                Assert.True(numberMap.ContainsKey(englishNumbers[i]));
                Assert.True(numberMap.Get(englishNumbers[i]) == spanishNumbers[i]);
            }
        }

        [Fact]
        public void HashMapOpenAddressing_Delete() {
            var key = "four";
            numberMap.Delete(key);
            Assert.False(numberMap.ContainsKey(key));
            Assert.Equal(englishNumbers.Count - 1, numberMap.Count);
        }
    }
}
