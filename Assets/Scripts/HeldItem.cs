using UnityEngine;

public class HeldItem : MonoBehaviour {
  
  public AudioSource startSound;
  public Transform worldItem;
  protected Transform cTransform;
  private float timer = 0.0f;
  private float bobbingSpeed = 0.15f;
  private Vector3 bobbingAmount = new Vector3(0.01f, 0.02f, 0.01f);
  private Vector3 midpoint;

  public virtual void Awake() {
    cTransform = transform;
    midpoint = cTransform.localPosition;
  }

  void OnEnable() {
    worldItem.gameObject.SetActive(false);

    if (startSound != null) {
      startSound.Play();
    }
  }

  void OnDisable() {
    worldItem.gameObject.SetActive(true);
  }

  public virtual void FixedUpdate () {
    float waveslice = 0.0f;
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");

    Vector3 cSharpConversion = cTransform.localPosition; 

    if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) {
      timer = 0.0f;
    }
    else {
      waveslice = Mathf.Sin(timer);
      timer = timer + bobbingSpeed;
      if (timer > Mathf.PI * 2) {
        timer = timer - (Mathf.PI * 2);
      }
    }
    if (waveslice != 0) {
      Vector3 translateChange = waveslice * bobbingAmount;
      float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
      totalAxes = Mathf.Clamp (totalAxes, 0.0f, 1.0f);
      translateChange = totalAxes * translateChange;
      cSharpConversion = midpoint + translateChange;
    }
    else {
      cSharpConversion = midpoint;
    }

    cTransform.localPosition = cSharpConversion;
  }

  public virtual void Use() {}

  public virtual void Drop() {
    worldItem.position = cTransform.position;
    worldItem.rotation = cTransform.rotation;
    
    if (worldItem.rigidbody != null) {
      worldItem.rigidbody.AddForce(worldItem.right * 100);
    }

    gameObject.SetActive(false);
  }

}