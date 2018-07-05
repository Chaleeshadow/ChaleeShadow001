using System.Collections;
using ProjectR.ECS;
using ProjectR.ECS.Player;
using Svelto.ECS;
using Svelto.Tasks;
using UnityEngine;

namespace ProjectR.ECS.Player
{
    public class PlayerMovementEngine : SingleEntityEngine<PlayerEntityView>, IQueryingEntitiesEngine
    {
        public IEntitiesDB entitiesDB { get; set; }
        public void Ready()
        {}
        
        public PlayerMovementEngine( ITime time)
        {
            _time = time;
//            _taskRoutine = TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumerator(PhysicsTick()).SetScheduler(StandardSchedulers.physicScheduler);
            _taskRoutine = TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumeratorProvider(PhysicsTick);
        }

        protected override void Add(ref PlayerEntityView entityView)
        {
            _taskRoutine.Start();
        }

        protected override void Remove(ref PlayerEntityView entityView)
        {
            _taskRoutine.Stop();
        }
        
        IEnumerator PhysicsTick()
        {  
            int targetsCount;
            var playerEntityViews = entitiesDB.QueryEntities<PlayerEntityView>(out targetsCount);
            var playerInputDatas = entitiesDB.QueryEntities<PlayerInputDataStruct>(out targetsCount);

            while (true)
            {   
                var phView = playerEntityViews[0].netPhotonViewComponent.netView;
                if (phView.isMine == true)
                {
                    Movement(ref playerInputDatas[0], ref playerEntityViews[0]);
                }


                yield return null; //don't forget to yield or you will enter in an infinite loop!
            }
        }

        
        void Movement(ref PlayerInputDataStruct playerEntityView, ref PlayerEntityView entityView)
        {
        
            Vector3 input = playerEntityView.input;
            
        
            Vector3 movement = input.normalized * entityView.speedComponent.movementSpeed * _time.deltaTime;

        
            entityView.transformComponent.position = entityView.positionComponent.position + movement;
        }
               
        readonly int floorMask = LayerMask.GetMask("Floor");    

        ITaskRoutine _taskRoutine;
        ITime        _time;
    }
}
