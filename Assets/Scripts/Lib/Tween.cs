using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// https://github.com/sole/tween.js/blob/master/src/Tween.js

public class Tween : MonoBehaviour {

  public static float BounceIn(float k) {
    return 1f - BounceOut(1f - k);
  }

  public static float BounceOut(float k) {
    if ( k < ( 1f / 2.75f ) ) {
      return 7.5625f * k * k;
    } else if ( k < ( 2f / 2.75f ) ) {
      return 7.5625f * ( k -= ( 1.5f / 2.75f ) ) * k + 0.75f;
    } else if ( k < ( 2.5f / 2.75f ) ) {
      return 7.5625f * ( k -= ( 2.25f / 2.75f ) ) * k + 0.9375f;
    } else {
      return 7.5625f * ( k -= ( 2.625f / 2.75f ) ) * k + 0.984375f;
    }
  }

  public static float BounceInOut(float k) {
    if ( k < 0.5f ) return BounceIn( k * 2f ) * 0.5f;
    return BounceOut( k * 2f - 1f ) * 0.5f + 0.5f;
  }
}