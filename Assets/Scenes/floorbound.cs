using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class floorbound : MonoBehaviour
{

    private List<GameObject> baskets;
    public GameObject basketPrefab;

    // Start is called before the first frame update
    void Start()
    {
        float bottomEdge = transform.position.y + 0.9f;
        baskets = new List<GameObject>();

        for (int i = 0; i < 3; i++){
            GameObject basket = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = basket.transform.position;
            pos.y = bottomEdge + (i * 0.32f);
            basket.transform.position = pos;
            baskets.Add(basket);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if baskets == 0, make the game stop
        if (baskets.Count == 0)
            SceneManager.LoadScene("EndGameMenu", LoadSceneMode.Single);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.gameObject.tag == "apple"){
            int top = baskets.Count - 1;

            if(top > -1){
                Destroy(baskets[top]);
                baskets.RemoveAt(top);
            }
        }

        GameObject [] appleArr = GameObject.FindGameObjectsWithTag("apple");
        
        foreach (GameObject apple in appleArr){
            Destroy(apple);
        }

        Tree.appleIncrement = 1.0f;


    }
}
