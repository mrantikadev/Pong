using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float speed = 30f;
    Rigidbody2D rb;

    [SerializeField] bool isPlayer1;
    private float movement;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {
        if (isPlayer1) {
            movement = Input.GetAxisRaw("Vertical");
        }
        else {
            movement = Input.GetAxisRaw("Vertical2");
        }

        rb.velocity = new Vector2(0, movement * speed * Time.deltaTime);
    }
}
