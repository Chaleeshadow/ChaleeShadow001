using System.Collections;
using System.Collections.Generic;
using Svelto.ECS;

namespace ProjectR.ECS.Net
{
    public class TestJoinEngine : IQueryingEntitiesEngine 
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
                var netDatas = entitiesDB.QueryEntities<NetworkDataStruct>(out targetsCount);
                for (int i = 0; i < targetsCount; i++)
                {
                    
//                    if (netDatas[i].isJoinedRoom)
//                    {
//
//                        OnJoinedRoom();
//                    }
                                                                                
                }

                yield return null;

            }

        }

        void OnJoinedRoom()
        {            
            UnityEngine.Debug.Log("TestJoinEngine::OnJoinedRoom Welcome to Room !!");
            
        }
    }            
    
}