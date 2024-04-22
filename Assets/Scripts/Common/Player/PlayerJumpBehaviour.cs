using UnityEngine;

namespace Common.Player
{
    public class PlayerJumpBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;

        private const string GroundTag = "Ground";

        private float jumpForce;
        private float doubleJumpForce;

        private bool isGrounded;
        private bool canDoubleJump;

        void Start()
        {
            jumpForce = SceneContext.I.Config.JumpForce;
            doubleJumpForce = SceneContext.I.Config.DoubleJumpForce;
        }

        public void TryJump()
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (canDoubleJump)
            {
                DoubleJump();
            }
        }

        private void Jump()
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpForce, rigidbody.velocity.z);
            canDoubleJump = true;
            isGrounded = false;
        }

        private void DoubleJump()
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, doubleJumpForce, rigidbody.velocity.z);
            canDoubleJump = false;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(GroundTag))
            {
                isGrounded = true;
                canDoubleJump = false;
            }
        }
    }
}