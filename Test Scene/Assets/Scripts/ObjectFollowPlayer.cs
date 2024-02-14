using UnityEngine;

public class ObjectFollowPlayer : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform

    private Vector3 lastPlayerPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPlayerPosition = playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            // Calculate the direction from the object to the player
            Vector3 direction = playerTransform.position - transform.position;
            direction.y = 0f; // Ignore the height difference

            // Calculate the player's velocity
            Vector3 playerVelocity = (playerTransform.position - lastPlayerPosition) / Time.deltaTime;
            lastPlayerPosition = playerTransform.position;

            // Calculate the follow speed based on the player's speed
            float followSpeed = playerVelocity.magnitude;

            // Move the object towards the player
            transform.position += direction.normalized * followSpeed * Time.deltaTime;
        }
    }
}
