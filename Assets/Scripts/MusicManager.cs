using UnityEngine;
public class MusicManager : MonoBehaviour
{
    public static MusicManager intance;
    private void Awake()
    {
        if (intance == null)
        {
            intance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
