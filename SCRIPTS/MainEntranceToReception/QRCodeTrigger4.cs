using System.Diagnostics;
using UnityEngine;
using Vuforia;

public class QRCodeTrigger4 : MonoBehaviour
{
    public MainEntranceToReception MainEntranceToReception;

    public void StartMainEntranceToReceptionNavigation()
    {
        if (MainEntranceToReception != null)
        {
            MainEntranceToReception.StartNavigation();
        }
        else
        {
            UnityEngine.Debug.LogError("Student House to Library Navigation script not assigned.");
        }
    }
}
