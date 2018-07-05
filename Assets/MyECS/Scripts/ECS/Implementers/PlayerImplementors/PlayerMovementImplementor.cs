
using UnityEngine;
using UnityEngine.UI;

namespace ProjectR.ECS.Player
{
    public class PlayerMovementImplementor : MonoBehaviour, IImplementor,
        IRigidBodyComponent,
        IAnimationComponent,        
        ISpeedComponent,
        ITransformComponent,
        INetPhotonViewComponent,
        IInfoComponent
    {
        public float speed = 6f;            // The speed that the player will move at.
        [SerializeField] private Text _playerName;
        private PhotonView phView;
        Animator anim;                      // Reference to the animator component.
        Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
        Transform playerTransform;
        
        public bool isKinematic { set { playerRigidbody.isKinematic = value; } }
        public Quaternion rotation { set {playerRigidbody.MoveRotation(value);} }

        public float       movementSpeed { get { return speed; } }
        
        public void setState(string name, bool value)
        {
            anim.SetBool(name, value);
        }

        public void reset()
        {
            anim.Rebind();
        }

        public string playAnimation { set {anim.SetTrigger(value);} }

        void Awake ()
        {
            // Set up references.
            phView = GetComponent<PhotonView>();
            anim = GetComponent<Animator>();
            playerRigidbody = GetComponent<Rigidbody>();
            playerTransform = transform;
        }

        public Vector3 position { get { return playerTransform.position; }  set {playerRigidbody.MovePosition(value);} }

        public PhotonView netView
        {
            get { return phView; }
        }

        public GameObject netObj
        {
            get { return this.gameObject; }
            
        }

        public string playerName
        {
            get { return _playerName.text;}
            set { _playerName.text = value; }
        }
    }
}
