using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite handCursor;
    public Sprite normalCursor;

    public GameObject clickEffect;
    public GameObject trailEffect;
    public float timeBtwnSpawn = 0.1f;

    void Start(){
        Cursor.visible = false;
        rend = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//stores cursor position
        transform.position = cursorPos; //sprite set to cursorPos

        if(Input.GetMouseButtonDown(0)){
            //rend.sprite = handCursor;
            Instantiate(clickEffect, transform.position, Quaternion.identity);//instantiate clickEffect whenever left mouse button is clicked
        }
        else if(Input.GetMouseButtonUp(0)){
            //rend.sprite = normalCursor;
        }
        if(timeBtwnSpawn <= 0){
            Instantiate(trailEffect, cursorPos, Quaternion.identity);
            timeBtwnSpawn = 0.1f;
        }
        else{
            timeBtwnSpawn -= Time.deltaTime;
        }
    }
}
