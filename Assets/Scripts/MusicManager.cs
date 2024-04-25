using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;
    private Dialogue dialogue; 

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
        // Get the Dialogue component
        dialogue = FindObjectOfType<Dialogue>();
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

        // Check if the current scene is scene 1 or if dialogue is active
        if (currentSceneIndex == 1 || (dialogue != null && dialogue.isActiveAndEnabled))
        {
            // Lower the volume of the music if in scene 1 or dialogue is active
            audioSource.volume = 0.2f; // Adjust the volume level as needed
        }
        else
        {
            // Reset the volume if neither in scene 1 nor dialogue is active
            audioSource.volume = 0.4f;
        }

        // Check if the music is not already playing
        if (!audioSource.isPlaying)
        {
            // Play music if not in scene 1 and dialogue is not active
            audioSource.Play();
        }
    }
}
