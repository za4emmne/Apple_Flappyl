using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode[] _keysUp;
    [SerializeField] private KeyCode[] _keysShoot;

    public bool DownButtonBirdUp()
    {
        return DownButton(_keysUp);
    }

    public bool DownButtonBirdShoot()
    {
        return DownButton(_keysShoot);
    }

    private bool DownButton(KeyCode[] keyCodes)
    {
        foreach (KeyCode keyCode in keyCodes)
            if (Input.GetKeyDown(keyCode))
                return true;

        return false;
    }
}
