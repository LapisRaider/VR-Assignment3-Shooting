using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public string grabButton;
    public string shootButton;
    public OVRInput.Controller Controller;
    public float grabRadius;
    public LayerMask grabMask;
    public AudioSource audioSource;
    public AudioClip grabAudio;
    public AudioClip shootAudio;

    private GameObject grabbedObject;
    private bool grabbing;

    void Update()
    {
        if (!grabbing && Input.GetAxis(grabButton) == 1) {
            GrabObject();
        }
        if (grabbing && Input.GetAxis(shootButton) == 1) {
            ShootObject();
        }
    }

    void GrabObject()
    {
        grabbing = true;

        RaycastHit[] hits;

        hits = Physics.SphereCastAll(transform.position, grabRadius,transform.forward,0f,grabMask);
        
        if (hits.Length > 0) 
        {
            int closestHit = 0;

            for(int i = 0; i<hits.Length; i++)
            {
                if ((hits[i]).distance < hits[closestHit].distance)
                {
                    closestHit = i;
                }
            }

            grabbedObject = hits[closestHit].transform.gameObject;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            grabbedObject.transform.position = transform.position;
            grabbedObject.transform.parent = transform;
            audioSource.PlayOneShot(grabAudio);
        }
    }

    void ShootObject()
    {
        grabbing = false;

        if (grabbedObject != null) 
        {
            grabbedObject.transform.parent = null;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.GetComponent<Rigidbody>().AddForce(transform.forward*20);
            grabbedObject = null;
            audioSource.PlayOneShot(shootAudio);
        }
    }
};
