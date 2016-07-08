using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBAlgorithms;

namespace EBAlgorithmsConsole {
    class Program {
        private static string programName = System.AppDomain.CurrentDomain.FriendlyName;

        static void Main(string[] args) {
            if (args.Length == 0) {
                Console.WriteLine("Usage: {0} <command> <parameters>", programName);
                return;
            }

            var command = args[0].ToLower();

            try {
                switch (command) {
                    case "distance":
                        DocumentDistanceRunner(args);
                        break;
                    default:
                        Console.WriteLine("Command not recognized.");
                        break;
                }
            } catch (Exception exception) {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Runs the document distance algorithm.
        /// </summary>
        /// <example>
        /// .\EBAlgorithmsConsole.exe distance ..\..\Data\DistanceData1.txt ..\..\Data\DistanceData2.txt
        /// </example>
        static void DocumentDistanceRunner(string[] args) {
            if (args.Length != 3) {
                Console.WriteLine("Usage: {0} distance filename1 filename2", programName);
                return;
            }

            var documentDistanceFinder = new DocumentDistanceFinder();

            var distance = documentDistanceFinder.FindDistance(args[1], args[2]);

            Console.WriteLine("The distance is {0} (radians)", distance);

            var ratio = distance / (Math.PI / 2);

            Console.WriteLine("Difference ratio is {0:N2}", ratio);
        }
    }
}
