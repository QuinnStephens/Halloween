using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FootstepAudio : MonoBehaviour {

  public FirstPersonDrifter drifter;
  public float timeBetweenSteps;
  public float stepVariation;
  public float startingPitch = 1f;
  public float pitchVariation;
  public AudioSource[] sources;

  void Start() {
    drifter = GetComponent<FirstPersonDrifter>();
    StartCoroutine(FootstepLoop());
  }

  IEnumerator FootstepLoop() {
    while(true) {
      if (drifter.grounded && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)) {
        AudioSource clip = sources[Random.Range(0, sources.Length)];
        clip.pitch = Random.Range(startingPitch - pitchVariation / 2, startingPitch + pitchVariation / 2);
        clip.Play();
      }
      yield return new WaitForSeconds(Random.Range(timeBetweenSteps - stepVariation / 2, timeBetweenSteps + stepVariation / 2));
    }
  }
  
}