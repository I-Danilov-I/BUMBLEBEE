using Newtonsoft.Json;
using System.Diagnostics;

namespace BUMBLEBEE
{
    internal static class Export_To_Json
    {
        internal static string Conver_To_Json(string email_adress, string password, string recovery_code)
        {
            var data = new
            {
                recovery_code,
                email_adress,
                password
            };
            string json_content = JsonConvert.SerializeObject(data, Formatting.Indented);
            Console.WriteLine(json_content);
            return json_content;
        }



        internal static void WriteStringToFile(string content, string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    using (FileStream fs = File.Create(filePath))
                    {
                        fs.Close();
                    }
                }

                using (StreamWriter writer = new StreamWriter(filePath, append: false))
                {
                    writer.WriteLine(content);
                }
                Console.WriteLine($"Der Inhalt wurde erfolgreich in die Datei {filePath} geschrieben.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Schreiben in die Datei: {ex.Message}");
            }
        }


        internal static string Create_Folder(string folder_name)
        {
            try
            {
                string currentDir = Directory.GetCurrentDirectory().Replace("bin\\Debug\\net8.0", "");
                string folderPath = Path.Combine(currentDir, folder_name);
                Directory.CreateDirectory(folderPath);
                return folderPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ConsoleColor.Red);
            }
            return folder_name;
        }


        internal static void RandomSleep(int von, int bis)
        {
            Random random = new Random();
            int minSleepSeconds = von;
            int maxSleepSeconds = bis;
            int sleepTimeMilliseconds = random.Next(minSleepSeconds * 1000, (maxSleepSeconds + 1) * 1000);
            int totalSleepTime = sleepTimeMilliseconds;

            // Starten des Timers
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (stopwatch.ElapsedMilliseconds < totalSleepTime)
            {
                // Berechnen der verbleibenden Zeit
                int remainingTime = totalSleepTime - (int)stopwatch.ElapsedMilliseconds;

                // Anzeigen der verbleibenden Zeit in der Konsole
                Console.Write("\rVerbleibende Zeit: {0} Sekunden", remainingTime / 1000);
                Thread.Sleep(100); // Aktualisierung der Anzeige alle 100ms
            }
            stopwatch.Stop();

            // Löschen der Zeile nach Beendigung des Timers
            Console.Write("\r{0}", new string(' ', Console.WindowWidth));
        }


    }
}
