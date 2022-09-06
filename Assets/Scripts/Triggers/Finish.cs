using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private CinemachineSwitcher _cinemachineSwitcher;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DollPart dollPart))
        {
            dollPart.Animator.enabled = false;
        }

        if (other.TryGetComponent(out PointScaler pointScaler))
        {
            pointScaler.ScaleMe();
        }
        _cinemachineSwitcher.SwitcToUpperCamera();
    }
}
