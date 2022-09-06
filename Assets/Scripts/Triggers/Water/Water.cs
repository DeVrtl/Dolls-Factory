using UnityEngine;

public class Water : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DollPartUpgrade upgrader))
            upgrader.ChangeColor();
    }
}
