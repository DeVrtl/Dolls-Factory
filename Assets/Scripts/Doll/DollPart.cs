using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class DollPart : MonoBehaviour
{
    [SerializeField] private float _speed = 7f;

    private readonly float _offsetSpeed = 100f;
    private Animator _animator;

    public Animator Animator => _animator;

    public event UnityAction<DollPart> Captured;

    private void OnValidate()
    {
        _speed = Mathf.Clamp(_speed, 0, float.MaxValue);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Collecteble collecteble))
        {
            if (collecteble.TryCollect(out DollPart dollPart))
                Captured?.Invoke(dollPart);
        }
    }

    public void Init(Transform lastPart)
    {
        StartCoroutine(Move(lastPart));
    }

    public void PlayPickUp()
    {
        _animator.Play(AnimatorDollPartController.States.PickUp);
    }

    public void MoveY(float y, float speed)
    {
        transform.Translate((transform.forward + new Vector3(0, y, 0)) * speed * Time.deltaTime);
    }

    private IEnumerator Move(Transform previousPart)
    {
        while(true)
        {
            float x = Mathf.LerpUnclamped(transform.position.x, previousPart.position.x, _offsetSpeed * Time.deltaTime);
            x -= transform.position.x;
            transform.Translate((transform.forward + new Vector3(x, 0, 0)) * _speed * Time.deltaTime);
            yield return null;
        }
    }
}
