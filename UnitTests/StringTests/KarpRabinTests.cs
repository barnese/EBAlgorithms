using System;
using Xunit;
using EBAlgorithms;

namespace EBAlgorithmsUnitTests {
    public class KarpRabinTests {
        [Fact]
        public void TestKarpRabinSearchInEnglish() {            
            var quote = "\"C makes it easy to shoot yourself in the foot; C++ makes it harder, but when you do, it blows away your whole leg.\" - Bjarne Stroustrup";

            Assert.True(KarpRabin.Search(quote, "C++ makes it harder").Count == 1);
            Assert.True(KarpRabin.Search(quote, "C# makes it easier").Count == 0);
            Assert.True(KarpRabin.Search(quote, "it").Count == 3);
            Assert.True(KarpRabin.Search(quote, quote).Count == 1);
        }

        [Fact]
        public void TestKarpRabinSearchInJapanese() {
            var japaneseQuote = "猿も木から落ちる。";

            foreach (var c in japaneseQuote) {
                Assert.True(KarpRabin.Search(japaneseQuote, c.ToString()).Count == 1);
            }
        }
    }
}
