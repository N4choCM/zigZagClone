using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target; // The target to follow
    private Vector3 offset; // Offset from the target

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        offset = transform.position - target.position;
    }

    // LateUpdate is called after all Update methods have been called
    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
