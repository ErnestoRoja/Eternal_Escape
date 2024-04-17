using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TestCharController : MonoBehaviour
{
    public float horizontalMovementSpeed = 5f;
    public float initialMovementSpeed = 10f;
    private float distanceTraveled = 0f;
    private float currentMovementSpeed;
    private bool isPlayerAlive = true;
    public float jumpForce = 10f;
    private bool isGrounded = true;
    public SpawnManager spawnManager;
    public Animator playerAnim;
    public Rigidbody rigidBody;
    public GameObject gameOverMenu;
    AudioManager audioManager;

    private PlayerRagdoll playerRagdoll;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        playerRagdoll = GetComponent<PlayerRagdoll>();
    }

    // Update is called once per frame
    void Update()
    {

        float hMovement = Input.GetAxis("Horizontal") * horizontalMovementSpeed;
        distanceTraveled += currentMovementSpeed * Time.deltaTime;
        currentMovementSpeed = initialMovementSpeed + (distanceTraveled * 0.01f);

        transform.Translate(new Vector3(hMovement, 0, currentMovementSpeed) * Time.deltaTime);
        playerAnim.SetTrigger("walk");

        if (rigidBody.velocity.y == 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded= false;
             
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) 
        {
            rigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            audioManager.PlaySFX(audioManager.jump);
            isGrounded = false;
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.transform.tag == "SpawnTrigger")
        {
            spawnManager.SpawnTriggerEntered();
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.tag == "Obstacle" && isPlayerAlive)
        {
            audioManager.PlaySFX(audioManager.death);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            playerRagdoll.SetRagdollState(true);

            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().SetPlayerAlive(false);

            StartCoroutine(WaitAndRestart(0.01f));
        }
    }

    private IEnumerator WaitAndRestart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        gameOverMenu.SetActive(true);
    }
}
