﻿
using Svelto.ECS;
using UnityEngine;

namespace ProjectR.ECS.Net
{
	public struct NetworkDataStruct : IEntityStruct
	{
		
//		public bool isJoinedRoom;
//		public int vidpun;
//		public PhotonView photonView;
//		public IClientFactory clientFactory;
//		public GameObject StruObj;
//		public Transform StruTrfm;
//		public bool isPlayer;
//		public PhontonData phData;
		public GameObjectData gameData;
//		public string playerName;
		public int testnum;
		public PlayerInfo playerInfo;
		public EGID    ID { get; set; }
	}

//	public struct PhontonData
//	{
//		public EGID otherEntityID;
//		public PhotonView view;
//
//		public PhontonData(EGID otherEntiD, PhotonView view)
//		{
//			this.otherEntityID = otherEntiD;
//			this.view = view;
//		}
//	}

	public struct PlayerInfo
	{
		public EGID ID;
		public string playerName;

		public PlayerInfo(EGID ID,string playerName)
		{
			this.ID = ID;
			this.playerName = playerName;
		}
	}
	
	public struct GameObjectData
	{
		public EGID ID;
		public GameObject obj;

		public GameObjectData(EGID ID, GameObject obj)
		{
			this.ID = ID;
			this.obj = obj;
		}
	}
	
}