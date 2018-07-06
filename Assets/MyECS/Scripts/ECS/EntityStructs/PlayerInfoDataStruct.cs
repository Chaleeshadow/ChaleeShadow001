using Svelto.ECS;

namespace ProjectR.ECS.Player
{   
    public struct PlayerInfoDataStruct : IEntityStruct
    {
        public int playerName;
        public Profile playerInfo;
        public EGID ID { get; set; }
    }
    public struct Profile
    {
        public string playerName;

        public Profile(string playerName)
        {            
            this.playerName = playerName;
        }
    }
    
}