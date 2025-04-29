using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float jumpForce = 12f;
    Rigidbody2D rb;

    void Awake() => rb = GetComponent<Rigidbody2D>();

    void Update()
    {
        if (GameManager.State != GameState.Playing) return;

        bool jumpPressed = Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space);
        if (jumpPressed)
            rb.linearVelocity = Vector2.up * jumpForce;
    }

    void OnCollisionEnter2D(Collision2D _) => GameManager.I.GameOver();
}
