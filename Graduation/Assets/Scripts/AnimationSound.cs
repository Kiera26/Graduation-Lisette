using UnityEngine;

// Plays a sound during an animation using an AudioSource.
public class AnimationSound : MonoBehaviour
{
    // Reference to the AudioSource component.
    public AudioSource audioSource;

    // Called via animation event to play the sound.
    public void PlaySound()
    {
        audioSource.Play(); // Plays the assigned audio clip.
    }
}
