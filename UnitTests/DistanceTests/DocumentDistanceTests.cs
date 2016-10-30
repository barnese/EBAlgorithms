using System;
using Xunit;
using EBAlgorithms;

namespace EBAlgorithmsUnitTests {
    public class DocumentDistanceTests {
        private string file1 = "Data/DistanceData1.txt";
        private string file2 = "Data/DistanceData2.txt";

        [Fact]
        public void TestFindingDifferingDistance() {
            var documentDistance = new DocumentDistance();

            var distance = documentDistance.FindDistance(file1, file2);

            // Since the files are completely different, we expect the greatest distance: pi/2.
            Assert.Equal(distance, Math.PI / 2);
        }

        [Fact]
        public void TestFindingIdenticalDistance() {
            var documentDistance = new DocumentDistance();

            var distance = documentDistance.FindDistance(file1, file1);

            // Since the files are the same, we expect no distance.
            Assert.Equal(distance, 0);
        }
    }
}
