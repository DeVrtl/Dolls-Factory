using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainInput : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * _speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * _speed * Time.deltaTime;
        }
    }
}
