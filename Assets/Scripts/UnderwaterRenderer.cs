using UnityEngine;

public class UnderwaterRenderer : MonoBehaviour {

  public Color fogColor;
  public float fogDensity;
  public Color ambientLightColor;

  public Light sun;
  private float sunIntensity;

  private Color normalAmbientLight;
  private Color normalFogColor;
  private float normalFogDensity;
  private Transform cTransform;

  private float waterLevel;

  private bool underwater;

  void Awake() {
    cTransform = transform;

    if (sun == null) { sun = GameObject.Find("Sun").GetComponent<Light>(); }

    normalAmbientLight = RenderSettings.ambientLight;
    normalFogColor = RenderSettings.fogColor;
    normalFogDensity = RenderSettings.fogDensity;
    sunIntensity = sun.intensity;

    Messenger.AddListener("playerEnteredWater", OnPlayerEnteredWater);
    Messenger.AddListener("playerExitedWater", OnPlayerExitedWater);
  }

  void Update() {
    if (underwater) {
      sun.intensity = 0.2f - (waterLevel - cTransform.position.y) * 0.01f;
    }
  }

  void OnPlayerEnteredWater() {
    underwater = true;

    waterLevel = cTransform.position.y;

    RenderSettings.ambientLight = ambientLightColor;
    RenderSettings.fogColor = fogColor;
    RenderSettings.fogDensity = fogDensity;

    GetComponent<Vignetting>().enabled = true;
    GetComponent<Blur>().enabled = true;
  }

  void OnPlayerExitedWater() {
    underwater = false;

    RenderSettings.ambientLight = normalAmbientLight;
    RenderSettings.fogColor = normalFogColor;
    RenderSettings.fogDensity = normalFogDensity;
    sun.intensity = sunIntensity;

    GetComponent<Vignetting>().enabled = false;
    GetComponent<Blur>().enabled = false;
  }
}