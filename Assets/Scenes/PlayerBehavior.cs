using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    private float b;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if(Time.timeScale != 0){
            Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            newPos.z = transform.position.z;
            newPos.y = transform.position.y;

            transform.position = newPos;
        }

        // b = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x;

        // if(newPos.x >= (0 - b) && newPos.x <= b){
        //     transform.position = newPos;
        // }
    }
    
    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "apple"){
            Destroy(collision.gameObject);
            GameObject.Find("Tree").GetComponent<Tree>().IncrementScore();
        }
    }
}