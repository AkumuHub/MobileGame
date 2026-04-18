using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{

    public static AudioManagerScript Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip UiClick;
    public AudioClip AnvilClick;
    public AudioClip NormalSwordCreated;
    public AudioClip GoodSwordCreated;
    public AudioClip PerfectSwordCreated;


    public AudioClip BackgroundMusic;

    private float musicVolume = 1f;
    private float sfxVolume = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            
            AudioSource[] sources = GetComponents<AudioSource>();

            if (sources.Length >= 2)
            {
                musicSource = sources[0];
                sfxSource = sources[1];
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume", 1f));
        SetSFXVolume(PlayerPrefs.GetFloat("SFXVolume", 1f));
        PlayMusic(BackgroundMusic);
    }


    public void PlaySound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip, sfxVolume);
    }

    public void StopSound()
    {
        sfxSource.Stop();
    }

    
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
}
