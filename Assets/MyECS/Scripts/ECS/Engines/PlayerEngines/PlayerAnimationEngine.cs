using System.Collections;
using ProjectR.ECS.Net;
using Svelto.ECS;
using Svelto.Tasks;

namespace ProjectR.ECS.Player
{
    public class PlayerAnimationEngine : SingleEntityEngine<PlayerEntityView>, IQueryingEntitiesEngine
    {
        public IEntitiesDB entitiesDB { get; set; }
        public void Ready()
        {
            _taskRoutine.Start();
        }
        
        public PlayerAnimationEngine()
        {
//            _taskRoutine = TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumerator(PhysicsTick()).SetScheduler(StandardSchedulers.physicScheduler);
            _taskRoutine = _taskRoutine =
                TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumeratorProvider(PhysicsTick);
        }
        
        IEnumerator PhysicsTick()
        {
            while (entitiesDB.HasAny<PlayerEntityView>() == false)
            {
                yield return null; //skip a frame
            }

            int targetsCount;
            var playerEntityViews = entitiesDB.QueryEntities<PlayerEntityView>(out targetsCount);
            var playerInputDatas = entitiesDB.QueryEntities<PlayerInputDataStruct>(out targetsCount);
            var netDatas = entitiesDB.QueryEntities<NetworkDataStruct>(out targetsCount);
            while (true)
            {
//                playerEntityViews[0].infoComponent.playerName = netDatas[0].playerName;
//                playerEntityViews[0].infoComponent.playerName = PhotonNetwork.playerName;
                var input = playerInputDatas[0].input;
                
                bool walking = input.x != 0f || input.z != 0f;
                
                playerEntityViews[0].animationComponent.setState("IsWalking", walking);

                yield return null;
            }
        }        

        protected override void Add(ref PlayerEntityView entityView)
        {}

        protected override void Remove(ref PlayerEntityView entityView)
        {
            _taskRoutine.Stop();
        }
        
        readonly ITaskRoutine _taskRoutine;
    }
}
