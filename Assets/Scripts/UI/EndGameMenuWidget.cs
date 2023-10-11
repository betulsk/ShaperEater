using UnityEngine;
using UnityEngine.UI;

public class EndGameMenuWidget : WidgetBase
{
    [SerializeField] private Button _retryButton;

    private void Awake()
    {
        GameManager.Instance.OnPhaseChanged += OnPhaseChanged;
        _retryButton.onClick.AddListener(OnRetryButtonClicked);
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnPhaseChanged -= OnPhaseChanged;
        _retryButton.onClick.RemoveListener(OnRetryButtonClicked);
    }

    private void OnPhaseChanged(EPhase phase)
    {
        if (phase is EPhase.EndGamePhase)
        {
            FadeIn();
        }
    }

    private void OnRetryButtonClicked()
    {
        FadeOut();
        //ToDo:Load Scene
    }
}
