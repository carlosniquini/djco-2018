using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaleScene : MonoBehaviour {

  string text = "Welcome to your first day of ERASMUS at FEUP.\nThe class will start so hurry up to find your class!\nYour class is on B205, have enough coffee to save time\n and beware of the holes.\nGood luck!";

  // Use this for initialization
  void Start () {
    Text obj = GameObject.Find("Text").GetComponent<Text>();
    StartCoroutine(Effects.Write(text, obj));
  }

  // Update is called once per frame
  void Update () {

  }
}
