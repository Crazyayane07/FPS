using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour {

    public delegate void ClickAction();
    public static event ClickAction OnClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClicked();
        }
    }
}
