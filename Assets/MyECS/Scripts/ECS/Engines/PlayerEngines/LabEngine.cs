using UnityEngine;
using System.Collections;
using Svelto.ECS;
using Svelto.Tasks;

namespace ProjectR.ECS.Player
{
    public class PlayerGunShootingFXsEngine : SingleEntityEngine<PlayerEntityView>, IQueryingEntitiesEngine
    {


        ITaskRoutine _taskRoutine;
        WaitForSeconds _waitForSeconds;

        protected override void Add(ref PlayerEntityView entityView)
        {
            _waitForSeconds = new WaitForSeconds(1);

        }

        protected override void Remove(ref PlayerEntityView entityView)
        {

        }

        public IEntitiesDB entitiesDB { get; set; }

        public void Ready()
        {
            _taskRoutine = TaskRunner.Instance.AllocateNewTaskRoutine().SetEnumeratorProvider(PhysicsTick);
        }

        IEnumerator PhysicsTick()
        {
            yield return _waitForSeconds;
            Test();
        }

        void Test()
        {
            
        }
    }
}