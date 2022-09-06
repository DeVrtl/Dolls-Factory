using UnityEngine;

public class HeadUpgrade : MonoBehaviour
{
    [SerializeField] private CinemachineSwitcher _cinemachineSwitcher;
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CameraStart cameraStart))
        {
            _cinemachineSwitcher.SwitchPriority();
            _animator.Play(AnimatorHeadHolderController.States.Idle);
        }

        if (other.TryGetComponent(out DollPartUpgrade upgrader))
            upgrader.ActivateHead();
    }
}
