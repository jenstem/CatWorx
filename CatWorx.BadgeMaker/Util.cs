using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SkiaSharp;


namespace CatWorx.BadgeMaker

{
    class Util
    {

        public static void PrintEmployees(List<Employee> employees)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                string template = "{0, -10}\t{1, -20}\t{2}";
                Console.WriteLine(String.Format(template, employees[i].GetId(),
                    employees[i].GetFullName(), employees[i].GetPhotoUrl()));
            }
        }

        public static void MakeCSV(List<Employee> employees)
        {
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            using (StreamWriter file = new StreamWriter("data/employees.csv"))
            {
                file.WriteLine("ID, Name, PhotoUrl");

                for (int i = 0; i < employees.Count; i++)
                {
                    string template = "{0}, {1}, {2}";
                    file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
                }
            }
        }

        async public static Task MakeBadges(List<Employee> employees)
        {
            int BADGE_WIDTH = 669;
            int BADGE_HEIGHT = 1044;

            using(HttpClient client = new HttpClient())
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    SKImage photo = SKImage.FromEncodedData(await client.GetByteArrayAsync(employees[i].GetPhotoUrl()));
                    SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));

                    SKBitmap badge = new SKBitmap(BADGE_WIDTH, BADGE_HEIGHT);
                    SKCanvas canvas = new SKCanvas(badge);

                    canvas.DrawImage(background, new SKRect(0, 0, BADGE_WIDTH, BADGE_HEIGHT));
                }
            }
        }
    }
}