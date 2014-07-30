using UnityEngine;

public class CheckUsableItems : MonoBehaviour {

  public Transform fpCamera;
  private int itemsLayer;

  void Awake() {
    itemsLayer = 1 << LayerMask.NameToLayer("Items");
  }

  void Update() {
    Transform item = null;
    RaycastHit hit;
    if (Physics.Raycast(fpCamera.position, fpCamera.forward, out hit, 2f, itemsLayer)) {
      item = hit.transform;
    }
    Messenger.Broadcast<Transform>("usableItem", item);
  }

}