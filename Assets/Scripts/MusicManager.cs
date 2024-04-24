using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    private void Awake()
    {
        // Ensure only one instance of the MusicManager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // Play music based on the current scene index
        PlayMusicBasedOnScene();
    }

    private void OnEnable()
    {
        // Subscribe to scene loading events
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from scene loading events
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Play music based on the current scene index when a new scene is loaded
        PlayMusicBasedOnScene();
    }

    private void PlayMusicBasedOnScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Check if the current scene is scene 2
        if (currentSceneIndex == 2)
        {
            // Stop music playback if in scene 2
            audioSource.Stop();
        }
        else
        {
            // Play music if not in scene 2
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
