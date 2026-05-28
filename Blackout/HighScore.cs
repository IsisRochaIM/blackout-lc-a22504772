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
            //add the last score to the list
            scores.Add(plays);

            //sort the list
            scores.Sort();

            //create a temporary list
            List<int> list = new List<int>();

            //add the numbers to the temporary list
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

            writer.Close();

        }

    }
}