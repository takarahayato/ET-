using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemBlock : MonoBehaviour
{
    public string Item;
    public GameObject Hatenatext;
    // 2Dの場合は2Dが後ろに付く。
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("chara")){
             Hatenatext.SetActive(true);
            //  Debug.Log(Item);
            // SceneManager.LoadScene("GameOver");
          }
    }


    
  


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
