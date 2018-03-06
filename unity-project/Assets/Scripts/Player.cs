using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

  private int coffee = 0;

  void Update() {
    if (transform.position.y < -5)
      replay();
  }

  public void replay() {
    coffee = 0;
    GameObject.Find("CoffeeText").GetComponent<Text>().text = "Coffee: " + coffee;
    gameObject.transform.position = new Vector3(1, 5, 1);
  }

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Mug")) {
      coffee++;
      GameObject.Find("CoffeeText").GetComponent<Text>().text = "Coffee: " + coffee;
      other.gameObject.GetComponent<Points>().Collected();
      //Debug.Log("Coletou");
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
