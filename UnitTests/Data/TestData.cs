using System;
using System.Collections.Generic;

namespace EBAlgorithmsUnitTests {
    public class TestData {

        public static List<int> Numbers = new List<int> { 55, 23, 74, 4, 40, 67, 89, 1, 20, 29, 54, 61, 72, 88, 99, 1, 3, 9, 30, 92 };

        public static List<string> Words = new List<string> { "zebra", "cat", "walrus", "bird", "bobcat", "bear", "snake", "elephant", "giraffe" };

        public static List<int> GetRandomIntList(int size, int minValue, int maxValue, bool uniqueValues) {
            var list = new List<int>(size);
            var random = new Random(DateTime.Now.Millisecond);

            for (var i = 0; i < size; i++) {
                int randomInt;
                do {
                    randomInt = random.Next(minValue, maxValue);
                } while (uniqueValues && list.Contains(randomInt));

                list.Add(randomInt);
            }

            return list;
        }
    }
}
