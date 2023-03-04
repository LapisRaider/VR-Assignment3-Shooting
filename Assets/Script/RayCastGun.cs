using System.Collections.Generic;
using UnityEngine;

public class RayCastGun : MonoBehaviour
{
    [Header("Interaction")]
    public string m_inputName = "LHandTrigger";
    public GameObject m_player;
    public List<string> m_teleportableCollidersTags = new List<string>();

    [Header("Ray")]
    public LineRenderer m_lineRenderer = null;
    public float m_gunRange = 3.0f;

    [Header("Teleportation Ring")]
    public GameObject m_teleportationRing;
    public Vector3 m_ringOffset = new Vector3(0, 0.5f, 0);
    private Quaternion m_ringOriginalRotation;

    private bool m_enableTeleportation = false;
    private Vector3 m_teleportationPos;

    private void Awake()
    {
        m_lineRenderer.useWorldSpace = true;

        m_ringOriginalRotation = m_teleportationRing.transform.rotation;
        m_teleportationRing.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if player release holding down button
        if (Input.GetAxis(m_inputName) < 1)
        {
            if (m_enableTeleportation)
            {
                m_player.transform.position = new Vector3(m_teleportationPos.x, m_player.transform.position.y, m_teleportationPos.z);
            }

            m_teleportationRing.SetActive(false);
            m_enableTeleportation = false;
            m_lineRenderer.enabled = false;
            return;
        }


        m_lineRenderer.enabled = true;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, m_gunRange);
    
        Vector3 endPos;
        if (hit.collider)
        {
            endPos = hit.point;

            if (m_teleportableCollidersTags.Contains(hit.collider.tag))
            {
                m_enableTeleportation = true;
                m_teleportationPos = endPos;

                //render the teleportation ring
                m_teleportationRing.transform.position = endPos + m_ringOffset;
                m_teleportationRing.transform.rotation = m_ringOriginalRotation; //so it doesn't follow parent rotation
                m_teleportationRing.SetActive(true);
            }
            else
            {
                m_enableTeleportation = false;
            }
        }
        else
        {
            endPos = transform.position + (transform.forward * m_gunRange);
            m_teleportationRing.SetActive(false);
        }

        m_lineRenderer.SetPosition(0, transform.position);
        m_lineRenderer.SetPosition(1, endPos);
    }
}
