using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void LoadLib_to_Caf()
    {
        SceneManager.LoadScene("Lib_to_Caf");
    }
    
    public void LoadStudentHouse_to_Library()
    {
        SceneManager.LoadScene("StudentHouse_to_Library");
    }
    
    public void LoadSecondaryEntrace_to_Reception_Navigation()
    {
        SceneManager.LoadScene("SecondaryEntrace_to_Reception_Navigation");
    }
    
    public void LoadMainEntranceToReception()
    {
        SceneManager.LoadScene("MainEntranceToReception");
    }
    
    public void LoadMapPage()
    {
        SceneManager.LoadScene("MapPage");
    }
   
    public void LoadMainEntrance_to_StudentHouse()
    {
        SceneManager.LoadScene("MainEntrancetoStudentHouse");
    }

     
    public void LoadLoginPage()
    {
        SceneManager.LoadScene("loginPage");
    } 

    public void LoadSignupPage()
    {
        SceneManager.LoadScene("SignupPage");
    }

    public void ExitApp()
    {
        Application.Quit();
        Debug.Log("You have quit the app");
    }

    public void LoadSelecNavigationScene()
    {
        SceneManager.LoadScene("SelecNavigation");
    }

    public void LoadInfoScene()
    {
        SceneManager.LoadScene("InformationScene");
        Debug.Log("You have quit the app");
    }

}
