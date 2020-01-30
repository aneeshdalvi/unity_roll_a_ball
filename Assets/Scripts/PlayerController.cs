using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private int score;
    public Text scoreText;
    public Text winText;
    public Text nameText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetCountText();
        winText.text = "";
        nameText.text = "Aneesh Dalvi";
    }

    void FixedUpdate()
    {
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVerti = Input.GetAxis("Vertical");

        Vector3 motion = new Vector3(moveHoriz, 0.0f, moveVerti);

        rb.AddForce(motion * speed);
    }

    void OnTriggerEnter(Collider rotator)
    {
        if (rotator.gameObject.CompareTag("Pick Up"))
        {
            rotator.gameObject.SetActive(false);
            score = score + 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        scoreText.text = "Count: " + score.ToString();
        if (score >= 9)
        {
            winText.text = "You Win!";
        }
    }
}
