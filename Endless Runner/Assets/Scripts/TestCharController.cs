using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TestCharController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float horizontalMovementSpeed = 5f;
    public float jumpForce = 10f;
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
        //float vMovement = Input.GetAxis("Vertical") * movementSpeed;

        transform.Translate(new Vector3(hMovement, 0, movementSpeed) * Time.deltaTime);
        playerAnim.SetTrigger("walk");

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            rigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            audioManager.PlaySFX(audioManager.jump);
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
        if (collision.gameObject.tag == "Obstacle")
        {
            audioManager.PlaySFX(audioManager.death);
            // gameObject.GetComponent<Rigidbody>().isKinematic = true;
            // gameObject.GetComponent<TestCharController>().movementSpeed = 0f;
            // gameObject.GetComponent<TestCharController>().horizontalMovementSpeed = 0f;

            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            playerRagdoll.SetRagdollState(true);

            StartCoroutine(WaitAndRestart(0.01f));
        }
    }

    private IEnumerator WaitAndRestart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        gameOverMenu.SetActive(true);
    }
}
