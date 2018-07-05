using UnityEngine;

namespace ProjectR.ECS
{
    public interface IAnimationComponent: IComponent
    {
        void setState(string name, bool value);
        void reset();
        string playAnimation { set; }
    }

    public interface IPositionComponent: IComponent
    {
        Vector3 position { get; }
    }

    public interface ITransformComponent: IPositionComponent
    {
        new Vector3 position { set; }
        Quaternion rotation { set; }
    }

    public interface IRigidBodyComponent: IComponent
    {
        bool isKinematic { set; }
    }

    public interface ISpeedComponent: IComponent
    {
        float movementSpeed { get; }
    }

    public interface IDamageSoundComponent: IComponent
    {
        AudioType playOneShot { set; }
    }

}
