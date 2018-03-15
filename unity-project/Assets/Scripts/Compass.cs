using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour {

  public Vector3 northDirection;
  public Transform player;
  public Quaternion missionDirection;

  public RectTransform northLayer;
  public RectTransform missionLayer;

  public Transform missionPlace;



  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {
    ChangeNorth();
    ChangeMissionDirection();

  }

  public void ChangeNorth() {
    northDirection.z = player.eulerAngles.y;
    northLayer.localEulerAngles = northDirection;

  }

  public void ChangeMissionDirection() {
    Vector3 dir = transform.position - missionPlace.position;
    missionDirection = Quaternion.LookRotation(dir);
    missionDirection.z = -missionDirection.y;
    missionDirection.x = 0;
    missionDirection.y = 0;

    missionLayer.localRotation = missionDirection * Quaternion.Euler(northDirection);
  }
}
