using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic;

    public static AudioManager instance;
    private AudioSource AudioSource;
    private AudioSource DecorAudio;
    private AudioSource PanAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        DecorAudio = GetComponent<AudioSource>();
        PanAudio = GetComponent<AudioSource>();

        if (backgroundMusic != null)
        {
            PlayBackgroundMusic(backgroundMusic);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayPanSound(AudioClip clip)
    {
        PanAudio.PlayOneShot(clip);
    }
    public void PlayCoinSound(AudioClip clip)
    {
        DecorAudio.PlayOneShot(clip);
    }
    public void PlayBackgroundMusic(AudioClip musicClip)
    {
        if (AudioSource != null && musicClip != null)
        {
            AudioSource.clip = musicClip;
            AudioSource.loop = true;
            AudioSource.Play();
        }
    }
}
