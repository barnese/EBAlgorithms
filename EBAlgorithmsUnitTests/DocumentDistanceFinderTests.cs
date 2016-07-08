using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBAlgorithms;

namespace EBAlgorithmsUnitTests {
    [TestClass]
    public class DocumentDistanceFinderTests {
        private string file1 = "../../Data/DistanceData1.txt";
        private string file2 = "../../Data/DistanceData2.txt";

        [TestMethod]
        public void DocumentDistanceFinder_FindDifferingDistance() {
            var documentDistanceFinder = new DocumentDistanceFinder();

            var distance = documentDistanceFinder.FindDistance(file1, file2);

            // Since the files are completely different, we expect the greatest distance: pi/2.
            Assert.AreEqual(distance, Math.PI / 2);
        }

        [TestMethod]
        public void DocumentDistanceFinder_FindIdenticalDistance() {
            var documentDistanceFinder = new DocumentDistanceFinder();

            var distance = documentDistanceFinder.FindDistance(file1, file1);

            // Since the files are the same, we expect no distance.
            Assert.AreEqual(distance, 0);
        }
    }
}
