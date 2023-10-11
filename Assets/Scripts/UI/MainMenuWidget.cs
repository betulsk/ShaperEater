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
        _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        GameManager.Instance.EnterGamePhase();
        FadeOut();
        gameObject.SetActive(false);
    }
}
