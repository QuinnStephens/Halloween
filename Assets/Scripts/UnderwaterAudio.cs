using UnityEngine;

public class UnderwaterAudio : MonoBehaviour {

  private AudioLowPassFilter lowPass;

  void Awake() {
    lowPass = GetComponent<AudioLowPassFilter>();
    lowPass.enabled = false;

    Messenger.AddListener("playerEnteredWater", OnPlayerEnteredWater);
    Messenger.AddListener("playerExitedWater", OnPlayerExitedWater);
  }


  void OnPlayerEnteredWater() {
    lowPass.enabled = true;

  }

  void OnPlayerExitedWater() {
    lowPass.enabled = false;

  }
}