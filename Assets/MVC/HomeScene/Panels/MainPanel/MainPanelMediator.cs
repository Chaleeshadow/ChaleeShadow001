using UniRx;
using UnityEngine;
using Zenject;

namespace ProjectR.MVC.HomeScene
{
    public class MainPanelMediator : MediatorBase<MainPanelView>, IInitializable
    {
        public void Initialize()
        {
            view.OnPlayBttonClickedAsObservable().Subscribe(_ => OnPlayButtonClick()).AddTo(view);
            
        }

        void OnPlayButtonClick()
        {
//            Debug.Log("Player Net Name : "+PhotonNetwork.playerName);
            if (PhotonNetwork.countOfRooms == 0)
                PhotonNetwork.CreateRoom("Room " + Random.Range(1, 9999), new RoomOptions() {MaxPlayers = 4}, null);
            else
                PhotonNetwork.JoinRandomRoom();
        }
                
    }
}