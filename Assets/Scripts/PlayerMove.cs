using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {
    public float Speed = 1.0f;
    public float Distance = .01f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Animator animate = GetComponent<Animator>();
        int velocity;
        Vector2 beforePos;
        if (Input.GetMouseButtonDown(0))
        {
            Speed -= .05f;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed += .05f;
            Distance += .01f;
            GetComponent<Animator>().speed += .5f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            beforePos = transform.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, Distance, 1 << 8);
            GetComponent<Animator>().SetBool("WalkingLeft", true);
            if (hit.collider == null)
            {
                GetComponent<Transform>().position = new Vector2(transform.position.x - Speed, transform.position.y);
            }

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("WalkingLeft", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, Distance, 1 << 8);
            animate.SetBool("WalkingRight", true);
            if (hit.collider == null)
            {
                GetComponent<Transform>().position = new Vector2(transform.position.x + Speed, transform.position.y);
            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animate.SetBool("WalkingRight", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Distance, 1 << 8);
            animate.SetBool("WalkingDown", true);
            if (hit.collider == null)
            {
                GetComponent<Transform>().position = new Vector2(transform.position.x, transform.position.y - Speed);
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animate.SetBool("WalkingDown", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, Distance, 1 << 8);
            animate.SetBool("WalkingUp", true);
            if (Input.GetMouseButton(0))
            {
                animate.SetBool("Attack", true);
            }
            if (hit.collider == null)
            {
                GetComponent<Transform>().position = new Vector2(transform.position.x, transform.position.y + Speed);
            }
            }
        if (Input.GetKeyUp(KeyCode.W))
        {
            animate.SetBool("WalkingUp", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed -= .05f;
            Distance -= .0f;
            GetComponent<Animator>().speed -= .5f;
        }
        if (Input.GetMouseButtonUp(0))
        {
            Speed += .05f;
            animate.SetBool("Attack", false);
        }
    }
}

