using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    Rigidbody2D player;
    public float speed = 1f;
    private int count;
    public Text countText;
    public Text winText;
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        setCountText();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        player.AddForce(movement*speed);
        if (count == 8)
        {
            winText.text = "You won!";
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            collision.gameObject.SetActive(false);
            count++;
            setCountText();
        }
    }

    public void setCountText()
    {
        countText.text = "Score:" + count.ToString();
    }
}
