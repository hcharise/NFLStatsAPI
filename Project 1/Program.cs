using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Project1
{
    class Program
    {
        static void Main()
        {
            // Read JSON content
            string jsonContent = File.ReadAllText(@"C:\Users\hchar\OneDrive\Other\Desktop\team49ers_season2020_a.json");

            // Deserialize to the Root class
            var jsonFile = JsonConvert.DeserializeObject<Root>(jsonContent);

            if (jsonFile != null && jsonFile.matchUpStats != null)
            {
                foreach (var matchUpStat in jsonFile.matchUpStats)
                {
                    Console.WriteLine($"Match Date: {matchUpStat.date}");
                    Console.WriteLine($"\tHome Team: {matchUpStat.homeTeamName}, Score: {matchUpStat.homeStats?.score}");
                    Console.WriteLine($"\tVisiting Team: {matchUpStat.visTeamName}, Score: {matchUpStat.visStats?.score}");
                }
            }
        }
    }

    public class Root
    {
        public List<MatchUpStats> matchUpStats { get; set; }
    }

    public class MatchUpStats
    {
        public bool neutral { get; set; }
        public string visTeamName { get; set; }
        public TeamStats visStats { get; set; }
        public string homeTeamName { get; set; }
        public TeamStats homeStats { get; set; }
        public bool isFinal { get; set; }
        public string date { get; set; }
    }

    public class TeamStats
    {
        public string statIdCode { get; set; }
        public string gameCode { get; set; }
        public int teamCode { get; set; }
        public string gameDate { get; set; }
        public int rushYds { get; set; }
        public int rushAtt { get; set; }
        public int passYds { get; set; }
        public int passAtt { get; set; }
        public int passComp { get; set; }
        public int penalties { get; set; }
        public int penaltYds { get; set; }
        public int fumblesLost { get; set; }
        public int interceptionsThrown { get; set; }
        public int firstDowns { get; set; }
        public int thridDownAtt { get; set; }
        public int thirdDownConver { get; set; }
        public int fourthDownAtt { get; set; }
        public int fourthDownConver { get; set; }
        public int timePoss { get; set; }
        public int score { get; set; }
    }
}