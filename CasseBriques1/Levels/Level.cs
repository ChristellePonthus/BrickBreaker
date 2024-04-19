using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;

namespace BrickBreaker
{
    public class Level
    {
        public int levelNum;
        public int[,] levData;

        public Level(int pLevelNum)
        {
            levelNum = pLevelNum;
            levData = new int[20, 10];
            LoadLevel(pLevelNum);
        }

        public void LoadLevel(int pLevelNum)
        {
            string jsonDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Levels\\Level_" + pLevelNum + ".json");
            
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(File.ReadAllText(jsonDirectory)));
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(LevelJSON));
            LevelJSON myLevelJSON = (LevelJSON)ser.ReadObject(stream);

            myLevelJSON.ConvertForRead(ref levData);

            levelNum = pLevelNum;
        }
    }
}
