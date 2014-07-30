using UnityEngine;
using System;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
  protected static T _main;
  protected bool destroyed = false;

  protected virtual void Awake() {
    // If no singleton yet, assign this
    if (_main == null) {
      _main = (T) ((MonoBehaviour) this);
    }
    // Otherwise, kill ourself if we're a dupe
    else if (this != main) {
      Destroy(gameObject);
      destroyed = true;
    }
  }

  // Returns the instance of this singleton.
  public static T main {
    get {
      if (_main == null) {
        _main = (T) FindObjectOfType(typeof(T));

        if (_main == null)
          Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
      }

      return _main;
    }
  }
}

public class ReplaceableSingleton<T> : MonoBehaviour where T : MonoBehaviour {
  protected static T _main;

  void Awake() {
    // Kill old singleton
    if (_main != null && this != main)
      Destroy(_main.gameObject);
  }

  // Returns the instance of this singleton.
  public static T main {
    get {
      if (_main == null) {
        _main = (T) FindObjectOfType(typeof(T));

        if (_main == null)
          Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
      }

      return _main;
    }
  }
}