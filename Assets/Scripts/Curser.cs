using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curser : MonoBehaviour
{
    public Texture2D customCursor;

    void Start()
    {
        // Ensure that there is only one instance of the CursorManager
        if (FindObjectsOfType<Curser>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            // Make this object persist across scenes
            DontDestroyOnLoad(gameObject);

            // Set the custom cursor
            Cursor.SetCursor(customCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
    }

}
