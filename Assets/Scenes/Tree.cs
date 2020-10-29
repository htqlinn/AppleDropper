using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tree : MonoBehaviour
{
    public float treeSpeed = 2.0f;
    public GameObject apple;
    public int score;
    public static float appleIncrement = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
        InvokeRepeating("speedUp", 5f, Random.Range(3f,7f));
        InvokeRepeating("switchDir", 10f, Random.Range(3f,8f));

    }

    void DropApple(){
        GameObject fruit = Instantiate<GameObject>(apple);
        fruit.transform.position = new Vector2(transform.position.x, transform.position.y - 0.3f);

        if(appleIncrement > 0.3f) appleIncrement -= 0.05f;
        Invoke("DropApple", appleIncrement);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(treeSpeed * Time.deltaTime, 0, 0);
        if (treeSpeed > 6 || treeSpeed < -6) treeSpeed = Random.Range(2.0f, 3.5f);

    }

    public void speedUp(){
        treeSpeed *= 1.3f;
    }

    public void switchDir(){
        treeSpeed *= -1.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "apple"){}
        else treeSpeed *= -1.0f;
    }

    public void IncrementScore(){
        score += 50;
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Score: " + score.ToString();
    }
}

