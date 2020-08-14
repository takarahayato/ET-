using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{

    public Text timeText;
    public ResultTime time;

    // Start is called before the first frame update
    void Start()
    {
        var json = PlayerPrefs.GetString("SCORE");
        time = JsonUtility.FromJson<ResultTime>(json);
        timeText.text = time.minute.ToString("00") + ":" + ((int) time.second).ToString ("00") + ":" + ((int) time.milis).ToString ("000");;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}