using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public static class Extensions {


  public static string Capitalize(this string str) {
    if (System.String.IsNullOrEmpty(str))
      return str;
    if (str.Length == 1)
      return str.ToUpper();
    return str.Remove(1).ToUpper() + str.Substring(1);
  }

  public static string Camelize(this string input) {
    if (input == null) return null;

    System.Globalization.TextInfo textInfo = new System.Globalization.CultureInfo("en-US", false).TextInfo;
    return textInfo.ToTitleCase(input.Trim()).Replace(" ", "");
  }

  public static U Get<T, U>(this IDictionary<T, U> dic, T key) {
    if (key != null && dic.ContainsKey(key))
      return dic[key];
    return default(U);
  }

  public static T RandomObject<T>(this IList<T> list) {
    if (list.Count > 0) {
      return list[UnityEngine.Random.Range(0, list.Count)];
    }
    return default(T);
  }

  public static Dictionary<string,object> GetDictionary<T, U>(this IDictionary<T, U> dic, T key) {
    if (key != null && dic.ContainsKey(key)) {
      object obj = dic[key];
      return (Dictionary<string,object>) obj;
    }
    return null;
  }

  public static List<object> GetList<T, U>(this IDictionary<T, U> dic, T key){
    if (key != null && dic.ContainsKey(key)) {
      object obj = dic[key];
      return (List<object>) obj;
    }
    return null;
  }


  public static bool GetBool<T, U>(this IDictionary<T, U> dic, T key, bool defaultValue = false) {
    if (key != null && dic.ContainsKey(key)) {
      object obj = dic[key];
      return (bool) obj;
    }
    return defaultValue;
  }

  public static string GetString<T, U>(this IDictionary<T, U> dic, T key) {
    if (key != null && dic.ContainsKey(key)) {
      object obj = dic[key];
      return (string) obj;
    }
    return null;
  }

  public static string GetString<T, U>(this IDictionary<T, U> dic, T key, string defaultValue) {
    if (key == null) return null;
    string val = dic.GetString(key);
    return val != null ? val : defaultValue;
  }

  public static int GetInt<T, U>(this IDictionary<T, U> dic, T key, int defaultValue = 0) {
    if (key != null && dic.ContainsKey(key)) {
      return Convert.ToInt32(dic[key]);
    }
    return defaultValue;
  }

  public static float GetFloat<T, U>(this IDictionary<T, U> dic, T key, float defaultValue = 0) {
    if (key != null && dic.ContainsKey(key)) {
      return Convert.ToSingle(dic[key]);
    }
    return defaultValue;
  }

  public static U Get<T, U>(this IDictionary<T, U> dic, T key, U defaultValue) {
    if (key != null && dic.ContainsKey(key))
      return dic[key];
    return defaultValue;
  }

  public static string Inspect<T, U>(this IDictionary<T, U> dic) {
    StringBuilder str = new StringBuilder();
    str.Append("{");

    foreach (var pair in dic) {
      str.Append(String.Format(" {0}={1} ", pair.Key, pair.Value));
    }

    str.Append("}");

    return str.ToString();
  }

  public static void Merge<TKey, TValue>(this Dictionary<TKey, TValue> me, Dictionary<TKey, TValue> merge) {
    foreach (var item in merge) {
      me[item.Key] = item.Value;
    }
  }

  public static T ToEnum<T>(this string me, T defaultValue) {
    System.Type type = typeof(T);
    if (Enum.IsDefined(type, me.Capitalize())) {
      return (T) Enum.Parse(type, me, true);
    } else {
      return defaultValue;
    }
  }

  public static void Shuffle<T>(this IList<T> list) {
      System.Random rng = new System.Random();
      int n = list.Count;
      while (n > 1) {
          n--;
          int k = rng.Next(n + 1);
          T value = list[k];
          list[k] = list[n];
          list[n] = value;
      }
  }

}
