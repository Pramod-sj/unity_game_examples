using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour {
    Rigidbody ball;
    public Text scoreText;
    public Text winText;
    private int score;
    // Use this for initialization
    void Start () {
        ball = GetComponent<Rigidbody>();
        score = 0;
        winText.text = "";
        setScore();
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Debug.Log(moveVertical);
        Debug.Log(moveHorizontal);
        Vector3 movement = new Vector3(moveHorizontal,ball.transform.position.y,moveVertical);
        ball.AddForce(movement*10);

        if (Input.GetButtonDown("Jump"))
        {
            ball.AddForce(-ball.velocity);
            ball.velocity=Vector3.zero*Time.deltaTime;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {

            collision.gameObject.SetActive(false);
            score++;
            setScore();
            if (score ==10)
            {
                winText.text = "You won!";
                ball.constraints = RigidbodyConstraints.FreezeAll;
            }
        }

    }


    public void setScore()
    {
        scoreText.text = "Score:" + score;
    }

}
