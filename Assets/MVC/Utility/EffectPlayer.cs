using UnityEngine;
using System;
using UniRx;

namespace ProjectR.MVC
{
    public class EffectPlayer : MonoBehaviour
    {
        [SerializeField]
        GameObject effectPrefab;

        void Start()
        {
            var effect = Instantiate(effectPrefab);
            effect.transform.SetParent(transform, false);
            var particle = effect.GetComponent<ParticleSystem>();

            Observable.Interval(TimeSpan.FromSeconds(particle.main.duration))
                .Take(1)
                .Subscribe(_ => Destroy(gameObject))
                .AddTo(this);
        }
    }
}
