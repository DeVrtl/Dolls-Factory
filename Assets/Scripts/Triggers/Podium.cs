using UnityEngine;

public class Podium : MonoBehaviour
{
    [SerializeField] private DollPodium _dollPodium;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DollPartLast dollPart))
        {
            ChangeDollActive(dollPart, _dollPodium, false, true);
        }
    }

    private void ChangeDollActive(DollPartLast dollPart, DollPodium dollPodium, bool stateForDollPart, bool stateForDollPodium)
    {
        dollPart.gameObject.SetActive(stateForDollPart);
        dollPodium.gameObject.SetActive(stateForDollPodium);
    }
}
