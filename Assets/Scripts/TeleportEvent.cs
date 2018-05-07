using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEvent : MonoBehaviour {

    private void OnEnable()
    {
        EventTrigger.OnClicked += Teleport;
    }

    private void OnDisable()
    {
        EventTrigger.OnClicked -= Teleport;
    }

    private void Teleport()
    {
        Vector3 newPosition = transform.position;
        newPosition.y = Random.Range(5f, 20f);
        transform.position = newPosition;
    }
}
