using UniRx;
using UnityEngine;
using Zenject;

namespace ProjectR.MVC.HomeScene
{
    public class HomeScneMediator : MediatorBase<HomeSceneView>, IInitializable, ITickable
    {
        [Inject] private HomeSceneEvents.OnConnecting onConEvent;
        [Inject] private HomeSceneEvents.OnConnected onConedEvent;
        
        public void Initialize()
        {
            Debug.Log("Hello HomeScene ");
            PhotonNetwork.automaticallySyncScene = true;
            
            if (PhotonNetwork.connectionStateDetailed == ClientState.PeerCreated)
                PhotonNetwork.ConnectUsingSettings("0.9");

            OnRandomName();
            Observable.EveryAfterUpdate().Subscribe(_ => { PhotonNetwork.playerName = view.inputtedName; }).AddTo(view);

        }

        public void OnRandomName()
        {
            if (string.IsNullOrEmpty(view.inputtedName))
            {
                PhotonNetwork.playerName = "Guest" + Random.Range(1, 9999);
                view.nameInputField.text = PhotonNetwork.playerName;
            } 
        }

        public void Tick()
        {            
            
            if (PhotonNetwork.connected)
            {                
                view.txtnumUser.text = PhotonNetwork.countOfPlayers.ToString();
                view.txtRoom.text = PhotonNetwork.countOfRooms.ToString();
                onConedEvent.Invoke();
            }
            else
            {
                onConEvent.Invoke();
            }
        }
    }
}