using UnityEngine;

public class Music_script : MonoBehaviour
{
    private AudioSource _audioSource;
    private static Music_script instance = null;
    public static Music_script Instance { get { return instance; } }

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

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
        if (_audioSource.isPlaying)
            _audioSource.Stop();
        else
            _audioSource.Play();
    }
}
