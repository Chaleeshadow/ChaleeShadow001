using System.Collections;
using System.Collections.Generic;
using Svelto.ECS;
using UnityEngine;

namespace ProjectR.ECS.Net
{
    public class NetEntityView : IEntityViewStruct
    {
        public INetComponent netComponent;
        public EGID ID { get; set; }

    }
    
    
    public interface INetComponent : IComponent
    {
//        bool isPlayer { get; }
//        bool isConned { get; }
        bool AutoConnect { get; }
        bool isJoinedRoom { get; }
//        int vidpun { get; set; }
//        PhotonView photonview { get; }
        GameObject netObj { get; }
        int countPlayer { get; set; }
//        ClientPlayerFactory clientPF { get; set; }
    }
}

