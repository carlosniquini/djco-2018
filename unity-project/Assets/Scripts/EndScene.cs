using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour {

  public Sprite[] panels;
  private float time;
  private float coffee;

  // Use this for initialization
  void Start () {
    time = PlayerPrefs.GetFloat("time");
    coffee = PlayerPrefs.GetInt("coffee");

    if (PlayerPrefs.GetInt("status") == 0) {
      GameObject.Find("Panel").GetComponent<Image>().sprite = panels[1];
      this.GetComponents<AudioSource>()[1].Play();
      GameObject.Find("BtnText").GetComponent<Text>().text = "Try Again";
    } else {
      GameObject.Find("Panel").GetComponent<Image>().sprite = panels[0];
      this.GetComponents<AudioSource>()[0].Play();
      GameObject.Find("BtnText").GetComponent<Text>().text = "Play Again";
    }
    GameObject.Find("TimerText").GetComponent<Text>().text = "" + time.ToString("F2") + "s";
    GameObject.Find("CoffeeText").GetComponent<Text>().text = "" + coffee;
  }

  // Update is called once per frame
  void Update () {

  }
}
