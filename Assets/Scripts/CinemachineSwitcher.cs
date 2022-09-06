using Cinemachine;
using UnityEngine;

public class CinemachineSwitcher : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _upperCamera;
    [SerializeField] private CinemachineVirtualCamera _middleCamera;
    [SerializeField] private CinemachineVirtualCamera _middleFarCamera;
    [SerializeField] private CinemachineVirtualCamera _lowerCamera;
    [SerializeField] private CinemachineVirtualCamera _winCamera;
    [SerializeField] private CinemachineVirtualCamera _boostedCamera;
    [SerializeField] private int _highPriority;
    [SerializeField] private int _lowPriority;

    private bool _isMainCamera = true;

    private void OnValidate()
    {
        _highPriority = Mathf.Clamp(_highPriority, 0, int.MaxValue);
        _lowPriority = Mathf.Clamp(_lowPriority, 0, int.MaxValue);
    }

    public void SwitchPriority() 
    {
        if (_isMainCamera)
        {
            _middleCamera.Priority = _lowPriority;
            _lowerCamera.Priority = _highPriority;
        }
        else
        {
            _middleFarCamera.Priority = _highPriority;
            _lowerCamera.Priority = _lowPriority;
        }

        _isMainCamera = !_isMainCamera;
    }

    public void SwitchToWinCamera()
    {
        _winCamera.Priority = _highPriority;
    }

    public void SwitchToBoostedCamera()
    {
        _boostedCamera.Priority = _highPriority;
    }

    public void SwitcToUpperCamera()
    {
        _upperCamera.Priority = _highPriority;
    }
}
