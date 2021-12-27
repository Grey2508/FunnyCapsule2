using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSwitcher : MonoBehaviour
{
    public bool Stage = false;

    void Start()
    {
        Cursor.visible = Stage;
    }
}
