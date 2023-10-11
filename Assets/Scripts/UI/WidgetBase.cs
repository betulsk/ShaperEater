using DG.Tweening;
using UnityEngine;

public class WidgetBase : MonoBehaviour
{
    private Tween _fadeTween;

    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _duration;

    private void Fade(float endValue, float duration, TweenCallback onEnded)
    {
        if (_fadeTween != null)
        {
            _fadeTween.Kill(false);
        }
        _fadeTween = _canvasGroup.DOFade(endValue, duration);
        _fadeTween.onComplete += onEnded;
    }

    public void FadeIn()
    {
        Fade(1f, _duration, () =>
        {
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        });
    }

    public void FadeOut()
    {
        Fade(0f, _duration / 2, () =>
        {
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        });
    }
}
