using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace Blackout
{
    public class HighScore 
    {
        private int numOfPlays;


        private string filePath = @"c:Blackout\HighScores";


        public void ArmazenateScores(int plays, List<int> scores)
        {
            //StreamReader reader = new StreamReader(filePath);
            scores.Add(plays);

            scores.Sort();

            List<int> list = new List<int>();
            foreach(int i in scores)
            {
                list.Add(i);
            }
            File.Delete(filePath);

            File.Create("HighScores.txt");

            using StreamWriter writer = new StreamWriter(filePath);
            
            foreach(int s in scores)
            {
                writer.WriteLine("{i}");
            }


        }

    }
}