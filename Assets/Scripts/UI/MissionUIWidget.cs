using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionUIWidget : WidgetBase
{
    private const string SLASH = "/";
    private MissionManager _missionManager;
    private float _sliderBGImageAlfa;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _missonText;
    [SerializeField] private Image _missionImage;
    [SerializeField] private Image _sliderBGImage;
    [SerializeField] private Image _fillImage;

    private void Awake()
    {
        _missionManager = MissionManager.Instance;
        _missionManager.OnMissionSelected += OnMissionSelected;
        InventoryController.OnDataUpdated += OnDataUpdated;
        _sliderBGImageAlfa = _sliderBGImage.color.a;
        GameManager.Instance.OnPhaseChanged += OnPhaseChanged;
    }

    private void OnDestroy()
    {
        if (MissionManager.Instance != null)
        {
            MissionManager.Instance.OnMissionSelected -= OnMissionSelected;
        }
        InventoryController.OnDataUpdated -= OnDataUpdated;
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnPhaseChanged -= OnPhaseChanged;
        }
    }

    private void OnPhaseChanged(EPhase phase)
    {
        if (phase is EPhase.GamePhase)
        {
            FadeIn();
        }
    }

    private void OnDataUpdated(ECollectibleType collectibleType, int collectedCollectibleCount)
    {
        if (collectibleType == _missionManager.CurrentMission.TargetCollectibleType)
        {
            UpdateMissionWidget(collectedCollectibleCount, _missionManager.CurrentMission.TargetCount);
        }
    }

    private void OnMissionSelected()
    {
        UpdateMissionWidget(0, MissionManager.Instance.CurrentMission.TargetCount);
    }

    public void UpdateMissionWidget(int currentCollectible, int totalCollectible)
    {
        _slider.value = (float)currentCollectible / totalCollectible;
        _missonText.text = currentCollectible + SLASH + totalCollectible;
        _missionImage.sprite = MissionManager.Instance.CurrentMission.MissionImage;
        _missionImage.color = MissionManager.Instance.CurrentMission.MissionColor;
        Color color = new Color();
        color = MissionManager.Instance.CurrentMission.MissionColor;
        color.a = _sliderBGImageAlfa;
        _sliderBGImage.color = color;
        _fillImage.color = MissionManager.Instance.CurrentMission.MissionColor;
    }
}
