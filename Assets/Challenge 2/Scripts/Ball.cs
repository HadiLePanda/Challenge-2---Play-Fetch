using UnityEngine;

public class Ball : MonoBehaviour
{
    private void Update()
    {
        // auto destroy if the game has finished
        if (!GameManager.singleton.IsGameInProgress)
            Destroy(gameObject);
    }
}
