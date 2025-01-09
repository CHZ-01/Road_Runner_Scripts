using UnityEngine;

public class Game_Audio : MonoBehaviour
{
    [Header("------SOURCES------")]
    [SerializeField] AudioSource SFX;

    [Header("------CLIPS------")]
    public AudioClip Dead;
    public AudioClip Coin;
    
    public void Play_SFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
