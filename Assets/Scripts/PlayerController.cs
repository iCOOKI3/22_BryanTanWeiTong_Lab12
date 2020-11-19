using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public GameObject Coin;
    public GameObject CoinCollected;

    private int coinCount; //total number of coin collected
    private int totalCoin; //total number of coin in scene

    float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        totalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        //Forward
        if(Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        //Backward
        if (Input.GetKey(KeyCode.DownArrow)||Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        //Left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        //Right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        //Winning Condition
        if(coinCount == totalCoin)
        {
            print("You Win!");
            SceneManager.LoadScene("WinScene");
        }

        //Losing Condition
        if (transform.position.y < -5)
        {
            print("You Lose!");
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            coinCount++; //+1 to coinCount variable

            CoinCollected.GetComponent<Text>().text = "Coin Collected: " + coinCount; //GetComponent of Text and set text with String and Variable

            Destroy(other.gameObject); //Destroy the triggered coin object
        }
    }
}
