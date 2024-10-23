using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 dir;
    [SerializeField] private int speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;

    private int linetoMove = 1;
    public float lineDistance = 4;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        if (SwipeController.swipeRight)
        {
            if (linetoMove < 2)
            {
                linetoMove++;
            }
        }
        if (SwipeController.swipeLeft)
        {
            if (linetoMove > 0)
            {
                linetoMove--;
            }
        }

        if (SwipeController.swipeUp)
        {
            if(characterController.isGrounded)
                Jump();
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if(linetoMove == 0)
        {
            targetPosition += Vector3.left * lineDistance;
        }
        else if(linetoMove == 2)
        {
            targetPosition += Vector3.right * lineDistance;
        }
        transform.position = targetPosition;

    }

    private void Jump()
    {
        dir.y = jumpForce;
        
    }
    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        characterController.Move(dir * Time.fixedDeltaTime);
    }
}
