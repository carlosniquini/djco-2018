using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour {

  public Texture2D fadeTexture;
  public float speed = 0.8f;

  private int drawDepth = -1000;
  private float alpha = 1.0f;
  private int fadeDir = -1;

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {

  }

  private void OnGUI() {
    alpha += fadeDir * speed * Time.deltaTime;
    alpha = Mathf.Clamp01(alpha);
    GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
    GUI.depth = drawDepth;
    GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
  }

  private float StartFade(int direction) {
    fadeDir = direction;
    return (speed);
  }

  private void OnLevelWasLoaded() {
    StartFade(-1);
  }

  private IEnumerator Fade(string cena) {
    float fadetime = StartFade(1);
    yield return new WaitForSeconds(0.5f);
    SceneManager.LoadScene(cena);
  }

  public void mainMenuScene() {
    StartCoroutine(Fade("mainMenu"));
  }

  public void taleScene() {
    StartCoroutine(Fade("tale"));
  }

  public void selectPlayerScene() {
    StartCoroutine(Fade("selectPlayer"));
  }

  public void selectPlaceScene() {
    StartCoroutine(Fade("selectPlace"));
  }

  public void mainScene() {
    StartCoroutine(Fade("main"));
    //SceneManager.LoadScene("main");
  }

  public void endScene() {
    StartCoroutine(Fade("end"));
  }

  public void aboutScene() {
    StartCoroutine(Fade("about"));
  }

  public void instructScene() {
    StartCoroutine(Fade("instructions"));
  }
}
