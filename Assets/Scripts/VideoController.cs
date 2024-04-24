using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Preload the video
        videoPlayer.Prepare();

        // Subscribe to the prepareCompleted event to know when the video is ready
        videoPlayer.prepareCompleted += VideoPrepared;
    }

    void VideoPrepared(VideoPlayer vp)
    {
        // Video is prepared, now you can play it
        vp.Play();

        // Unsubscribe from the prepareCompleted event
        vp.prepareCompleted -= VideoPrepared;
    }
}