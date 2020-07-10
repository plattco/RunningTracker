using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RunningApp
{
    [Table("run")]
    public class Run 
    { 
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public DateTime datePerformed { get; set; }

    public TimeSpan Duration { get; set; }

    public int distanceMile { get; set; }

    public int distanceDec { get; set; }

        public string unit = "";


        public override string ToString()
        {
            var unitPref = Xamarin.Essentials.Preferences.Get("val", "miles");
            unit = unitPref;

            return string.Format("Date: {0} Distance: {1}.{2} {3} Duration: {4}", datePerformed.ToString("MM/dd/yyyy"), distanceMile, distanceDec, unit, Duration);
        }

        public static Run ParseCSV(string line)
        {
            string[] toks = line.Split(',');
            Run run = new Run
            {
                datePerformed = DateTime.Parse(toks[0]),
                distanceMile = Int32.Parse(toks[1]),
                distanceDec = Int32.Parse(toks[2]),
                Duration = TimeSpan.Parse(toks[3])
            };
            return run;
        }
    }

    
      
    }
