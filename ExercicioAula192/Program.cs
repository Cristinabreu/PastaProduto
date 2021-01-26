using Entities;
using System;
using System.Globalization;
using System.IO;


namespace ExercicioAula192 {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Enter file full path: ");
            string sourceFilePath = Console.ReadLine();

            try {
                string[] lines = File.ReadAllLines(sourceFilePath);

                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFolderPath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";

                Directory.CreateDirectory(sourceFolderPath);

                using (StreamWriter sw = File.AppendText(targetFilePath)){
                    foreach(string line in lines) {

                        string[] fields = line.Split(',');
                        string name = fields[0];
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quatity = int.Parse(fields[2]);

                        Product product = new Product(name, price, quatity);

                        sw.WriteLine(product.Name + "," + product.Total().ToString("F2", CultureInfo.InvariantCulture));

                    }
                }
            }
            catch (IOException e) {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
