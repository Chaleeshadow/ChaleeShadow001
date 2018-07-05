using System.IO;
using UnityEngine;
namespace ProjectR.ECS
{
    [ExecuteInEditMode]
    public class SpawningData : MonoBehaviour
    {
        private static bool serializedSpawnDataOnce;

        private void Awake()
        {
            if (serializedSpawnDataOnce == false)
                SerializeSpawnData();
        }

        public void SerializeSpawnData()
        {
            serializedSpawnDataOnce = true;

            var data = GetComponents<ClientPlayerData>();
            JSonClientPlayerSpawnData[] spawningdata = new JSonClientPlayerSpawnData[data.Length];
            
            for(int i = 0; i < data.Length; i++)
                spawningdata[i] = new JSonClientPlayerSpawnData(data[i].spawnData);

            var json = JsonHelper.arrayToJson(spawningdata);
            Utility.Console.Log(json);
            File.WriteAllText(Application.persistentDataPath + "/ClientPlayerSpawningData.json", json);            
        }
                
    }
}