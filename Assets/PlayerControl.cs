using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D myRb;
    public float grav, mass;
    public enum TouchingState { Links, Luft, Rechts }
    public float pushX, pushY;

    private TouchingState _state;

    // Use this for initialization
    void Start()
    {
        myRb = gameObject.GetComponent<Rigidbody2D>();
        myRb.gravityScale = grav;
        myRb.mass = mass;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_state == TouchingState.Links)
            {
                myRb.velocity = new Vector2(pushX, pushY);
            }

            if (_state == TouchingState.Rechts)
            {
                myRb.velocity = new Vector2(-pushX, pushY);
            }

            if (_state == TouchingState.Luft)
            {
                Debug.Log("Geht Nicht");
            }
            Debug.Log("ist gedrückt");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LW"))
        {
            _state = TouchingState.Links;
            Debug.Log("Links berührt");
        }
        if (col.CompareTag("RW"))
        {
            _state = TouchingState.Rechts;
            Debug.Log("Rechts berührt");
        }
        if (col.CompareTag("Ground"))
        {
            myRb.velocity = new Vector2(0, pushY);
            Debug.Log("U DED");
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (!col.CompareTag("Ground"))
            _state = TouchingState.Luft;
        Debug.Log("Wieder in der luft");
    }
}
