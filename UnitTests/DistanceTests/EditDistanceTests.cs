using System;
using Xunit;
using EBAlgorithms;

namespace EBAlgorithmsUnitTests {
    public class EditDistanceTests {
        [Fact]
        public void TestFindingNoEdits() {
            var s = "same";
            var t = "same";
            var expected = 0;
            var distance = EditDistance.FindWagnerFischerDistance(s, t);
            Assert.Equal(expected, distance);
        }

        [Fact]
        public void TestFindingEdits() {
            var s = "Saturday";
            var t = "Sunday";
            var expected = 3;
            var distance = EditDistance.FindWagnerFischerDistance(s, t);
            Assert.Equal(expected, distance);
        }
    }
}
