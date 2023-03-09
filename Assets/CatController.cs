using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private ParticleSystem ps;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ps = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food") && !animator.GetBool("isSleeping"))
        {
            ScoreManager.instance.IncrementScore(1);
            ps.Play();
            FoodManager.instance.SpawnFood();
            animator.SetBool("isSleeping", true);
        }
    }
}
