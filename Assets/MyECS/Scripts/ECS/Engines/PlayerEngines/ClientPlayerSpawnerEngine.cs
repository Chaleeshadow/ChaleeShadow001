using Svelto.ECS;
using System.Collections;
using System.Collections.Generic;
using Svelto.Tasks.Enumerators;
using System.IO;
using System.Runtime.InteropServices;
using ProjectR.ECS.Net;
using UnityEngine;

namespace ProjectR.ECS.Player
{
    public class ClientPlayerSpawnerEngine : IStep<EGID> ,IQueryingEntitiesEngine
    {
        int num;
        public IEntitiesDB entitiesDB { get; set; }
        readonly IClientFactory _clientFactory;
        readonly IEntityFunctions _entityFunctions;        
        readonly WaitForSecondsEnumerator  _waitForSecondsEnumerator = new WaitForSecondsEnumerator(SECONDS_BETWEEN_SPAWNS);
        const int SECONDS_BETWEEN_SPAWNS = 1;
        public ClientPlayerSpawnerEngine(IClientFactory clientPlayerFactory,
                                         IEntityFunctions entityFunctions)
        {
            _entityFunctions = entityFunctions;
            _clientFactory = clientPlayerFactory;
//            num = 1;
            num = PhotonNetwork.room.playerCount;
        }
        public void Ready()
        {
            IntervaledTick().Run();
        }

        IEnumerator IntervaledTick()
        {
            while (true)
            {
                yield return _waitForSecondsEnumerator;{
                    var clientPlayersSpawn = ReadClientPlayerspawningDataServiceRequest();
                    int targetsCount;                     
                    var netDatas = entitiesDB.QueryEntities<NetworkDataStruct>(out targetsCount);
                    var netEntityViews = entitiesDB.QueryEntities<NetEntityView>(out targetsCount);
                    
                    for (int i = 0; i < targetsCount; i++)
                    {
                       
                        netEntityViews[i].netComponent.countPlayer = PhotonNetwork.room.playerCount;
                        if (netEntityViews[i].netComponent.isJoinedRoom)
                        {                            
//                            for (int j = num ; j != netEntityViews[i].netComponent.countPlayer  ; ++j)
//                            {                     
//                                
//                                _clientFactory.Build(clientPlayersSpawn[0].clientPlayerSawnData);
////                            netDatas[j].playerName = PhotonNetwork.playerName;
//                                Utility.Console.Log("Build " + PhotonNetwork.playerName);
////                                namecheck = PhotonNetwork.playerName;
//                                Utility.Console.Log("user: " + PhotonNetwork.room.playerCount);
//                                num++;
//
//
//                            }
                            for (int j = num; j >= 0 && num >= PhotonNetwork.room.playerCount; --j)
                            {
                                _clientFactory.Build(clientPlayersSpawn[0].clientPlayerSawnData);
                                Utility.Console.Log(num.ToString());
                                num = num - num;
                            }
                        }
                    }
                }
                
            }
        }


        static JSonClientPlayerSpawnData[] ReadClientPlayerspawningDataServiceRequest()
        {
            string json =
                File.ReadAllText(UnityEngine.Application.persistentDataPath + "/ClientPlayerSpawningData.json");
            JSonClientPlayerSpawnData[] clientPlayerstoSpawn = JsonHelper.getJsonArray<JSonClientPlayerSpawnData>(json);
            return clientPlayerstoSpawn;
        }
        
        public void Step(ref EGID token, int condition)
        {
//            num = PhotonNetwork.room.playerCount;
//            num++;
        }
    }
}
