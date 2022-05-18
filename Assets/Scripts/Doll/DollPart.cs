using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Renderer))]
public class DollPart : MonoBehaviour
{
    [SerializeField] private Material _material;

    private float _speed = 4f;
    private float _offsetSpeed = 10000f;

    private Renderer _renderer;

    public event UnityAction<DollPart> Captured;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Water water))
            _renderer.material = _material;

        if (other.TryGetComponent(out Collecteble collecteble))
        {
            if (collecteble.TryCollect(out DollPart dollPart))
                Captured?.Invoke(dollPart);
        }
    }

    private IEnumerator Move(Transform previousPart)
    {
        while(true)
        {
            float x = Mathf.Lerp(transform.position.x, previousPart.position.x, _offsetSpeed * Time.deltaTime);
            x -= transform.position.x;
            //Debug.Log(x);
            transform.Translate((transform.forward + new Vector3(x, 0, 0)) * _speed * Time.deltaTime);
            yield return null;
        }
    }

    public void Init(Transform lastPart, Material material)
    {
        _material = material;

        StartCoroutine(Move(lastPart));
    }
}
