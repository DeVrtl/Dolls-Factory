using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DollPartUpgrade : MonoBehaviour
{
    [SerializeField] private Material _water;
    [SerializeField] private Material _waterDress;
    [SerializeField] private Material _original;
    [SerializeField] private Body _body;
    [SerializeField] private DimondsHolder _dimonds;
    [SerializeField] private Head _head;
    [SerializeField] private MeshRenderer _dress;
    [SerializeField] private MeshRenderer _ñlay;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Animator _animator;

    private bool _isColorChanged = false;

    public bool IsColorChanged => _isColorChanged;

    public void ChangeColor()
    {
        _renderer.material = _water;
        _isColorChanged = true;
    }

    public void UpdateDressColor()
    {
        if (_isColorChanged == true)
        {
            UpgradeBody();
            _dress.material = _waterDress;
        }
        else
        {
            UpgradeBody();
            _dress.material = _original;
        }
    }

    public void ActivateHead()
    {
        _animator.Play(AnimatorDressAndBodyController.States.BodyUpgrade);
        _head.gameObject.SetActive(true);
    }

    public void ActivateDimondHolder()
    {
        _dimonds.gameObject.SetActive(true);
    }

    private void UpgradeBody()
    {
        _body.gameObject.SetActive(true);

        _dress.enabled = true;
        _ñlay.enabled = false;
    }
}