using UnityEngine;

public class CameraEnd : MonoBehaviour
{
    [SerializeField] private CinemachineSwitcher _cinemachineSwitcher;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HeadUpgrade headUpgrade))
            _cinemachineSwitcher.SwitchPriority();
    }
}
