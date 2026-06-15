using UnityEngine;

public class CarRespawn : MonoBehaviour
{
    private Vector3 startPos;
    private Quaternion startRot;

    private float upsideTimer = 0f;

    public float resetTime = 3f;

    void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    void Update()
    {
        if (transform.up.y < 0)
        {
            upsideTimer += Time.deltaTime;

            if (upsideTimer >= resetTime)
            {
                Respawn();
            }
        }
        else
        {
            upsideTimer = 0f;
        }
    }

    void Respawn()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        transform.position = startPos;
        transform.rotation = startRot;

        GameManager.Instance.LoseStar();

        upsideTimer = 0f;
    }
}