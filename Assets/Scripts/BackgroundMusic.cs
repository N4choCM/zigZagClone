using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic bm;
    private void Awake()
    {
        if (bm == null)
        {
            bm = this;
        }
        else if (bm != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
