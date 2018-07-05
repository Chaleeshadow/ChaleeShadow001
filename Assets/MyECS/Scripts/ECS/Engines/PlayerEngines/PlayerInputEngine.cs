using System.Collections;
using ProjectR.ECS.Player;
using Svelto.ECS;
using Svelto.Tasks;
using UnityEngine;

namespace ProjectR.ECS.Player
{
   
    public class PlayerInputEngine:SingleEntityEngine<PlayerEntityView>, IQueryingEntitiesEngine
    {
        public IEntitiesDB entitiesDB { get; set; }
        public void Ready()
        {}
        public PlayerInputEngine()
        {
            _taskRoutine = TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumeratorProvider(ReadInput);
        }

        IEnumerator ReadInput()
        {
            while (entitiesDB.HasAny<PlayerEntityView>() == false)
            {
                yield return null; //skip a frame
            }
            
            int targetsCount;
            var playerInputDatas = entitiesDB.QueryEntities<PlayerInputDataStruct>(out targetsCount);
            var playerEntityViews = entitiesDB.QueryEntities<PlayerEntityView>(out targetsCount);
           
            while (true)
            {
//                var Obj = playerEntityViews[0].netPhotonViewComponent.netObj;
//                var photonViewobj = Obj.GetComponent<PhotonView>();
                var phView = playerEntityViews[0].netPhotonViewComponent.netView;
                if (phView.isMine == true)
                {
                    float h = Input.GetAxisRaw("Horizontal");
                    float v = Input.GetAxisRaw("Vertical");

                    playerInputDatas[0].input = new Vector3(h, 0f, v);
                }

                yield return null;
            }
        }

        protected override void Add(ref PlayerEntityView entityView)
        {
            _taskRoutine.Start();
        }

        protected override void Remove(ref PlayerEntityView entityView)
        {
            _taskRoutine.Stop();
        }
        
        ITaskRoutine _taskRoutine;
    }
}