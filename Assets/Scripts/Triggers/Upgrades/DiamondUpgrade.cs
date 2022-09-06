using UnityEngine;

public class DiamondUpgrade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DollPartUpgrade upgrader))
            upgrader.ActivateDimondHolder();
    }
}
