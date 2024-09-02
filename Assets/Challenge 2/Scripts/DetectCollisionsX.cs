using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // increase score when a ball touches a dog during gameplay
        if (GameManager.singleton.IsGameInProgress &&
            other.GetComponent<Dog>())
        {
            GameManager.singleton.AddScore(1);
        }

        // self-destruct
        Destroy(gameObject);
    }
}
