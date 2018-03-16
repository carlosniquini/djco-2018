using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstruScene : MonoBehaviour {

  // Use this for initialization
  void Start () {
    StartCoroutine(Skip());
  }

  private IEnumerator Skip() {
    yield return new WaitForSeconds(5f);
    GameObject.Find("Transition").GetComponent<Transition>().mainScene();
  }

  // Update is called once per frame
  void Update () {

  }
}
