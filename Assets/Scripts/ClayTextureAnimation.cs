using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ClayTextureAnimation : MonoBehaviour
{
    private const string MainTex = "_MainTex";

    [SerializeField] private float _xSpeed;
    [SerializeField] private float _ySpeed;

    private float _curveX;
    private float _curveY;
    private Renderer _renderer;

    private void OnValidate()
    {
        _xSpeed = Mathf.Clamp(_xSpeed, 0, float.MaxValue);
        _ySpeed = Mathf.Clamp(_ySpeed, 0, float.MaxValue);
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        _curveX = _renderer.material.mainTextureOffset.x;
        _curveY = _renderer.material.mainTextureOffset.y;
    }

    private void FixedUpdate()
    {
        AddDeltaTime(ref _curveX, _xSpeed);
        AddDeltaTime(ref _curveY, _ySpeed);

        _renderer.material.SetTextureOffset(MainTex, new Vector2(_curveX, _curveY));
    }

    private void AddDeltaTime(ref float curve, float speed)
    {
        curve += Time.deltaTime * speed;
    }
}
