using UnityEngine;

public class Music_script : MonoBehaviour
{
    private AudioSource audioSource;
    private static Music_script instance = null;
    public static Music_script Instance { get { return instance; } }

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (PlayerPrefs.GetInt("Music") == 1)
        {
            audioSource.Play();
        }
        else if (PlayerPrefs.GetInt("Music") == 0)
            {
            audioSource.Stop();
        }
        else
        {
            PlayerPrefs.SetInt("Music", 1);
            audioSource.Play();
        }

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
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            audioSource.Play();
            PlayerPrefs.SetInt("Music", 1);
        }
    }
}
