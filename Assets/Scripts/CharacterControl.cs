using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public Transform rayStart; // The starting point of the ray
    private Animator animator; // Animator component for character animations
    private Rigidbody rb;
    private bool goRight = true;
    private GameManager gm; // Reference to the GameManager
    public GameObject crystalEffect; // Particle effect prefab for collecting crystals

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gm = FindFirstObjectByType<GameManager>(); // Find the GameManager in the scene
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeDirection();
        }

        RaycastHit hit;

        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            animator.SetTrigger("Falling");
        }

        if (transform.position.y < -10)
        {
            gm.EndGame(); // Call EndGame method in GameManager if the character falls below a certain height
        }
    }

    // FixedUpdate is called every fixed frame-rate frame
    private void FixedUpdate()
    {
        if (!gm.isGameStarted)
        {
            return; // Exit if the game has not started
        }
        else
        {
            animator.SetTrigger("GameStarted");
        }

        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    // Called when the user presses the space key to change direction. to the right or left
    private void ChangeDirection()
    {
        if (!gm.isGameStarted)
        {
            return; // Exit if the game has not started
        }

        goRight = !goRight;

        if (goRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            gm.IncreaseScore(); // Call IncreaseScore method in GameManager to increase the score
            GameObject go = Instantiate(crystalEffect, rayStart.transform.position, Quaternion.identity);
            Destroy(go, 2f); // Destroy the particle effect after 2 seconds
            Destroy(other.gameObject); // Destroy the crystal object
        }
    }
}
