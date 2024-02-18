using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float jumpForce = 1f;
    public float trampF = 2f;
    private Rigidbody2D r2d;

    public GameObject scriptOb;
    public GameObject nextLvl;
    [SerializeField] private ParticleSystem ps;
    fade fade;
 
    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        fade = scriptOb.GetComponent<fade>();
        nextLvl.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = Input.GetAxis("Horizontal");
        if(fade.isMemo) {
            r2d.velocity = new Vector2(direction * movementSpeed, r2d.velocity.y);
            
            if(Input.GetKeyDown(KeyCode.UpArrow) && Mathf.Abs(r2d.velocity.y) < 0.1) {
                r2d.velocity = new Vector2(r2d.velocity.x, jumpForce);
                Debug.Log(ps.isPlaying);
                ps.Play();
                Debug.Log(ps.isPlaying);
            }
            if(direction < 0f) {
                transform.localScale = new Vector2(-7f, 7f);
            } else {
                transform.localScale = new Vector2(7f, 7f);
            }
        }
        if(transform.position.x < -7.4) {
            transform.position = new Vector3(-7.4f, transform.position.y, transform.position.z);
        } else if(transform.position.x > 7.4) {
            transform.position = new Vector3(7.4f, transform.position.y, transform.position.z);
        } else if(transform.position.y > 4.44) {
            transform.position = new Vector3(transform.position.x, 4.44f, transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.Q)) {
            Application.Quit();
        }
     }
     void OnTriggerEnter2D(Collider2D col) {
         if(col.tag == "Hurts") {
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
         } else if (col.tag == "tramp") {
             r2d.velocity =  new Vector2(r2d.velocity.x, trampF*jumpForce);
         } else if(col.tag == "Portal") {
            if(SceneManager.GetActiveScene().name == "Tutorial Level 3") {
                SceneManager.LoadScene("Congrats");
            } else {
                nextLvl.SetActive(true);
            }

         }
     }

}
