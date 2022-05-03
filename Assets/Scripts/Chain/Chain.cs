using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{
    [SerializeField] private DollPart _startDollPart;
    [SerializeField] private float _stepSize;

    private Vector3 _lastPosition;
    private Transform _currentTarget;
    private List<Transform> _dollParts = new List<Transform>();
    private float _offset;

    private void Start()
    {
        _currentTarget = _startDollPart.transform;

        _lastPosition = _startDollPart.transform.position;

        _startDollPart.ChangeState(true);
        _startDollPart.SetChain(this);

        _offset = _startDollPart.transform.localScale.x / _stepSize;
    }

    public void AddToChain(DollPart dollPart)
    {
        _dollParts.Add(dollPart.transform);

        SetNextPosition();

        dollPart.SetTarget(_currentTarget);

        _currentTarget = _dollParts[_dollParts.Count - 1];

        dollPart.transform.position = _lastPosition;
        //dollPart.transform.SetParent(transform);
    }

    private void SetNextPosition()
    {
        _lastPosition = new Vector3(_dollParts[_dollParts.Count - 1].transform.position.x, _lastPosition.y, _dollParts[_dollParts.Count - 1].transform.position.z + _offset);
    }
}
