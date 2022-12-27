using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private float sightRadius = 10f;
    [SerializeField] private float minimumSeparation = 1f;
    private GameObject player;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        int neighbourTotal = 0;

        Collider2D[] neighbours = Physics2D.OverlapCircleAll(transform.position, sightRadius);

        Vector3 averageNeighbourPosition = Vector3.zero;
        Vector3 totalSeparation = Vector3.zero;
        Vector3 averageVelocity = Vector3.zero;

        foreach(Collider2D neighbour in neighbours)
        {
            if (neighbour != player.GetComponent<Collider2D>())
            {
                if ((neighbour.transform.position - transform.position).magnitude < minimumSeparation)
                {   
                    totalSeparation += transform.position - neighbour.transform.position;
                }
                float neighbourAngle = neighbour.transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
                float neighbourHorizontal = Mathf.Cos(neighbourAngle);
                float neighbourVertical = Mathf.Sin(neighbourAngle);
                averageVelocity += new Vector3(neighbourHorizontal, neighbourVertical, 0f);

                averageNeighbourPosition += neighbour.transform.position;
                neighbourTotal++;
            }
        }
        if (neighbourTotal > 0)
        {
            averageVelocity /= neighbourTotal;
            averageNeighbourPosition /= neighbourTotal;
            Vector3 desiredPosition = averageNeighbourPosition + 80f * totalSeparation + 10f * averageVelocity + 10f * (player.transform.position - transform.position);
            float desiredAngle = Mathf.Atan2(desiredPosition.y, desiredPosition.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, 0f, desiredAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, moveSpeed * Time.deltaTime);
        }

        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        float horizontal = Mathf.Cos(angle);
        float vertical = Mathf.Sin(angle);
        Vector2 velocity = new Vector2(horizontal, vertical) * moveSpeed;
        rb.AddForce(velocity, ForceMode2D.Impulse);
    }
}
