using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

  public GameObject mapaPrefab;
  public float initialTime;
  private float timer;
  private GameObject player;
  //private GameObject canvasMenu;
  //private GameObject canvasMsg;
  //private Button btnRestart;
  //private Button btnStart;
  private bool status = false;
  private GameObject mapa = null;

  // Use this for initialization
  void Start () {
    mapa = Instantiate(mapaPrefab) as GameObject;
    //Debug.Log(GameObject.Find("Compass").GetComponent<Compass>());
    //Debug.Log(GameObject.Find("EndPoint(Clone)").GetComponent<Transform>());
    GameObject.Find("Main Camera").GetComponent<Compass>().missionPlace = GameObject.Find("EndPoint(Clone)").GetComponent<Transform>();
    player = GameObject.Find("MaleFreeSimpleMovement1");
    status = true;
    timer = initialTime;
    /*
    canvasMenu = GameObject.Find("CanvasMenu");
    canvasMsg = GameObject.Find("CanvasMsg");
    btnStart = GameObject.Find("BtnStart").GetComponent<Button>() as Button;
    btnRestart = GameObject.Find("BtnRestart").GetComponent<Button>() as Button;
    btnStart.onClick.AddListener(delegate {
    canvasMenu.SetActive(false);
    player.SetActive(true);
    timer = initialTime;
    status = true;
    });
    btnRestart.onClick.AddListener(delegate {
    canvasMsg.SetActive(false);
    player.SetActive(true);
    timer = initialTime;
    status = true;
    });
    player.SetActive(false);
    canvasMsg.SetActive(false);
    */
  }

  // Update is called once per frame
  void Update () {
    if(status) Timer();
  }

  private void Timer() {
    GameObject.Find("TimerText").GetComponent<Text>().text = timer.ToString("F2");
    timer = timer - Time.deltaTime;
    if (timer <= 0) {
      status = false;
      //canvasMsg.SetActive(true);
      //GameObject.Find("TextRestart").GetComponent<Text>().text = "Você caiu no limbo do Blobo B. \n Tente mais uma vez";
      Restart();
    }
  }

  private void Restart() {
    Destroy(mapa);
    mapa = Instantiate(mapaPrefab) as GameObject;
    player.GetComponent<Player>().replay();
    //player.SetActive(false);
  }

  public void Finish() {
    status = false;
    //canvasMsg.SetActive(true);
    //GameObject.Find("TextRestart").GetComponent<Text>().text = "Você chegou!. \n Mas sua proxima aula é em um novo bloco, \n corra quando acabar essa aula.";
    Restart();
  }
}
