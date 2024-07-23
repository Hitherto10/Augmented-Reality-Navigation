using System.Diagnostics;
using UnityEngine;
using Vuforia;

public class QRCodeTrigger5 : MonoBehaviour
{
    public MainEntranceToStudentHouse MainEntranceToStudentHouse;

    public void StartMainEntranceToStudentHouseNavigation()
    {
        if (MainEntranceToStudentHouse != null)
        {
            MainEntranceToStudentHouse.StartNavigation();
        }
        else
        {
            UnityEngine.Debug.LogError("Student House to Library Navigation script not assigned.");
        }
    }
}
