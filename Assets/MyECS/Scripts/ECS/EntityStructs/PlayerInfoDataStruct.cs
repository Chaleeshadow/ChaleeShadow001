using Svelto.ECS;

namespace MyECS.Scripts.ECS.EntityStructs
{
    public class PlayerInfoDataStruct: IEntityStruct
    {
        public string playerName { get; set; }
        public EGID ID { get; set; }
    }
}