using UnityEngine;

public class FirstMechanism: MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DollPart dollPart))
            _animator.Play(AnimatorMainController.States.WorkHarder);
    }
}
