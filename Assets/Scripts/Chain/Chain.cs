using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Chain : MonoBehaviour
{
    [SerializeField] private DollPart _first;
    [SerializeField] private float _offset;
    [SerializeField] private float _offsetY;

    private Transform _lastPart;
    private List<DollPart> _parts = new List<DollPart>();
    private Vector3 _lastPosition;

    public List<DollPart> Parts  => _parts;

    private void OnValidate()
    {
        _offset = Mathf.Clamp(_offset, 0, float.MaxValue);
        _offsetY = Mathf.Clamp(_offsetY, 0, float.MaxValue);
    }

    private void Start()
    {
        _lastPart = _first.transform;

        _lastPosition = _lastPart.position;

        Add(_first);
    }

    private void OnDisable()
    {
        foreach (var part in _parts)
            part.Captured -= Add;
    }

    public void Add(DollPart dollPart)
    {
        _parts.Add(dollPart);

        dollPart.Captured += Add;

        _lastPosition = CalculateNextPosition();
        dollPart.Init(_lastPart);

        StartCoroutine(PlayAndWait(_parts));

        _lastPart = _parts[_parts.Count - 1].transform;
        dollPart.transform.position = _lastPosition;
    }

    private IEnumerator PlayAndWait(List<DollPart> parts)
    {
        for (int i = parts.Count - 1; i >= 0; i--)
        {
            parts[i].PlayPickUp();
            yield return new WaitForSeconds(0.1f);
        }
    }

    private Vector3 CalculateNextPosition()
        => new Vector3(_parts[_parts.Count - 1].transform.position.x, _offsetY, _parts[_parts.Count - 1].transform.position.z + _offset);
}
