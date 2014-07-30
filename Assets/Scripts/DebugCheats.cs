using UnityEngine;

public class DebugCheats : MonoBehaviour {

  public FirstPersonDrifter drifter;
  private float cSpeed;

  void Awake() {
    if (!Debug.isDebugBuild) {
      gameObject.SetActive(false);
    }

    cSpeed = drifter.walkSpeed;
  }
  
  void Update() {
    if (Input.GetKeyDown(KeyCode.Alpha0)) {
      drifter.Speed = drifter.Speed == cSpeed ? cSpeed * 10f : cSpeed;
    }
  }

}