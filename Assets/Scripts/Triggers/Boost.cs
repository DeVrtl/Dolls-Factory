using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] private CinemachineSwitcher _cinemachineSwitcher;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out HeadUpgrade headUpgrade))
            _cinemachineSwitcher.SwitchToBoostedCamera();
    }
}
