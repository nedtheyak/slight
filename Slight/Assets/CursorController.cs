// This script handles capturing and hiding the system mouse cursor
// The code commented out in the switch statement is for CONFINING the cursor to the window; something only supported on the desktop clients


using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class CursorController : MonoBehaviour {

    CursorLockMode wantedMode;

    // Apply requested cursor state
    void SetCursorState()
    {
        Cursor.lockState = wantedMode;
        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }

    void OnGUI()
    {
        GUILayout.BeginVertical();
        // Release cursor on escape keypress
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = wantedMode = CursorLockMode.None;

        switch (Cursor.lockState)
        {
            case CursorLockMode.None:
                //GUILayout.Label("Cursor is normal");
                if (GUILayout.Button("Lock cursor"))
                    wantedMode = CursorLockMode.Locked;
                //if (GUILayout.Button("Confine cursor"))
                    //wantedMode = CursorLockMode.Confined;
                break;
            //case CursorLockMode.Confined:
                //GUILayout.Label("Cursor is confined");
                //if (GUILayout.Button("Lock cursor"))
                    //wantedMode = CursorLockMode.Locked;
                //if (GUILayout.Button("Release cursor"))
                    //wantedMode = CursorLockMode.None;
                //break;
            case CursorLockMode.Locked:
                //GUILayout.Label("Cursor is locked");
                if (GUILayout.Button("Unlock cursor"))
                    wantedMode = CursorLockMode.None;
                //if (GUILayout.Button("Confine cursor"))
                    //wantedMode = CursorLockMode.Confined;
                break;
        }

        GUILayout.EndVertical();

        SetCursorState();
    }
}
