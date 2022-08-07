using gridlock.application;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace gridlock.data
{
    public class LevelDataService
    {
        public Field LoadLevel(int levelNumber)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();
            var resourceName = $"gridlock.levels.{levelNumber}.json";

            using (Stream stream = currentAssembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();

                var parser = new LevelParser();
                return parser.Parse(result);
            }
        }
    }
}
