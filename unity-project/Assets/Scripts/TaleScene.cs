using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaleScene : MonoBehaviour {

  public string text;

  // Use this for initialization
  void Start () {
    Text obj = GameObject.Find("Text").GetComponent<Text>();
    StartCoroutine(Effects.Write(text, obj));
  }

  // Update is called once per frame
  void Update () {

  }
}
