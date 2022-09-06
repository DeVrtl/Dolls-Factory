using UnityEngine;

public class BodyUpgrade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Hands hands))
            hands.DestroyHands();

        if (other.TryGetComponent(out DollPartUpgrade upgrader))
            upgrader.UpdateDressColor();
    }
}
