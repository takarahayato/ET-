using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Camera : MonoBehaviour {
 
    //寿司を格納する変数
    public GameObject chara;
 
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
 
        Vector3 charaPos = chara.transform.position;
 
        //カメラとプレイヤーの位置を同じにする
        transform.position = new Vector3(charaPos.x, charaPos.y+2,-10);
    }
}