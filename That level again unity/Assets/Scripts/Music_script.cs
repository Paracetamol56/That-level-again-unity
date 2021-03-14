using UnityEngine;

public class Music_script : MonoBehaviour
{
    private AudioSource audioSource;
    private static Music_script instance = null;
    public static Music_script Instance { get { return instance; } }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    public void ToogleMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }
}
