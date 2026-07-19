using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake ( )
    {
        instance = this;
    }

    public void PlaySfx ( AudioClip clip, float volume = 1.0f )
    {
        StartCoroutine (PlaySfxCoroutine(clip, volume));
    }
    private System.Collections.IEnumerator PlaySfxCoroutine ( AudioClip clip, float volume )
    {
        AudioSource source = gameObject.AddComponent<AudioSource> ( );
        source.clip = clip;
        source.volume = volume;
        source.Play();

        yield return new WaitForSeconds(source.clip.length * 2);

        Destroy ( source );
    }
}
