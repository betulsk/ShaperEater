using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameMenuWidget : WidgetBase
{
    [SerializeField] private Button _retryButton;
    [SerializeField] private ParticleSystem _confettiParticle;

    private void Awake()
    {
        GameManager.Instance.OnPhaseChanged += OnPhaseChanged;
        _retryButton.onClick.AddListener(OnRetryButtonClicked);
    }

    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnPhaseChanged -= OnPhaseChanged;
        }
        _retryButton.onClick.RemoveListener(OnRetryButtonClicked);
    }

    private void OnPhaseChanged(EPhase phase)
    {
        if (phase is EPhase.EndGamePhase)
        {
            FadeIn();
            _confettiParticle.Play();
        }
    }

    private void OnRetryButtonClicked()
    {
        FadeOut();
        SceneManager.LoadScene("SampleScene");
        //ToDo:Load Scene
    }
}
