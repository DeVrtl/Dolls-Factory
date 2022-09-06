using UnityEngine;

public class Deactivator : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DollPart dollPart))
        {
            dollPart.gameObject.SetActive(false);
        }
    }
}
