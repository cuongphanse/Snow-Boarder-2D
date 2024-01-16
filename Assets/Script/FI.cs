using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FI : MonoBehaviour
{
    [SerializeField] float delatTime = 0.5f;
    [SerializeField] ParticleSystem finishEffect;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", delatTime);
        }
    }

    void ReloadScene(){
        SceneManager.LoadScene(0);
    }
}
