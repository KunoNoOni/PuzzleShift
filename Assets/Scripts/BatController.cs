using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BatController : MonoBehaviour 
{
    public float moveSpeed;
    public GameObject magicSpell; 
    public Slider stamina;

    private Rigidbody2D bat;
    private float moveVelocityH;
    private float moveVelocityV;
    private LevelManager levelManager;
    private float staminaCooldown = .5f;

    void Start () 
    {
        bat = GetComponent<Rigidbody2D>();
        levelManager = FindObjectOfType<LevelManager>();
        stamina = FindObjectOfType<Slider>();
    }

    void Update () 
    {
        moveVelocityH = moveSpeed * Input.GetAxisRaw("Horizontal");
        moveVelocityV = moveSpeed * Input.GetAxisRaw("Vertical");

        bat.velocity = new Vector2(moveVelocityH, moveVelocityV);

        if(Input.GetButtonDown("Fire3") && LevelManager.hasMouse)
        {
            //Debug.Log("Changing into a mouse");
            Instantiate(magicSpell, this.transform.position, this.transform.rotation);
            levelManager.mousePlayer.SetActive(true);
            levelManager.mousePlayer.transform.position = new Vector3(levelManager.batPlayer.transform.position.x,
                levelManager.batPlayer.transform.position.y,
                levelManager.batPlayer.transform.position.z);
            levelManager.batPlayer.SetActive(false);
            levelManager.player.SetActive(false);
        }

        if(Input.GetButtonDown("Jump") && LevelManager.hasBat)
        {
            //Debug.Log("Changing into a human");
            Instantiate(magicSpell, this.transform.position, this.transform.rotation);
            levelManager.player.SetActive(true);
            levelManager.player.transform.position = new Vector3(levelManager.batPlayer.transform.position.x,
                levelManager.batPlayer.transform.position.y,
                levelManager.batPlayer.transform.position.z);
            levelManager.batPlayer.SetActive(false);
            levelManager.mousePlayer.SetActive(false);

        }

        staminaCooldown -= Time.deltaTime;
        if(staminaCooldown < 0)
        {
            staminaCooldown = .5f;
            stamina.value += 1f;
            if(stamina.value == 5)
            {
                //Debug.Log("Changing into a human");
                Instantiate(magicSpell, this.transform.position, this.transform.rotation);
                levelManager.player.SetActive(true);
                levelManager.player.transform.position = new Vector3(levelManager.batPlayer.transform.position.x,
                    levelManager.batPlayer.transform.position.y,
                    levelManager.batPlayer.transform.position.z);
                levelManager.batPlayer.SetActive(false);
                levelManager.mousePlayer.SetActive(false);
            }
        }
            
    }
}

