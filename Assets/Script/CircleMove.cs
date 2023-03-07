using UnityEngine;

public class CircleMove : MonoBehaviour
{
    public float speed = 2.0f;
    public float radius = 2.0f; // The radius of the circle
    public Transform lookAtTarget;

    private float angle = 0.0f;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        angle += speed * Time.deltaTime;

        // Move in a circle
        Vector3 newPosition = initialPosition + new Vector3(Mathf.Sin(angle) * radius, Mathf.Cos(angle) * radius, 0);

        transform.position = newPosition;
    }
}