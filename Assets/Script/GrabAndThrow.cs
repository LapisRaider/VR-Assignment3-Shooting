using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndThrow : MonoBehaviour
{
    public string buttonName;
    public OVRInput.Controller Controller;
    public float grabRadius;
    public LayerMask grabMask;
    public AudioSource audioSource;
    public AudioClip grabAudio;
    public AudioClip throwAudio;

    private GameObject grabbedObject;
    private bool grabbing;

    void Update()
    {
        if (!grabbing && Input.GetAxis(buttonName) == 1)
        {
            GrabObject();
        }
        
        if (grabbing && Input.GetAxis(buttonName) < 1)
        {
            ThrowObject();
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

    void ThrowObject()
    {
        grabbing = false;

        if (grabbedObject != null) 
        {
            grabbedObject.transform.parent = null;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject.GetComponent<Rigidbody>().velocity = OVRInput.GetLocalControllerVelocity(Controller)*3;
            grabbedObject.GetComponent<Rigidbody>().angularVelocity = OVRInput.GetLocalControllerAngularVelocity(Controller);
            grabbedObject = null;
            audioSource.PlayOneShot(throwAudio);
        }
    }

};
