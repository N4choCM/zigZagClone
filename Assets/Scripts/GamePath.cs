using UnityEngine;

public class GamePath : MonoBehaviour
{
    public GameObject pathPrefab; // Prefab for the path segment
    public Vector3 lastPosition; // Last position where a path segment was placed
    public float differenceThreshold = 0.70f; // Minimum distance to place a new segment
    private int pathBlocksCount = 0; // Counter for the number of path blocks created

    public void InitMapBuild()
    {
        InvokeRepeating("CreateNewPathBlock", 1f, 0.5f); // Start creating path blocks after 2 seconds, repeat every 0.5 seconds
    }

    public void CreateNewPathBlock()
    {
        print("Creating new path block");
        Vector3 newPosition = Vector3.zero;
        float option = Random.Range(0, 100); // Randomly choose between 1 and 100
        if (option <= 50)
        {
            newPosition = new Vector3(
                lastPosition.x + differenceThreshold,
                lastPosition.y,
                lastPosition.z + differenceThreshold
                );
        }
        else
        {
            newPosition = new Vector3(
                lastPosition.x - differenceThreshold,
                lastPosition.y,
                lastPosition.z + differenceThreshold
                );
        }
        GameObject go = Instantiate(pathPrefab, newPosition, Quaternion.Euler(0, 45, 0));
        lastPosition = go.transform.position;

        pathBlocksCount++;
        if(pathBlocksCount % 5 == 0)
        {
            go.transform.GetChild(0).gameObject.SetActive(true); // Activate the diamond on every 5th block
        }
    }
}
