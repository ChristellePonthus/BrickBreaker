using System.Runtime.Serialization;

namespace BrickBreaker
{
    [DataContract]
    public class LevelJSON
    {
        [DataMember]
        public int levelNum;
        [DataMember]
        public int[][] levelData;

        public void ConvertForRead(ref int[,] pLevelData)
        {
            int nbLines = levelData.Length-1;
            int nbColumns = levelData[0].Length-1;

            for (int l = 0; l < nbLines; l++)
            {
                for (int c = 0; c < nbColumns; c++)
                {
                    pLevelData[l, c] = levelData[l][c];
                }
            }
        }
    }
}
