using Svelto.ECS;
using UnityEngine;

namespace ProjectR.ECS.Player
{
    public struct PlayerInputDataStruct : IEntityStruct
    {
        public Vector3 input;        
        public EGID    ID { get; set; }
    }
}