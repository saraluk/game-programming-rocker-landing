using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour
{
    public LayerMask platform;
    public LayerMask landscape;
    Rigidbody2D rb;
    Vector2 force;
    public Text fuelText;
    double fuel = 5.0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        force = Vector2.zero;
        if (fuel > 0.0)
        {
            fuelText.text = fuel.ToString("0.0");

            if (Input.GetKey(KeyCode.A))
            {
                force.x = 1;
                fuel -= Time.deltaTime;
            } 
            else if (Input.GetKey(KeyCode.D))
            {
                force.x = -1;
                fuel -= Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                force.y = 1;
                fuel -= Time.deltaTime;
            }
        }

        Vector2 bottom = new Vector2(transform.position.x, transform.position.y - 0.2f);
        Vector2 dimensions = new Vector2(1.0f, 0.2f);
        bool onPlatform = Physics2D.OverlapBox(bottom, dimensions, 0, platform);
        bool onLandscape = Physics2D.OverlapBox(bottom, dimensions, 0, landscape);
    
        if (onPlatform)
        {
            Debug.Log("on platform");
            GameData.result = "Successful Landing !";
            SceneManager.LoadScene("GameOverScene");

        }
        if (onLandscape)
        {
            Debug.Log("Not on platform");
            GameData.result = "Failed Landing !";
            SceneManager.LoadScene("GameOverScene");
        }
    
    }

    private void FixedUpdate()
    {
        rb.AddForce(force);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -2, 2), Mathf.Clamp(rb.velocity.y, -1, 1));
    }
}
