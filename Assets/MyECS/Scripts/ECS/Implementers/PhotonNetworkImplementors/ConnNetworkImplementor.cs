using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonoBehaviour = Photon.MonoBehaviour;

namespace ProjectR.ECS.Net
{
	public class ConnNetworkImplementor : MonoBehaviour, IImplementor
	{
		PhotonView m_PhotonView;
		public string versionName = "0.1";
		private void Awake()
		{
			m_PhotonView = GetComponent<PhotonView>();
		}

		private void Start()
		{
			connectToPhoton();
		}

		public bool isPlayer
		{
			get { return m_PhotonView.isMine; }
		}
				
		public void connectToPhoton()
		{
			PhotonNetwork.ConnectUsingSettings(versionName);
			Debug.Log("Connectin to photon...");
		}

		private void OnConnectedToMaster()
		{
			PhotonNetwork.JoinLobby(TypedLobby.Default);
			Debug.Log("We are connected to master");
		}

		private void OnJoinedLobby()
		{
			Debug.Log("On Joined Lobby");
		}

		private void OnDisconnectedFromServer(NetworkDisconnection info)
		{
			Debug.Log("Dis from photon services");
		}


	}
}