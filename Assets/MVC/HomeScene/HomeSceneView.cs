using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectR.MVC.HomeScene
{
    public class HomeSceneView : MonoBehaviour, IView
    {
        [SerializeField] public InputField nameInputField;
        [SerializeField] public Text txtnumUser;
        [SerializeField] public Text txtRoom;
        [SerializeField] private Text txtVer;
        
        public string inputtedName
        {
            get { return nameInputField.text; }            
        }

        public IObservable<string> OnChangedNameInputField()
        {            
            return nameInputField.OnValueChangedAsObservable();
        }
       
        public void FocusToInputField()
        {
            nameInputField.ActivateInputField();
            nameInputField.Select();
        }
        
        public void OnCreatedRoom()
        {
            Debug.Log("OnCreatedRoom");
            PhotonNetwork.LoadLevel("ECSGame");
        }
    }
}