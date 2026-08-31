using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float rotationSpeed = 10f;
    private Vector2 moveInput;
    private bool jumpInput;
    private Rigidbody rig;
    [SerializeField]
    private Animator anim;
    private int score;
    [SerializeField]
    private TMP_Text scoreText;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip jumpSound;

    [SerializeField]
    private AudioClip scoreSound;

    void Start()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Physics code will go here.
        Vector3 velocity = new Vector3(moveInput.x, 0, moveInput.y) * moveSpeed;


        if (jumpInput && IsGrounded())
        {
            jumpInput = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            audioSource.PlayOneShot(jumpSound);
        }

        jumpInput = false;
        velocity.y = rig.linearVelocity.y;

        rig.linearVelocity = velocity;

        // Update the animation state.
        anim.SetBool("Moving", moveInput.magnitude > 0);
        anim.SetBool("InAir", !IsGrounded());

        // Game over if the player falls off.
        if (transform.position.y < -10)
        {
            GameOver();
        }

    }
    void Update()
    {
        if (moveInput.magnitude == 0)
            return;

        float targetAngle = Mathf.Atan2(moveInput.x, moveInput.y) * Mathf.Rad2Deg;
        float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, Time.deltaTime * rotationSpeed);
        transform.eulerAngles = new Vector3(0, angle, 0);
    }

    bool IsGrounded()
    {
        if (Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), Vector3.down, 0.2f))
        {
            return true;
        }

        return false;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        jumpInput = context.ReadValueAsButton();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
        audioSource.PlayOneShot(scoreSound);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
