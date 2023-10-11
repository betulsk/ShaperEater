using UnityEngine;

public class BackgroundTillingController : MonoBehaviour
{
    [SerializeField] private Material _bgMaterial;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private bool _isRunning = false;

    private float _yOffset = 0f;

    private void Start()
    {
        GameManager.Instance.OnPhaseChanged += OnPhaseChanged;
    }

    private void OnPhaseChanged(EPhase phase)
    {
        if (phase is EPhase.GamePhase)
        {
            _isRunning = true;
        }
        if (phase is EPhase.EndGamePhase) 
        {
            _isRunning = false;
        }
    }

    private void FixedUpdate()
    {
        if (_isRunning)
        {
            _yOffset += Time.deltaTime * _speed;
            _bgMaterial.SetFloat("_Float", _yOffset);
        }
        else
        {
            //_tapeMaterial.mainTextureOffset = Vector2.zero;
            _bgMaterial.SetFloat("_Float", -0.17f);

        }

    }
}
