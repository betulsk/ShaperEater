using UnityEngine;
using UnityEngine.UIElements;

public class SimpleMovementBehaviour : MonoBehaviour
{
    private Vector3 position;
    private float width;
    private float height;
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private Transform _upBoundry;
    [SerializeField] private Transform _downBoundry;
    [SerializeField] private CharacterController _characterController = null;

    [SerializeField] private float _xSpeed = 2f;
    [SerializeField] private float _zSpeed = 2.0f;
    [SerializeField] private float _ySpeed = -1f;
    [SerializeField] private bool _isGameEnded;
    public float moveSpeed = 5.0f;  // Karakterin yatay hareket hýzý
    public float verticalSpeed = 2.0f;  // Fare yönünde yukarý/aþaðý hareket hýzý
    public float minY = -2.0f;  // Y ekseninin minimum sýnýrý
    public float maxY = 2.0f;

    public void Move(float swipeAmount)
    {
        var characterPosition = _characterTransform.position;
        Vector3 sideWayDir = _characterTransform.right * (swipeAmount - characterPosition.y);

        var direction = _characterTransform.forward * _zSpeed +
                            sideWayDir * _xSpeed +
                            new Vector3(0, 0, 0);
        _characterController.Move(direction /*Vector3.forward * _xSpeed*/ * Time.deltaTime);
    }

    private bool TryMove()
    {
        if (!_isGameEnded)
        {
            return true;
        }
        return false;
    }

    private void Update()
    {
        if (TryMove())
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPos.z = 0f;
                _characterTransform.position = new Vector3(_characterTransform.position.x, mouseWorldPos.y, 0);
                Debug.Log("Mouse Pos: " + mouseWorldPos);

            }
        }

    }
    private void LateUpdate()
    {
        KeepOnPlatform();
    }
    private void KeepOnPlatform()
    {
        var characterPosition = _characterTransform.position;

        if (characterPosition.y > _upBoundry.position.y)
        {
            _characterTransform.position = new Vector3(characterPosition.x
                , _upBoundry.position.y
                , characterPosition.z);
        }
        else if (characterPosition.y < _downBoundry.position.y)
        {
            _characterTransform.position = new Vector3(characterPosition.x
                , _downBoundry.position.y
                , characterPosition.z);
        }
    }
}
