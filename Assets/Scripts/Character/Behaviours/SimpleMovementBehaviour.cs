using UnityEngine;

public class SimpleMovementBehaviour : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController = null;
    [SerializeField] private Transform _characterTransform;
    [SerializeField] private float _xSpeed = 2f;

    //Todo: Remove that referances from managers
    [SerializeField] private bool _isGameEnded;
    [SerializeField] private Transform _upBoundry;
    [SerializeField] private Transform _downBoundry;

    private void Update()
    {
        if (TryMove())
        {
            Move();
        }

    }
    private void LateUpdate()
    {
        KeepOnPlatform();
    }

    public void Move()
    {
        _characterController.Move(Vector3.right * _xSpeed * Time.deltaTime);
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f;
            _characterTransform.position = new Vector3(_characterTransform.position.x, mouseWorldPos.y, 0);
        }
    }

    private bool TryMove()
    {
        if (!_isGameEnded)
        {
            return true;
        }
        return false;
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
