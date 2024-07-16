using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMoveController : MonoBehaviour, ICanPause
{
    [SerializeField] private PlayerStatsConfig playerStats;

    private float horizontalInput;
    private float vertivalInput;
    private Rigidbody2D playerRigidbody;
    private Animator animator;

    private enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        Stop
    }

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ((ICanPause)this).SubscribeToPause();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        vertivalInput = Input.GetAxis("Vertical");

        ChangeDirection();
    }

    private void ChangeDirection()
    {
        if (horizontalInput == 0 && vertivalInput == 0)
        {
            animator.speed = 0;
            return;
        }

        animator.speed = 1;
        animator.SetFloat("horizontal", horizontalInput);
        animator.SetFloat("vertical", vertivalInput);
    }

    private void FixedUpdate()
    {
        Vector2 force = new Vector2(horizontalInput, vertivalInput).normalized * playerStats.Speed * Time.fixedDeltaTime;
        playerRigidbody.velocity = force;
    }

    public void Pause()
    {
        animator.enabled = false;
        playerRigidbody.Sleep();
        enabled = false;
    }

    private void OnDestroy()
    {
        ((ICanPause)this).Unsubscribe();
    }
}