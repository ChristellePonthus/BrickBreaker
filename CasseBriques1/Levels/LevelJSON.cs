using System.Runtime.Serialization;

namespace BrickBreaker.Levels
{
    [DataContract]
    public class LevelJSON
    {
        [DataMember]
        public string LevelNum;
    }
}
