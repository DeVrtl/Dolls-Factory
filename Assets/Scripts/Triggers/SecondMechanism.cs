using UnityEngine;

public class SecondMechanism : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DollPart dollPart))
            _animator.Play(AnimatorHeadHolderController.States.GoDown);
    }
}
