using UnityEngine;

public class SingletonTemplate<T> : MonoBehaviour where T: SingletonTemplate<T>
{
    public static T Instance { get; protected set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            Debug.LogError("An instance of this singleton already exists.");
        }
        else
        {
            Instance = (T)this;
        }
    }
}
