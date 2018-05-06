using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public int health = 3;
    public AudioClip scream_clip;
    public static int paintings = 10;
    GameObject scoreManager;
    public GameObject sparks;

    private void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("GameController");
    }
    private void Update()
    {
        if(health <= 0)
        {
            AudioSource.PlayClipAtPoint(scream_clip, transform.position);
            Instantiate(sparks, gameObject.transform.position, Quaternion.identity);
            paintings--;
            scoreManager.transform.SendMessage("SetNewText", paintings, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }    
    }

    void DeductPoints(int damageAmount)
    {
        health -= damageAmount;
    }
}
