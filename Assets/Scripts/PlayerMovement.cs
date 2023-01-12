using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalMod = 1;
    public float verticalMod = 1;

    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // Make Player move (bonjour?)
        rb.velocity = new Vector2(horizontalInput * horizontalMod, verticalInput * verticalMod);
    }
}
