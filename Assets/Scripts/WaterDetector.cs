using UnityEngine;

public class WaterDetector : MonoBehaviour {
  
  void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == LayerMask.NameToLayer("Water")) {
      Messenger.Broadcast("playerEnteredWater");
    }
  }

  void OnTriggerExit(Collider other) {
    if (other.gameObject.layer == LayerMask.NameToLayer("Water")) {
      Messenger.Broadcast("playerExitedWater");
    }
  }
}