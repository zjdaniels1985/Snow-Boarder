using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{ 
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    private bool _hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Ground") && !_hasCrashed)
        {
            // Disable player controls if crashed
            FindObjectOfType<PlayerController>().DisableControls();
            
            // Play Crash Particle System Effect
            crashEffect.Play();
            
            // Play crash audio sfx
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            
            // Set _hasCrashed to true to disable playing crash sfx and particle system more than once during crash
            _hasCrashed = true;
            
            // Reload scene after crash
            Invoke("ReloadScene", loadDelay);
            
        }    
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
