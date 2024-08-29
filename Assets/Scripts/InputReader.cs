using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private KeyCode[] _keysUp;
    [SerializeField] private KeyCode[] _keysShoot;

    public bool IsDownButtonBirdUp()
    {
        return DownButton(_keysUp);
    }

    public bool IsDownButtonBirdShoot()
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
