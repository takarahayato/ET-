using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemBlock : MonoBehaviour
{
    public GameObject ItemImg;
    public string Item;
    private bool get_flag = false;
    private int stop_counter = 0;
    // 2Dの場合は2Dが後ろに付く。
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("chara")){
            Debug.Log(Item);
            get_flag = true;
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

        if (get_flag && stop_counter <= 20)
        {
            ItemImg.transform.position += new Vector3(0, 0.03f, 0);
            stop_counter += 1;
        }
    }
}
