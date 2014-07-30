using UnityEngine;

public class UnderwaterMovement : MonoBehaviour {

  public float walkSpeed;
  public float jumpSpeed;
  public float gravity;
  
  private FirstPersonDrifter drifter;
  private float cWalkSpeed;
  private float cRunSpeed;
  private float cJumpSpeed;
  private float cGravity;

  void Awake() {
    drifter = GetComponent<FirstPersonDrifter>();
    cWalkSpeed = drifter.walkSpeed;
    cRunSpeed = drifter.runSpeed;
    cJumpSpeed = drifter.jumpSpeed;
    cGravity = drifter.gravity;

    Messenger.AddListener("playerEnteredWater", OnPlayerEnteredWater);
    Messenger.AddListener("playerExitedWater", OnPlayerExitedWater);
  }

  void OnPlayerEnteredWater() {
    drifter.swimming = true;
    drifter.walkSpeed = drifter.runSpeed = walkSpeed;
    drifter.jumpSpeed = jumpSpeed;
    drifter.gravity = gravity;
  }

  void OnPlayerExitedWater() {
    drifter.swimming = false;
    drifter.walkSpeed = cWalkSpeed;
    drifter.runSpeed = cRunSpeed;
    drifter.jumpSpeed = cJumpSpeed;
    drifter.gravity = cGravity;
  }
}