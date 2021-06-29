using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip click, punch;

    static AudioSource audioSource;

    void Start()
    {
        click = Resources.Load<AudioClip>("click");
        punch = Resources.Load<AudioClip>("punch");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "click":
                audioSource.PlayOneShot(click);
                break;

            case "punch":
                audioSource.PlayOneShot(punch);
                break;
        }
    }
}