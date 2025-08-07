using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public Transform rayStart; // The starting point of the ray
    private Animator animator; // Animator component for character animations
    private Rigidbody rb;
    private bool goRight = true;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeDirection();
        }

        RaycastHit hit;

        if(!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            animator.SetTrigger("Falling");
        }
    }

    // FixedUpdate is called every fixed frame-rate frame
    private void FixedUpdate()
    {
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    // Called when the user presses the space key to change direction. to the right or left
    private void ChangeDirection()
    {
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
}
