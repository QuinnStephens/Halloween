using UnityEngine;

public class GameGui : MonoBehaviour {

  public Texture2D hudCenter;
  public Texture2D hand;

  private bool showHand = false;

  void Awake() {
    Messenger.AddListener<Transform>("usableItem", OnUsableItem);
  }
  
  void OnGUI() {
    GUI.DrawTexture(new Rect(Screen.width / 2 - 3, Screen.height / 2 - 3, 6, 6), hudCenter);
    if (showHand) { 
      GUI.DrawTexture(new Rect(Screen.width / 2 - 25, Screen.height / 2 - 25, 50, 50), hand); 
    }
  }

  void OnUsableItem(Transform item) {
    showHand = item != null;
  }

}