using System.Diagnostics;
using UnityEngine;
using Vuforia;

public class QRCodeTrigger : MonoBehaviour
{
    public libraryToCafeNavigationScript libraryToCafeNavigationScript;

    public void StartLibraryToCafeNavigation()
    {
        if (libraryToCafeNavigationScript != null)
        {
            libraryToCafeNavigationScript.StartNavigation();
        }
        else
        {
            UnityEngine.Debug.LogError("Library to Cafe Navigation script not assigned.");
        }
    }
}
