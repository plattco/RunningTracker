using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;
using Xamarin.Essentials;
using System.Reflection;

namespace RunningApp
{
    public class DB
    {
        private static string DBName = "log.db";
        public static SQLiteConnection conn;
        public static void OpenConnection()
        {
            string libFolder = FileSystem.AppDataDirectory;
            string fname = System.IO.Path.Combine(libFolder, DBName);
            conn = new SQLiteConnection(fname);
            conn.CreateTable<Run>();
        }
        public static void DeleteTableContents(string tableName)
        {
            int v = conn.Execute("DELETE FROM " + tableName);
        }
        public static void RepopulateTables()
        {
            LoadRuns();
        }
        public static void LoadRuns()
        {
            try
            {
                DeleteTableContents("run");
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly;
                Stream stream = assembly.GetManifestResourceStream("TrainingDB.log.txt");
                StreamReader input = new StreamReader(stream);
                while (!input.EndOfStream)
                {
                    string line = input.ReadLine();
                    Run run = Run.ParseCSV(line);
                    conn.Insert(run);
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}