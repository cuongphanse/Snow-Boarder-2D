using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float delatTime = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrash = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground" && !hasCrash){
            hasCrash = true;
            FindObjectOfType<SpinPlayer>().DisableController();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", delatTime);
        }
    }
    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
