using System;
using System.IO;

namespace Viking.Sdk
{
    public class Log
    {
        public static void ErrorLog(string titulo, string mensaje1, string mensaje2 = null)
        {
            string url = Directory.GetCurrentDirectory();
            string fileName = DateTime.Now.ToString("yyyy_MM_dd") + ".txt";
            string completeUrl = url + "\\ErrorLog\\";

            if (!Directory.Exists(completeUrl))
                Directory.CreateDirectory(completeUrl);

            completeUrl = completeUrl + fileName;
            int intentos = 0;

            bool guarda = Intermedio(completeUrl, titulo, mensaje1, mensaje2);
            if (!guarda)
            {
                intentos++;
                if (intentos < 3)
                    Intermedio(completeUrl, titulo, mensaje1, mensaje2);
            }
        }
        private static bool Intermedio(string completeUrl, string titulo, string mensaje1, string mensaje2)
        {
            try
            {
                ExecuteLog(completeUrl, titulo, mensaje1, mensaje2);
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }
        }
        private static void ExecuteLog(string completeUrl, string titulo, string mensaje1, string mensaje2)
        {
            using (StreamWriter w = File.AppendText(completeUrl))
            {
                w.WriteLine(string.Format("{0} - {1}", DateTime.Now, titulo));
                w.WriteLine(mensaje1);
                w.WriteLine(mensaje2);
                w.WriteLine("---------------------------------------------------------------------------------------");
            }
        }
    }

}