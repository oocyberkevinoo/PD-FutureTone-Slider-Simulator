using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor : MonoBehaviour
{


    public bool state = false;
    public KeyCode key;

    private Collider2D col;
    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        state = Input.GetKey(key);

        if (state)
        {
            spr.color = Color.green;
        }
        else
        {
            spr.color = Color.white;
        }
    }


}
