using UnityEngine;
using System.Collections.Generic;

public class HeldItemManager : MonoBehaviour {

  private List<HeldItem> allItems = new List<HeldItem>();
  private HeldItem currentItem;

  void Awake(){
    foreach(Transform child in transform) {
      child.gameObject.SetActive(false);
      HeldItem item = child.GetComponent<HeldItem>();
      if (item != null) { allItems.Add(item); }
    }

    Messenger.AddListener<Transform>("itemUsed", OnItemUsed);
    Messenger.AddListener("itemDropped", OnItemDropped);
    Messenger.AddListener<HeldItem>("heldItemUsed", OnHeldItemUsed);
  }

  void OnItemUsed(Transform itemTransform) {
    HeldItem heldItem = null;

    foreach(HeldItem item in allItems) {
      if (itemTransform == item.worldItem) { heldItem = item; break; }
    }

    if (heldItem != null) {
      if (currentItem != null) { currentItem.Drop(); }
      currentItem = heldItem;

      heldItem.gameObject.SetActive(true);
      Messenger.Broadcast<HeldItem>("heldItem", heldItem);
    }
  }

  void OnHeldItemUsed(HeldItem item) {
    if (item == currentItem) {
      item.Use();
    }
  }

  void OnItemDropped() {
    if (currentItem != null) {
      currentItem.Drop();
      currentItem = null;
      Messenger.Broadcast<HeldItem>("heldItem", null);
    }
  }

}