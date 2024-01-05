using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(NotificationManager))]
public class GameBehaviour : Singleton<GameBehaviour>
{

    private GameObject _sophie = null;
    public GameObject Sophie
    {
        get
        {
            if (_sophie == null) _sophie = GameObject.FindWithTag("Sophie");
            return _sophie;
        }
    }

    private NotificationManager _notifications = null;
    public NotificationManager Notifications
    {
        get
        {
            if (_notifications == null) _notifications = Instance.GetComponent<NotificationManager>();
            return _notifications;
        }
    }

    // OnDisable method in Listener class causes an error when exiting game on editor. This method is to avoid the error.
    private void OnApplicationQuit()
    {
        MonoBehaviour[] scripts = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
            script.enabled = false;
    }
}