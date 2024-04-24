using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public RawImage rawImage;
    public VideoClip videoClip;

    private VideoPlayer videoPlayer;
    private RenderTexture renderTexture;

    void Start()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        renderTexture = new RenderTexture((int)rawImage.rectTransform.rect.width, (int)rawImage.rectTransform.rect.height, 0);
        
        videoPlayer.playOnAwake = false;
        videoPlayer.clip = videoClip;
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;
        videoPlayer.targetTexture = renderTexture;
        videoPlayer.Play();

        rawImage.texture = renderTexture;
    }
}
