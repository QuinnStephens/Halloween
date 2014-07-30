using UnityEngine;

public class InputManager : MonoBehaviour {

  Transform targetItem;
  HeldItem heldItem;
  
  void Awake() {
    Messenger.AddListener<Transform>("usableItem", OnUsableItem);
    Messenger.AddListener<HeldItem>("heldItem", OnHeldItem);
  }

  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      if (targetItem != null) {
        Messenger.Broadcast<Transform>("itemUsed", targetItem);
      }
      else if (heldItem != null) {
        Messenger.Broadcast<HeldItem>("heldItemUsed", heldItem);
      }
    }
    if (Input.GetMouseButtonDown(1)) {
      Messenger.Broadcast("itemDropped");
    }
  }

  void OnUsableItem(Transform item) {
    targetItem = item;
  }

  void OnHeldItem(HeldItem item) {
    heldItem = item;
  }

}