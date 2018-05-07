using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnColorEvent : MonoBehaviour {

    private void OnEnable()
    {
        EventTrigger.OnClicked += ChangeColor;
    }

    private void OnDisable()
    {
        EventTrigger.OnClicked -= ChangeColor;
    }

    private void ChangeColor()
    {
        Color color = new Color(Random.value, Random.value, Random.value);
        GetComponent<Renderer>().material.color = color;
    }
}
