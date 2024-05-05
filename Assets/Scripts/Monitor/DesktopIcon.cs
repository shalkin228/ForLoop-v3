using UnityEngine;

public class DesktopIcon : MonoBehaviour
{
    private bool _isSelected;



    private void OnValidate()
    {
        if (GetComponentInParent<DesktopController>() == null)
        {
            Debug.LogError("There's should be a DesktopController in one of the Icon " + gameObject.name + " parents");
        }
    }
}
