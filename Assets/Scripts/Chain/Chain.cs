using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    [SerializeField] private DollPart _first;
    [SerializeField] private Material _water;
    [SerializeField] private float _offset;

    private Transform _lastPart;
    private List<DollPart> _parts = new List<DollPart>();
    private Vector3 _lastPosition;

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
        dollPart.Init(_lastPart, _water);

        _lastPart = _parts[_parts.Count - 1].transform;
        dollPart.transform.position = _lastPosition;
    }

    private Vector3 CalculateNextPosition()
        => new Vector3(_parts[_parts.Count - 1].transform.position.x, _lastPosition.y, _parts[_parts.Count - 1].transform.position.z + _offset);
}
