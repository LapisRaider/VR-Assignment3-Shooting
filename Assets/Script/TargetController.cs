using UnityEngine;

public class TargetController : MonoBehaviour
{
    public GameObject explodeEffects;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food")) 
        {
            ScoreManager.instance.IncrementScore(1);
            Instantiate(explodeEffects, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);  
        }

    }
}