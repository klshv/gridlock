using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using gridlock.application;

namespace gridlock.data
{
    public class LevelParser
    {
        public Field Parse(string levelDataJson)
        {
            return JsonConvert.DeserializeObject<Field>(levelDataJson) 
                ?? throw new Exception($"Level file {levelDataJson} is incorrect!");
        }
    }
}
