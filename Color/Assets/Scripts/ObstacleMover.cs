using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    private float speed = 5f;
    private float destroyLimit = -5f;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Destroy after passing player
        if (transform.position.z < destroyLimit)
        {
            Destroy(gameObject);
        }
            
    }
}
