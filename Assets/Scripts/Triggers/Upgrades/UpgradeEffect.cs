using UnityEngine;

public class UpgradeEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DollPart dollPart))
        {
            _effect.Play();
        }
    }
}
