using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _offsetSpeed;

    private Vector3 _direction;

    private void Update()
    {
        _direction = _speed * Vector3.forward;

        if (Input.GetKey(KeyCode.A))
            _direction += -Vector3.right * _offsetSpeed;

        else if (Input.GetKey(KeyCode.D))
            _direction += Vector3.right * _offsetSpeed;

        transform.Translate(_direction * Time.deltaTime);
    }
}
