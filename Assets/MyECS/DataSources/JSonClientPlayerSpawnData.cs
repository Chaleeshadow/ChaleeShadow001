using System;
using UnityEngine;
namespace ProjectR.ECS
{
    [Serializable]
    public class JSonClientPlayerSpawnData
    {
        public ClientPlayerSpawnData clientPlayerSawnData;

        public JSonClientPlayerSpawnData(ClientPlayerSpawnData spawnData)
        {
            clientPlayerSawnData = spawnData;
        }

    }

    [Serializable]
    public class ClientPlayerSpawnData
    {
        public GameObject    clientPlayerPrefab;
        public Transform[]   spawnPoints;
        public float         spawnTime;
        
    }
}