using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;

public class FirebaseDatabaseManager : MonoBehaviour
{
    private DatabaseReference databaseReference;
    

    void Awake() 
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError($"Failed to initialize Firebase: {task.Exception}");
            }
            else if (task.IsCompletedSuccessfully)
            {
                if (task.Result == DependencyStatus.Available)
                {
                    // If dependency status is available, initialize Firebase
                    databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
                }
                else
                {
                    UnityEngine.Debug.LogError("Firebase dependencies are not available.");
                }
            }
        });
    }

    public void CreateUser(User user, System.Action<bool> onComplete)
    {
        string json = JsonUtility.ToJson(user);

        databaseReference.Child("users").Child(user.uid).SetRawJsonValueAsync(json).ContinueWithOnMainThread(task =>
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                onComplete(false);
                return;
            }
            onComplete(true);
        });
    }
}

// User data model class
[System.Serializable]
public class User
{
    public string uid;
    public string email;

    // constructor to only take the UID and email
    public User(string uid, string email)
    {
        this.uid = uid;
        this.email = email;
    }
}
