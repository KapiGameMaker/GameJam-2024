using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor_Control : MonoBehaviour
{
    public Texture2D cursorArrow;
    public Texture2D cursorClick;

    void Start()
    {
        //Cursor.visible = false;
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }
    private void Update()
    {
        OnMouseClick();
    }

    void OnMouseClick()
    {
        Debug.Log("down");
        if (Input.GetMouseButton(0))
        {
            Cursor.SetCursor(cursorClick, Vector2.zero, CursorMode.ForceSoftware);
        }
        else Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

}
