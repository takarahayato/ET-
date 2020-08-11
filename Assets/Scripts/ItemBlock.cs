using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlock : MonoBehaviour
{
    public GroundCheck hatena;

    private bool isHatena = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isHatena = hatena.IsGround();

        if (isHatena)
        {
            Debug.Log("block!!!!");
        }
        
    }
}
