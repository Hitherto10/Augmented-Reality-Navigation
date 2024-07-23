using System.Diagnostics;
using UnityEngine;
using Vuforia;

public class QRCodeTrigger3 : MonoBehaviour
{
    public SecondaryEntrancetoReception SecondaryEntrancetoReception;

    public void StartSecondaryEntrancetoReceptionNavigation()
    {
        if (SecondaryEntrancetoReception != null)
        {
            SecondaryEntrancetoReception.StartNavigation();
        }
        else
        {
            UnityEngine.Debug.LogError("Student House to Library Navigation script not assigned.");
        }
    }
}
