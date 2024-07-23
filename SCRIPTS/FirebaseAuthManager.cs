using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Extensions;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FirebaseAuthManager : MonoBehaviour
{
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public Text feedbackText; 

    private FirebaseAuth auth;

    private int initializationAttempts = 0;
    private const int maxInitializationAttempts = 3;

    void Start()
    {
        StartCoroutine(InitializeFirebase());
    }

    IEnumerator InitializeFirebase()
    {
        var task = FirebaseApp.CheckAndFixDependenciesAsync();
        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted)
        {
            UnityEngine.Debug.LogError("Could not resolve all Firebase dependencies: " + task.Exception);
            // Retry initialization after a delay
            if (initializationAttempts < maxInitializationAttempts)
            {
                initializationAttempts++;
                yield return new WaitForSeconds(2); // wait for 2 seconds before retrying
                StartCoroutine(InitializeFirebase());
            }
            else
            {
                UnityEngine.Debug.LogError("Max initialization attempts reached, Firebase is not available.");
            }
        }
        else if (task.Result == DependencyStatus.Available)
        {
            auth = FirebaseAuth.DefaultInstance;
            UnityEngine.Debug.Log("Firebase is initialized and ready.");
        }
        else
        {
            UnityEngine.Debug.LogError($"Could not resolve all Firebase dependencies: {task.Result}");
        }
    }


    public void RegisterUser()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                UpdateFeedback("Registration encountered an error: " + task.Exception);
                return;
            }
            else
            {
                FirebaseUser newUser = task.Result.User;
                UpdateFeedback($"User created successfully: {newUser.Email}");

                // Create a new User object with just the UID and email
                User user = new User(newUser.UserId, newUser.Email);

                // Get a reference to the FirebaseDatabaseManager and save the user
                FirebaseDatabaseManager databaseManager = GetComponent<FirebaseDatabaseManager>();
                if (databaseManager != null)
                {
                    databaseManager.CreateUser(user, success =>
                    {
                        if (success)
                        {
                            UpdateFeedback("User data saved successfully.");
                            SceneManager.LoadScene("SelecNavigation");
                        }
                        else
                        {
                            UpdateFeedback("Failed to save user data.");
                        }
                    });
                }
                else
                {
                    UpdateFeedback("Database manager not found.");
                }
            }
        });
    }

    public void LoginUser()
    {
        string email = emailInputField.text;
        string password = passwordInputField.text;

        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                UpdateFeedback("Login failed: " + task.Exception);
                return;
            }

            FirebaseUser user = task.Result.User;
            UpdateFeedback($"User logged in successfully: {user.Email}");
            SceneManager.LoadScene("SelecNavigation"); 
        });
    }

    private void UpdateFeedback(string message)
    {
        Debug.Log(message);
        feedbackText.text = message; 
    }
}
