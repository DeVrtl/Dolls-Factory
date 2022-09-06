using UnityEngine;
using DG.Tweening;

public class PointScaler : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleFactor;
    [SerializeField] private float _time;

    private void OnValidate()
    {
        _time = Mathf.Clamp(_time, 0, float.MaxValue);
    }

    public void ScaleMe()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(_scaleFactor, _time));
    }
}
