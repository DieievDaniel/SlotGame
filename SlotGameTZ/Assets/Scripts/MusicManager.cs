using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource spinSound;

    private bool isPlaying = false;

    public AudioSource _spinSound => this.spinSound;

    public void PlaySpinSound()
    {
        StartCoroutine(PlaySpinSoundForDuration(10f));
    }
    public IEnumerator PlaySpinSoundForDuration(float duration)
    {
        isPlaying = true;
        spinSound.PlayOneShot(spinSound.clip);
        yield return new WaitForSeconds(duration);
        isPlaying = false;
    }
}
