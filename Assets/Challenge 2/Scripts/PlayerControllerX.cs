using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject dogPrefab;

    [Header("Settings")]
    [SerializeField] private float pressInterval = 1f;

    private float lastPressTime;

    private void Start()
    {
        lastPressTime = float.MinValue;
    }

    private void Update()
    {
        // on spacebar pressed off-cooldown, send dog
        if (Input.GetKeyDown(KeyCode.Space) &&
            Time.time >= lastPressTime + pressInterval)
        {
            // spawn a dog
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            // update timer values
            lastPressTime = Time.time;
        }
    }
}
