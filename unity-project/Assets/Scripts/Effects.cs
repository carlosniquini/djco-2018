using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Effects {

  public static IEnumerator Write(string text, Text obj) {
    int i = 0;
    while (i < text.Length) {
      obj.text = obj.text + text[i];
      i++;
      yield return new WaitForSeconds(0.04f);
    }

  }

}
