using UnityEngine;
using UnityEngine.UI;

public class MainMenuWidget : WidgetBase
{
    [SerializeField] private Button _playButton;

    private void Awake()
    {
        FadeIn();
        _playButton.onClick.AddListener(OnPlayButtonClicked);
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(OnPlayButtonClicked);
    }

    private void OnPlayButtonClicked()
    {
        GameManager.Instance.EnterGamePhase();
        FadeOut();
    }

    //private void Fade(float endValue, float duration, TweenCallback onEnded)
    //{
    //    if (_fadeTween != null)
    //    {
    //        _fadeTween.Kill(false);
    //    }
    //    _fadeTween = _canvasGroup.DOFade(endValue, duration);
    //    _fadeTween.onComplete += onEnded;
    //}

    //private void FadeIn()
    //{
    //    Fade(1f, _duration, () =>
    //    {
    //        _canvasGroup.interactable = true;
    //        _canvasGroup.blocksRaycasts = true;
    //    });
    //}

    //private void FadeOut()
    //{
    //    Fade(0f, _duration / 2, () =>
    //    {
    //        _canvasGroup.interactable = false;
    //        _canvasGroup.blocksRaycasts = false;
    //    });
    //}

}
