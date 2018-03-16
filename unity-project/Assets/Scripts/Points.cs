using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update() {
    transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
  }

  public void Collected() {
    //this.GetComponentInParent<AudioSource>().Play();
    Destroy(gameObject);
  }
}
