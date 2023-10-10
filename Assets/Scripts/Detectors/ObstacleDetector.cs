using DG.Tweening;
using UnityEngine;

public class ObstacleDetector : BaseDetector
{
    private Sequence _tween; 
    [SerializeField] private Transform _characterVisualTransform;
    [SerializeField] private float _duration;

    public override void HitCustomActions()
    {
        base.HitCustomActions();
        DOTween.Complete(_characterVisualTransform);
        _characterVisualTransform
            .DOShakePosition(_duration, vibrato: 2, randomness: 5)
            .SetLink(_characterVisualTransform.gameObject);
        Debug.Log("Shake");
    }
}
