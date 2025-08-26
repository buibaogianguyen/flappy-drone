using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D myBody;
    [SerializeField] private Animator jumpAnim;
    private Vector3 direction;
    public float Gravity = 0f;
    public float jumpForce = 7f;
    [SerializeField] private string groundTouch;
    [SerializeField] private string droneJump;
    [SerializeField] private bool isJumping;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        jumpAnim = GetComponent<Animator>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            myBody.velocity = Vector3.zero;
            myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
            JumpAnim();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

    public void JumpAnim()
    {
        if (isJumping == true)
        {
            jumpAnim.SetTrigger("droneJump");
        }

    }
}


