using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

  public Sprite[] spriteLife;
  private int life = 3;
  private int coffee = 0;

  void Start() {
    GameObject.Find("ImageLife").GetComponent<Image>().sprite = spriteLife[0];
	PlayerPrefs.SetInt("coffee", 0);
  }

  void Update() {

    if (Input.GetKey("w") && !this.GetComponents<AudioSource>()[1].isPlaying && this.transform.position.y == 0) {
      this.GetComponents<AudioSource>()[1].Play();
    }
    if (!Input.GetKey("w")) {
      this.GetComponents<AudioSource>()[1].Stop();
    }
    if (Input.GetKeyDown("space")) {
      this.GetComponents<AudioSource>()[1].Stop();
      this.GetComponents<AudioSource>()[2].Play();
    }
    //if (this.transform.position.y < 0) {
    // this.GetComponents<AudioSource>()[3].Play();
    //}

    if (transform.position.y < -5)
      replay();
  }

  public void replay() {
    //coffee = 0;
    life -= 1;
    if (life == 2) {
      GameObject.Find("ImageLife").GetComponent<Image>().sprite = spriteLife[1];
    } else if (life == 1) {
      GameObject.Find("ImageLife").GetComponent<Image>().sprite = spriteLife[2];
    } else {
      PlayerPrefs.SetInt("status", 0);
      PlayerPrefs.SetInt("coffee", coffee);
      GameObject.Find("GameController").GetComponent<GameController>().Finish();
      //GameObject.Find("Transition").GetComponent<Transition>().endScene();
    }
    GameObject.Find("CoffeeText").GetComponent<Text>().text = "" + coffee;
    gameObject.transform.position = new Vector3(1, 0, 1);
  }

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Mug")) {
      coffee++;
	  PlayerPrefs.SetInt("coffee", coffee);
      GameObject.Find("CoffeeText").GetComponent<Text>().text = "" + coffee;
      this.GetComponentsInParent<AudioSource>()[0].Play();
      GameObject.Find("GameController").GetComponent<GameController>().AddTime();
      other.gameObject.GetComponent<Points>().Collected();
      //Debug.Log("Coletou");
    }
    if (other.gameObject.CompareTag("Finish")) {
      PlayerPrefs.SetInt("status", 1);
      PlayerPrefs.SetInt("coffee", coffee);
      GameObject.Find("GameController").GetComponent<GameController>().Finish();
    }
  }
  /*
  private Rigidbody rb;
  public float maxVelocity = 3;
  public float rotationSpeed = 3;

  #region Monobehaviour API

  private void Start () {
  rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  private void Update () {
  float yAxis = Input.GetAxis("Vertical");
  float xAxis = Input.GetAxis("Horizontal");

  ThrustFoward(yAxis);
  Rotate(transform, xAxis * rotationSpeed);
  }
  #endregion

  #region Maneuvering API

  private void ClampVelocity() {
  float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
  float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

  rb.velocity = new Vector3(x, 0, y);
  }

  private void ThrustFoward(float amount) {
  Vector3 force = transform.forward * amount;
  rb.AddForce(force);
  }

  private void Rotate(Transform t, float amount) {
  t.Rotate(0, amount, 0);
  }

  #endregion
  */
}
