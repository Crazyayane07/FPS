using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour {
    public AudioClip gunfire_clip;
    private const float TO_NEXT_SHOT_TIME = 1f;
    public bool shooted;
    public int damageAmount = 1;
    public float targetDistance;
    public float allowedRange = 15f;
    public GameObject gunEnd;
    LineRenderer laserLine;
    Camera fpsCam;

    private void Start()
    {
        shooted = false;
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<Camera>();
    }
    void Update ()
    {
        if (Input.GetMouseButtonDown(0) && !shooted)
        {
            shooted = true;
            PlayAnimationAndSound();
            Shooting();
            StartCoroutine(WaitForNextShot());
        }
	}

    void PlayAnimationAndSound()
    {
        AudioSource.PlayClipAtPoint(gunfire_clip, transform.position);
        GetComponent<Animation>().Play("Gunshot");
    }

    void Shooting()
    {
        laserLine.enabled = true;
        RaycastHit shot;
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
        laserLine.SetPosition(0, gunEnd.transform.position);
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out shot))
        {
            targetDistance = shot.distance;
            laserLine.SetPosition(1, shot.point);
            if (targetDistance < allowedRange)
            {
                shot.transform.SendMessage("DeductPoints", damageAmount, SendMessageOptions.DontRequireReceiver);
            }
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward*allowedRange));
        }
    }
    IEnumerator WaitForNextShot()
    {
        yield return new WaitForSeconds(TO_NEXT_SHOT_TIME);
        shooted = false;
        laserLine.enabled = false;
    }
}
