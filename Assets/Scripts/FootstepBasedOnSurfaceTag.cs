using StarterAssets;
using UnityEngine;

public class FootstepBasedOnSurfaceTag : MonoBehaviour
{
    [Header("References")]
    public ThirdPersonControllerFixed PlayerSound;

    [Header("Audio Clips")]
    public AudioClip[] SandAudioClips;
    public AudioClip[] DirtAudioClips;
    public AudioClip[] WoodAudioClips;
    public AudioClip[] StoneAudioClips;
    public AudioClip[] WaterAudioClips;
    [Header("Audio Volume")]
    [Range(0,1)] public float SandVolume = 0.5f;
    [Range(0,1)] public float DirtVolume = 0.5f;
    [Range(0,1)] public float WoodVolume = 0.5f;
    [Range(0,1)] public float StoneVolume = 0.5f;
    [Range(0,1)] public float WaterVolume = 0.5f;

    private string currentSurfaceTag;

    [Header("Raycast")]
    public float raycastDistance;

    void Start()
    {
        GetComponent<ThirdPersonControllerFixed>();
    }

    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position + Vector3.up, Vector3.down, out hit, raycastDistance))
        {
            if (hit.collider.tag == currentSurfaceTag)
                return;

            currentSurfaceTag = hit.collider.gameObject.tag;
            
            switch (currentSurfaceTag)
            {
                case "Sand":
                    PlayerSound.FootstepAudioClips = SandAudioClips;
                    PlayerSound.FootstepAudioVolume = SandVolume;
                    break;
                case "Dirt":
                    PlayerSound.FootstepAudioClips = DirtAudioClips;
                    PlayerSound.FootstepAudioVolume = DirtVolume;
                    break;
                case "Stone":
                    PlayerSound.FootstepAudioClips = StoneAudioClips;
                    PlayerSound.FootstepAudioVolume = StoneVolume;
                    break;
                case "Wood":
                    PlayerSound.FootstepAudioClips = WoodAudioClips;
                    PlayerSound.FootstepAudioVolume = WoodVolume;
                    break;
                case "Water":
                    PlayerSound.FootstepAudioClips = WaterAudioClips;
                    PlayerSound.FootstepAudioVolume = WaterVolume;
                    break;
                default:
                    break;
            }
        }
    }
}
