using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerStatsConfig playerStats;

    private float horizontalInput;
    private float vertivalInput;
    private Rigidbody2D playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        vertivalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 force = new Vector2(horizontalInput, vertivalInput).normalized * playerStats.Speed * Time.fixedDeltaTime;
        playerRigidbody.velocity = force;
    }
}
