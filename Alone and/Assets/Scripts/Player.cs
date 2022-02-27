using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    public float speed;
    public float jumpspeed;
    private float gravity=-9.81f;
    public Transform Groundpos;
    public LayerMask GroundLayer;
    public GameObject warningimg;
    public GameObject alertimg;
    public CharacterController controller;
    private float GroundSphereRadius = 0.1f;
    public bool isGrounded;
    Vector3 Velocity;

    public HealthStats healthstats;
    public GameObject walking;
    public walkeffect audiocon;
    public Joystick js;
    private float X;
    private float Y;
    private float Z;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.enabled = true;
       
        Loader();
    }

    // Update is called once per frame
    void Update()
    {
        Saver();
        mobinput();
        // player Groundcheck
        isGrounded = Physics.CheckSphere(Groundpos.position, GroundSphereRadius, GroundLayer);

        Velocity.y += gravity * Time.deltaTime;  // applying gravity
        if (isGrounded && Velocity.y <= 0)
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                Velocity.y = jumpspeed;
            }
        }
     
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * x + transform.forward * y;

        if (direction.magnitude >= 0.1f)
        {
            // Player movement        
            controller.Move(direction * Time.deltaTime * speed);
            // Sprint speed
            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.Move(direction * Time.deltaTime * speed * 1.5f);
            }
        }


        
        controller.Move(Velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("wz"))
        {
            warningimg.SetActive(true);
            healthstats.health -= 4;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            alertimg.SetActive(true);

        }

       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("wz"))
        {
            warningimg.SetActive(false);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            alertimg.SetActive(false);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("underground"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void mobinput()
    {
        float hor = js.Horizontal;
        float ver = js.Vertical;
        Vector3 direction = transform.right * hor + transform.forward * ver;

        if (direction.magnitude >= 0.1f)
        {
            walking.SetActive(true);
            audiocon.walking.pitch = 1f;
            controller.Move(direction * Time.deltaTime * speed);
            // Sprint speed
            if (js.Vertical >= 0.99) 
            {
                audiocon.walking.pitch = 1.5f;
                controller.Move(direction * Time.deltaTime * speed * 0.8f);
            }

            else if (js.Vertical <= -0.99)
            {
                audiocon.walking.pitch = 1.5f;
                controller.Move(direction * Time.deltaTime * speed * 0.7f);
            }
        }
        else
        {
            walking.SetActive(false);
        }
        controller.Move(Velocity * Time.deltaTime);
    }

    public void jump()
    {
        if (isGrounded && Velocity.y <= 0)
        {
            Velocity.y = jumpspeed;
        }
            
    }

    void Saver()      ///////    Save [ Position, Sliders ]
    {
        X = transform.position.x;
        Y = transform.position.y;
        Z = transform.position.z;

        PlayerPrefs.SetFloat("x", X);
        PlayerPrefs.SetFloat("y", Y);
        PlayerPrefs.SetFloat("z", Z);
    }

    void Loader()
    {
        if (PlayerPrefs.HasKey("x"))
        {
            X = PlayerPrefs.GetFloat("x");
            Y = PlayerPrefs.GetFloat("y");
            Z = PlayerPrefs.GetFloat("z");
        }
        else
        {
            X = 10.100f;
            Y = -1;
            Z = 14.900f;
        }
            Vector3 LoadPos = new Vector3(X, Y, Z);
            transform.position = LoadPos;
    
    }
    
}
