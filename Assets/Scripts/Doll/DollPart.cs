using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DollPart : MonoBehaviour
{
    [SerializeField] private Material _materialToChange;

    private Vector3 _lastPosition;
    private Transform _target;
    private Chain _chain;
    private Renderer _renderer;
    private bool _isInChain;

    public Chain Chain => _chain;
    public bool IsInChain => _isInChain;
    public Vector3 LastPosition => _lastPosition;
    public Transform Target => _target;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DollPart dollPart))
        {
            if (dollPart.IsInChain == false)
            {
                dollPart.SetChain(_chain);
                dollPart.ChangeState(true);
            }
        }
    }

    public void Move(float speed)
    {
        if (_target != null && _target.transform.position != _lastPosition)
        {
            //наша движение к таргету по X(иксу)
            //transform.Translate(speed * Time.deltaTime * _target.position.x, 0, _target.position.z + 0.5f);
            transform.position = Vector3.Lerp(transform.position, _lastPosition, speed * Time.deltaTime);
            _lastPosition = _target.transform.position;
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
        _lastPosition = target.position;
    }

    public void SetChain(Chain chain)
    {
        _chain = chain;
        _chain.AddToChain(this);
    }

    public void ChangeState(bool flag)
    {
        _isInChain = flag;
    }

    public void ChangeMaterial()
    {
        _renderer.material = _materialToChange;
    }
}
