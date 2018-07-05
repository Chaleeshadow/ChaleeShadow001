
using ProjectR.ECS.Net;
using ProjectR.ECS.Player;

using Svelto.Context;
using Svelto.ECS;
using UnityEngine;
using Svelto.ECS.Schedulers.Unity;
using Svelto.Tasks;


namespace ProjectR.ECS
{
    public class Main : IUnityCompositionRoot
    {
        public Main()
        {
            SetupEnginesAndEntities();
        }
        void SetupEnginesAndEntities()
        {
            _enginesRoot = new EnginesRoot(new UnitySumbmissionEntityViewScheduler());
            _entityFactory = _enginesRoot.GenerateEntityFactory();
            GameObjectFactory factory = new GameObjectFactory();
            var entityFunctions = _enginesRoot.GenerateEntityFunctions();
            IClientFactory clientPlayerFactory = new ClientPlayerFactory(factory, _entityFactory);

            ITime      time      = new Time();
            var connNetEngine = new ConnNetEngine();
//            var testJoinEngine = new TestJoinEngine();
            var spawnerplayer = new ClientPlayerSpawnerEngine(clientPlayerFactory, entityFunctions);
            var playerMovementEngine = new PlayerMovementEngine(time);
            var playerAnimationEngine = new PlayerAnimationEngine();
            
            
                        
                                    
            
            _enginesRoot.AddEngine(connNetEngine);
//            _enginesRoot.AddEngine(testJoinEngine);
            _enginesRoot.AddEngine(spawnerplayer);
            _enginesRoot.AddEngine(playerMovementEngine);
            _enginesRoot.AddEngine(playerAnimationEngine);
            _enginesRoot.AddEngine(new PlayerInputEngine());
            
            
        }
                
        public void OnContextCreated(UnityContext contextHolder)
        {
//            var prefabsDictionary = new PrefabsDictionary(Application.persistentDataPath + "/prefabs.json");
                
            BuildEntitiesFromScene(contextHolder);        
//            BuildPlayerEntities(prefabsDictionary);
//            BuildNetworkEntities(prefabsDictionary);
            
        }

        void BuildPlayerEntities(PrefabsDictionary prefabsDictionary)
        {
            
            var player = prefabsDictionary.Istantiate("Player");     

            var initializer = _entityFactory.BuildEntity<PlayerEntityDescriptor>(player.GetInstanceID(), player.GetComponents<IImplementor>());            
            
        }

        void BuildNetworkEntities(PrefabsDictionary prefabsDictionary)
        {
            var network = prefabsDictionary.Istantiate("Network");
			
        }
        

        void BuildEntitiesFromScene(UnityContext contextHolder)
        {
            
            IEntityDescriptorHolder[] entities = contextHolder.GetComponentsInChildren<IEntityDescriptorHolder>();
            

            for (int i = 0; i < entities.Length; i++)
            {
                var entityDescriptorHolder = entities[i];
                var entityViewsToBuild = entityDescriptorHolder.GetEntitiesToBuild();
                _entityFactory.BuildEntity
                (((MonoBehaviour) entityDescriptorHolder).gameObject.GetInstanceID(),
                    entityViewsToBuild,
                    (entityDescriptorHolder as MonoBehaviour).GetComponentsInChildren<IImplementor>());
            }
        }
        
        public void OnContextInitialized()
        {}
        
        
        public void OnContextDestroyed()
        {   
            _enginesRoot.Dispose();
                        
            TaskRunner.StopAndCleanupAllDefaultSchedulers();
        }

        EnginesRoot    _enginesRoot;
        IEntityFactory _entityFactory;
 }
   
    public class MainContext : UnityContext<Main>
    { }

}