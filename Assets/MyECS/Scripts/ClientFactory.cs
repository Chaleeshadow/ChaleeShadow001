using ProjectR.ECS.Player;
using Svelto.ECS;
using Svelto.Factories;
using UnityEngine;

namespace ProjectR.ECS
{
    public class ClientPlayerFactory : IClientFactory
    {        
        readonly IGameObjectFactory _gameobjectFactory;
        readonly IEntityFactory     _entityFactory;
        public ClientPlayerFactory(IGameObjectFactory gameObjectFactory,
            IEntityFactory entityFactory)
        {
            _gameobjectFactory = gameObjectFactory;
            _entityFactory = entityFactory;
        }
        
        public void Build(ClientPlayerSpawnData clientPlayerSpawnData)
        {
            int spawnPointIndex = UnityEngine.Random.Range(0, clientPlayerSpawnData.spawnPoints.Length);

//            var go = PhotonNetwork.Instantiate("ClientPlayer", new Vector3(Random.RandomRange(-3.0f, 3.0f),0,Random.RandomRange(-3.0f, 3.0f)), Quaternion.identity,0 );
            var go = PhotonNetwork.Instantiate(clientPlayerSpawnData.clientPlayerPrefab.name, clientPlayerSpawnData.spawnPoints[spawnPointIndex].position, Quaternion.identity, 0);
            var implementors = go.GetComponentsInChildren<IImplementor>();
            var initializer = _entityFactory.BuildEntity<PlayerEntityDescriptor>(go.GetInstanceID(), implementors);

            var transform = go.transform;
            var spawnInfo = clientPlayerSpawnData.spawnPoints[spawnPointIndex];

//            transform.position = spawnInfo.position;
            transform.rotation = spawnInfo.rotation;
        }
        
        public void Build(ClientPlayerSpawnData clientPlayerSpawnData, int id1)
        {
            int spawnPointIndex = UnityEngine.Random.Range(0, clientPlayerSpawnData.spawnPoints.Length);

            var go = _gameobjectFactory.Build(clientPlayerSpawnData.clientPlayerPrefab);
            PhotonView[] nViews = go.GetComponentsInChildren<PhotonView>();
            nViews[0].viewID = id1;

            var implementors = go.GetComponentsInChildren<IImplementor>();
            var initializer = _entityFactory.BuildEntity<PlayerEntityDescriptor>(go.GetInstanceID(), implementors);

            var transform = go.transform;
            var spawnInfo = clientPlayerSpawnData.spawnPoints[spawnPointIndex];

            transform.position = spawnInfo.position;
            transform.rotation = spawnInfo.rotation;
        }

    }
}