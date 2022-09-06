using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DollPodium : MonoBehaviour
{
    [SerializeField] private Material _water;
    [SerializeField] private Material _original;
    [SerializeField] private float _scaleX;
    [SerializeField] private float _scaleY;
    [SerializeField] private float _scaleZ;

    private Renderer _renderer;

    private void OnValidate()
    {
        _scaleX = Mathf.Clamp(_scaleX, 0, float.MaxValue);
        _scaleY = Mathf.Clamp(_scaleY, 0, float.MaxValue);
        _scaleZ = Mathf.Clamp(_scaleZ, 0, float.MaxValue);
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out DollPartUpgrade dollPart))
        {
            transform.localScale += new Vector3(_scaleX, _scaleY, _scaleZ);

            if (dollPart.IsColorChanged == true)
            {
                AssignMaterial(_water);
            }
            else
            {
                AssignMaterial(_original);
            }
        }
    }

    private void AssignMaterial(Material material)
    {
        _renderer.material = material;
    }
}
