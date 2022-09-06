using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Chain))]
public class ChainCounter : MonoBehaviour
{
    [SerializeField] private CinemachineSwitcher _cinemachineSwitcher;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem _winEffect;

    private Chain _chain;

    private void Awake()
    {
        _chain = GetComponent<Chain>();
    }

    private void Update()
    {
        if (_chain.Parts.All(p => p.gameObject.activeSelf == false))
        {
            _cinemachineSwitcher.SwitchToWinCamera();
            _animator.Play(AnimatorCameraController.States.GoUp);
            _winEffect.Play();
        }
    }
}
