using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _goInWaterSpeed;
    [SerializeField] private float _getOutOfWaterSpeed;
    [SerializeField] private float _offsetY;

    private Coroutine _goInWaterJob;
    private Coroutine _getOutOfWaterJob;
    private Vector3 _startPosition;

    private void OnValidate()
    {
        _goInWaterSpeed = Mathf.Clamp(_goInWaterSpeed, 0, float.MaxValue);
        _getOutOfWaterSpeed = Mathf.Clamp(_getOutOfWaterSpeed, 0, float.MaxValue);
        _offsetY = Mathf.Clamp(_offsetY, 0, float.MaxValue);
    }

    private void Update()
    {
        if (transform.position.y == _startPosition.y)
        {
            if (_getOutOfWaterJob == null)
                return;

            StopCoroutine(_getOutOfWaterJob);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DollPart dollPart))
        {
            _startPosition = dollPart.transform.position;

            float targetPositonY = dollPart.transform.position.y - _offsetY;

             StopCoroutine(GetOutOfWater(dollPart));
            _goInWaterJob = StartCoroutine(GoInWater(dollPart, targetPositonY));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out DollPart dollPart))
        {
            StopCoroutine(GoInWater(dollPart, _offsetY));
            _getOutOfWaterJob = StartCoroutine(GetOutOfWater(dollPart));
        }
    }

    private IEnumerator GoInWater(DollPart dollPart, float positionY)
    {
        while (dollPart.transform.position.y != positionY)
        {
            float targetPosition = Mathf.LerpUnclamped(dollPart.transform.position.y, positionY, _goInWaterSpeed * Time.deltaTime);
            dollPart.transform.Translate(-(transform.up + new Vector3(0, targetPosition, 0)) * _goInWaterSpeed * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator GetOutOfWater(DollPart dollPart)
    {
        while (dollPart.transform.position.y != _startPosition.y)
        {
            dollPart.transform.Translate((transform.up + new Vector3(0, _startPosition.y, 0)) * _getOutOfWaterSpeed * Time.deltaTime);

            yield return null;
        }
    }
}