using System.Diagnostics;
using UnityEngine;
using Vuforia;

public class QRCodeTrigger2 : MonoBehaviour
{
    public studentHouseToLibraryNavigationScript studentHouseToLibraryNavigationScript;

    public void StartStudentHouseToLibraryNavigation()
    {
        if (studentHouseToLibraryNavigationScript != null)
        {
            studentHouseToLibraryNavigationScript.StartNavigation();
        }
        else
        {
            UnityEngine.Debug.LogError("Student House to Library Navigation script not assigned.");
        }
    }
}
