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

        /// <summary>
        /// armazenate the new score, sort the scores and armazenate in a new file
        /// </summary>
        /// <param name="plays"></param>
        /// <param name="scores"></param>
        public void ArmazenateScores(int plays, List<int> scores)
        {
            //add the last score to the list
            scores.Add(plays);

            //sort the list
            scores.Sort();
            
            //delete the last file
            File.Delete(filePath);
            
            //create a new file with the same name
            File.Create("HighScores.txt");


            using StreamWriter writer = new StreamWriter(filePath);
            
            //rewrite the new scores order on the new file
            foreach(int s in scores)
            {
                writer.WriteLine("{i}");
            }

            writer.Close();

        }

    }
}