using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 400f;
    Vector3 LastVelocity;
    // Start is called before the first frame update
    void Start()
    {
	rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(20 * Time.deltaTime * speed, 20 * Time.deltaTime * speed));
    }

    // Update is called once per frame
    void Update()
    {
        LastVelocity = rb.velocity;
    }
    private void OnCollisionEnter2D(Collision2D collision) {
	    var speed = LastVelocity.magnitude;
	    var direction = Vector3.Reflect(LastVelocity.normalized, collision.contacts[0].normal);
	    rb.velocity = direction * Mathf.Max(speed, 0f);
	    if (collision.gameObject.tag == "Player") {
            speed += 10f;
	    }
    }
}
