using UnityEngine;

public class PlayerRagdoll : MonoBehaviour
{
    private Collider[] colliders;
    private Rigidbody[] rigidbodies;

    private Rigidbody charRigidBody;
    private Collider charCollider;
    private Animator charAnimator;
    private TestCharController charController;
    [SerializeField] ParticleSystem charParticles;

    public GameObject ragdollRootObj;

    // Start is called before the first frame update
    void Start()
    {
        charRigidBody = GetComponent<Rigidbody>();
        charCollider = GetComponent<CapsuleCollider>();
        charAnimator = GetComponent<Animator>();
        charController = GetComponent<TestCharController>();
        // charParticles.Play();

        colliders = ragdollRootObj.GetComponentsInChildren<Collider>();
        rigidbodies = ragdollRootObj.GetComponentsInChildren<Rigidbody>();

        SetRagdollState(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRagdollState(bool state)
    {
        charRigidBody.isKinematic = state;
        charCollider.enabled = !state;
        charAnimator.enabled = !state;
        charController.enabled = !state;
        
        if (state)
            charParticles.Stop();
        else
            charParticles.Play();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = !state;
        }
    }
}
