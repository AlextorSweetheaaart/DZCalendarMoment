using CalendarForTeacherPrikhodkoAP42IS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace CalendarForTeacherPrikhodkoAP42IS
{
    public static class ConnetWithjson
    {
        const string HOLYDAYS_PATH = "Holydays.json";

        public static List<Holyday> getHolydays()
        {
            List<Holyday> holydays = new List<Holyday>();
            try
            {
                string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string json = File.ReadAllText(Path.Combine(dir, HOLYDAYS_PATH));
                holydays = JsonSerializer.Deserialize<List<Holyday>>(json);
            }
            catch (System.Exception e) { MessageBox.Show($"C праздниками!\n{e.Message}", "Уведомление об ошибке", MessageBoxButton.OK, MessageBoxImage.Error); }

            return holydays;
        }
    }
}
