using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float leftLimit = -30f;
    [SerializeField] private float bottomLimit = -5f;

    private void Update()
    {
        // destroy dogs if x position less than left limit
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        } 
        // destroy balls if y position is less than bottomLimit
        else if (transform.position.y < bottomLimit)
        {
            // lose one life during gameplay
            if (GameManager.singleton.IsGameInProgress)
                GameManager.singleton.LoseLife(1);

            Destroy(gameObject);
        }
    }
}
