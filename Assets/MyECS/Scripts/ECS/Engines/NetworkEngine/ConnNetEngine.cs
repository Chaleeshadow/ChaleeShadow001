using System.Collections;
using System.Collections.Generic;
using Svelto.ECS;

namespace ProjectR.ECS.Net
{
    public class ConnNetEngine : IQueryingEntitiesEngine 
    {
        public IEntitiesDB entitiesDB { get; set; }
        
        public void Ready()
        {
            Tick().Run();
        }

        IEnumerator Tick()
        {            
            while (true)
            {

                int targetsCount;
                var netEntityViews = entitiesDB.QueryEntities<NetEntityView>(out targetsCount);                          

                for (int i = 0; i < targetsCount; i++)
                {
                    var netDatas = entitiesDB.QueryEntities<NetworkDataStruct>(out targetsCount); 
                    // must config version value from other engine
//                    netDatas[i].Version = 1; 
//                    var versionname = netDatas[i].Version;
                    
                    if (netEntityViews[i].netComponent.AutoConnect && !PhotonNetwork.connected)
                    {
                        PhotonNetwork.ConnectUsingSettings("1");
                        
                    }

//                    if (netEntityViews[i].netComponent.isJoinedRoom)
//                    {
//                        netDatas[i].isJoinedRoom = netEntityViews[i].netComponent.isJoinedRoom;
////                        UnityEngine.Debug.Log(netDatas[i].isJoinedRoom );
////                        OnJoinedRoom();
//                    }                        
                                                        
                }

//                UnityEngine.Debug.Log("GG");


                yield return null;

            }

        }

//        void OnJoinedRoom()
//        {            
//            UnityEngine.Debug.Log("Welcome to Room !!");
//            
//        }
    }            
    
}