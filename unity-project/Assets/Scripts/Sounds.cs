using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sounds : MonoBehaviour {

  void Awake() {
    DontDestroyOnLoad(transform.gameObject);
  }

  // Use this for initialization
  void Start () {
    GameObject.Find("Transition").GetComponent<Transition>().mainMenuScene();
  }

  // Update is called once per frame
  void Update () {
    if (SceneManager.GetActiveScene().name == "main") {
      this.GetComponent<AudioSource>().mute = true;
    }
    if (SceneManager.GetActiveScene().name == "mainMenu" && this.GetComponent<AudioSource>().mute == true) {
      this.GetComponent<AudioSource>().Play();
      this.GetComponent<AudioSource>().mute = false;
    }
  }
}
