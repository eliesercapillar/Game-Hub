using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        private AudioSource footsteps;

        private Animator animator;
        private Transform playerTransform;
        private Camera cam;

        private bool canMove = true;

        private void Start()
        {
            animator = GetComponent<Animator>();
            footsteps = this.GetComponent<AudioSource>();
            playerTransform = GetComponent<Transform>();
            cam = Camera.main;
            if (DataPersistency.hasStoredPlayerCoords())
            {
                float[] coords = DataPersistency.getPlayerCoords();
                playerTransform.position = new Vector3(coords[0], coords[1], 0);
            }
        }

        private void Update()
        {
            if (canMove)
            {
                Vector2 dir = Vector2.zero;
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                {
                    dir.x = -1;
                    animator.SetInteger("Direction", 3);
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                {
                    dir.x = 1;
                    animator.SetInteger("Direction", 2);        
                }

                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    dir.y = 1;
                    animator.SetInteger("Direction", 1);
                }
                else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                {
                    dir.y = -1;
                    animator.SetInteger("Direction", 0);
                }

                dir.Normalize();

                GetComponent<Rigidbody2D>().velocity = speed * dir;
                animator.SetBool("isMoving", (dir.magnitude > 0));

                if (dir.magnitude > 0 && !footsteps.isPlaying)
                {
                    footsteps.Play();
                }
            }
        }

        public void recordPlayerCoords()
        {
            Vector3 playerPos = playerTransform.position;
            Vector3 cameraPos = cam.GetComponent<Transform>().position;

            DataPersistency.setPlayerCoords(playerPos.x, playerPos.y);
            DataPersistency.setCameraCoords(cameraPos.x, cameraPos.y);
        }

        public void isMovable(bool b)
        {
            canMove = b;
        }
    }
}
