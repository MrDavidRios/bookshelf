using UnityEngine;

public class ToggleVisibility : MonoBehaviour
{
    public void Open(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void Close(GameObject obj)
    {
        obj.SetActive(false);
    }
}
