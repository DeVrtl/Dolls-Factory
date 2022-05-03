using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DollPart))]
public class DollPartMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private DollPart _dollPart;

    private void Awake()
    {
        _dollPart = GetComponent<DollPart>();
    }

    private void Update()
    {
        _dollPart.Move(_speed);
    }
}
