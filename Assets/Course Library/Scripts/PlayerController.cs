using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 private Rigidbody playerRb;
 public float jumpForce;
 public float gravityModifier;
 public bool isOnGround = true;
 public bool gameOver;
 private Animator playerAnim;
 public ParticleSystem dirtParticle;
 public ParticleSystem explosionParticle;
 public AudioClip crashSound; 
 public AudioClip jumpSound;
 private AudioSource playerAudio;

public bool canDoubleJump;
public float doubleJumpForce;

public bool superSpeed;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

       

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) 
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false; 
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            canDoubleJump = true;  
         }else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && !gameOver && canDoubleJump) 
         {
            playerRb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.0f);

         }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            superSpeed = true;
        
        }else 
        {
            superSpeed = false;

        }


        
        
    }
   private void OnCollisionEnter(Collision other)
    {
     if (other.gameObject.CompareTag("Ground"))
		{
			isOnGround = true;
			dirtParticle.Play();
		}  
        if (other.gameObject.CompareTag("Obstacle"))
		{
			gameOver = true; 
			Debug.Log("Game Over!");
			playerAnim.SetBool("Death_b", true);
			playerAnim.SetInteger("DeathType_int", 1);
			explosionParticle.Play();
			playerAudio.PlayOneShot(crashSound, 0.8f);
  
    }
  }
}
