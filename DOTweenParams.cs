using DG.Tweening;
using UnityEngine;

namespace BBExtensions.DOTweenExt
{
    [System.Serializable]
    public class DOTweenParams
    {
        public bool CustomEase;
        public Ease StandardEase;
        public float Duration;
        public AnimationCurve AnimationCurve;

        public DOTweenParams(bool customEase, Ease standardEase, float duration, AnimationCurve animationCurve)
        {
            CustomEase = customEase;
            StandardEase = standardEase;
            Duration = duration;
            AnimationCurve = animationCurve;
        }
    }
}