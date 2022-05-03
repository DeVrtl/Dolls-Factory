using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainPusher : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }
}
