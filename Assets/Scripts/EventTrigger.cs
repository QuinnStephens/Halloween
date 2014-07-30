using UnityEngine;

public class EventTrigger : MonoBehaviour {
  
  public string eventString;

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "Player") {
      Messenger.Broadcast("event:" + eventString);
    }
  }
}