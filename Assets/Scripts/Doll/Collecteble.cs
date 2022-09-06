using UnityEngine;

public class Collecteble : MonoBehaviour
{
    private bool _isCollected = false;

    public bool TryCollect(out DollPart dollPart)
    {
        dollPart = null;

        if (_isCollected)
            return false;

        _isCollected = true;

        dollPart = gameObject.AddComponent<DollPart>();

        return true;
    }
}