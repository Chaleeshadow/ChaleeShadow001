using Svelto.ECS;
using UnityEngine;

namespace ProjectR.ECS.Player
{
    public struct PlayerEntityView : IEntityViewStruct
    {
        public ISpeedComponent         speedComponent;
        public IRigidBodyComponent     rigidBodyComponent;
        public IPositionComponent      positionComponent;
        public IAnimationComponent     animationComponent;
        public ITransformComponent     transformComponent;
        public INetPhotonViewComponent netPhotonViewComponent;
        public IInfoComponent          infoComponent;
        public EGID ID { get; set; }
    }

    public interface IInfoComponent : IComponent
    {
        string    playerName { set; }    
    }
    
    public interface INetPhotonViewComponent : IComponent
    {
        PhotonView netView { get; }
        GameObject netObj { get; }

    }    
}

