using System.Collections;
using System.Collections.Generic;
using System.IO;
using ProjectR.ECS.Player;
using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

namespace ProjectR.ECS.Net
{
	public class ConnectAndJoinRandomImplementor : MonoBehaviour, IImplementor,
		INetComponent
	{
		PhotonView m_PhotonView;
		public IClientFactory _clientFactory;
		
		public bool autoConn;

		private void Awake()
		{
			m_PhotonView = GetComponent<PhotonView>();
		}

//		public bool isPlayer
//		{
//			get { return m_PhotonView.isMine; }
//		}	

		
		private bool _isJoinedR = false;
		public bool isJoinedRoom
		{
			get { return _isJoinedR ; }
		}

		public GameObject netObj
		{
			get { return this.gameObject; }
		}

		public int countPlayer { get; set; }

		public bool AutoConnect
		{
			get { return autoConn;}
		}
		private void Start()
		{

			PhotonNetwork.autoJoinLobby = false;
		}

		public virtual void OnFailedToConnectToPhoton(DisconnectCause cause)
		{
			Debug.LogError("Cause: " + cause);
		}

		public void OnJoinedRoom()
		{
			_isJoinedR = true;			
			Debug.Log(PhotonNetwork.room.PlayerCount);
		}
		
		public void OnDisconnectedFromPhoton()
		{
			--countPlayer;
		}

		public void OnLeftRoom()
		{
			--countPlayer;
		}
//		
//        [PunRPC]
//        void SpawnClient(int id1)
//        {
//            Utility.Console.Log("Hello 1 SpawnClient id : "+id1);
//	        var clientPlayersSpawn = ReadClientPlayerspawningDataServiceRequest();
//	        _clientFactory.Build(clientPlayersSpawn[0].clientPlayerSawnData, id1);
//        }
//		
//		static JSonClientPlayerSpawnData[] ReadClientPlayerspawningDataServiceRequest()
//		{
//			string json =
//				File.ReadAllText(UnityEngine.Application.persistentDataPath + "/ClientPlayerSpawningData.json");
//			JSonClientPlayerSpawnData[] clientPlayerstoSpawn = JsonHelper.getJsonArray<JSonClientPlayerSpawnData>(json);
//			return clientPlayerstoSpawn;
//		}
		
	}
}