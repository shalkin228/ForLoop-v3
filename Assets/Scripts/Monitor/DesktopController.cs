using System.Collections.Generic;
using UnityEngine;

public class DesktopController : MonoBehaviour
{
    private List<DesktopIcon> _icons;

    public void RegisterIcon(DesktopIcon icon)
    {
        _icons.Add(icon);
    }
}
