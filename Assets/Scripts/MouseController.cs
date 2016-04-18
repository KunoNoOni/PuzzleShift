using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MouseController : MonoBehaviour 
{
    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask theGround;
    public GameObject magicSpell;
    public Slider stamina;
    public float staminaCooldownRefresh = 2f;

    private bool grounded;
    private Rigidbody2D mouse;
    private Animator anim;
    private float moveVelocity;
    private LevelManager levelManager;
    private float staminaCooldown;
    private AudioSource asourceJump;

    void Start () 
    {
        mouse = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        levelManager = FindObjectOfType<LevelManager>();
        stamina = FindObjectOfType<Slider>();
        asourceJump = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius, theGround);
    }

    void Update () 
    {
        anim.SetBool("grounded",grounded);

        if(Input.GetButtonDown("Fire1") && grounded)
        {
            asourceJump.Play();
            mouse.velocity = new Vector2(mouse.velocity.x,jumpHeight);
        }

        moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");

        mouse.velocity = new Vector2(moveVelocity, mouse.velocity.y);

        anim.SetFloat("speed", Mathf.Abs(mouse.velocity.x));

        if(mouse.velocity.x > 0)
            transform.localScale = new Vector3(1f,1f,1f);
        else if (mouse.velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

        if(Input.GetButtonDown("Fire3") && LevelManager.hasMouse)
        {
            //Debug.Log("Changing into a human");
            Instantiate(magicSpell, this.transform.position, this.transform.rotation);
            levelManager.player.SetActive(true);
            levelManager.player.transform.position = new Vector3(levelManager.mousePlayer.transform.position.x,
                levelManager.mousePlayer.transform.position.y,
                levelManager.mousePlayer.transform.position.z);
            levelManager.mousePlayer.SetActive(false);
            levelManager.batPlayer.SetActive(false);

        }

        if(Input.GetButtonDown("Jump") && LevelManager.hasBat)
        {
            //Debug.Log("Changing into a bat");
            Instantiate(magicSpell, this.transform.position, this.transform.rotation);
            levelManager.batPlayer.SetActive(true);
            levelManager.batPlayer.transform.position = new Vector3(levelManager.mousePlayer.transform.position.x,
                levelManager.mousePlayer.transform.position.y,
                levelManager.mousePlayer.transform.position.z);
            levelManager.mousePlayer.SetActive(false);
            levelManager.player.SetActive(false);

        }

        if(stamina.gameObject.activeSelf)
        {
            if(stamina.value > 0)
            {
                staminaCooldown -= Time.deltaTime;
                if(staminaCooldown < 0)
                {
                    staminaCooldown = staminaCooldownRefresh;
                    stamina.value -= .5f;
                }
            }
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "MovingPlatform")   
        {
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.transform.tag == "MovingPlatform")   
        {
            transform.parent = null;
        }
    }
}
