using UnityEngine;

public class ChainTouchMover : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;
    [SerializeField] private float _offsetSpeed;

    private Vector3 _lastMousePosition;
    private Vector3 _mousePosition;
    private Vector3 _target;


    private void OnValidate()
    {
        _offsetSpeed = Mathf.Clamp(_offsetSpeed, 0, float.MaxValue);
        _speed = Mathf.Clamp(_speed, 0, float.MaxValue);
    }


    private void Update()
    {
        float xDifference = 0;

        if (Input.GetMouseButton(0))
        {
            _mousePosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            xDifference = _mousePosition.x - _lastMousePosition.x;
            _lastMousePosition = _mousePosition;
        }

        _target = transform.position;
        _target.x += xDifference * Time.deltaTime * _offsetSpeed;

        transform.position = _target + transform.forward * _speed * Time.deltaTime;
    }
}
