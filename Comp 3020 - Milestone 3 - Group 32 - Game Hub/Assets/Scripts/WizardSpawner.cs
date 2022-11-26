using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WizardSpawner : MonoBehaviour
{
    private DialogueManager dm;
    private Transform player;

    [SerializeField] private GameObject wizard;

    private void Awake()
    {
        dm = GameObject.Find("Dialogue Manager").GetComponent<DialogueManager>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    public void attemptSpawn()
    {
        calculateSpawnableTile();
    }

    private void calculateSpawnableTile()
    {
        Vector3 playerPos = player.position;
        Vector2 playerPos2D = new Vector2(playerPos.x, playerPos.y);
        Vector3 playerDown = new Vector3(playerPos.x, playerPos.y - 1, 0);

        bool downSpawnable = true;
        bool leftSpawnable = true;
        bool rightSpawnable = true;
        bool southEastSpawnable = true;
        bool southWestSpawnable = true;

        RaycastHit2D hit = Physics2D.Raycast(playerPos2D, Vector2.down, 2f);
        if (hit.collider != null && hit.collider.tag != "Player")
        {
            Debug.Log("down is unspawnable." + hit.collider);
            downSpawnable = false;
        }

        hit = Physics2D.Raycast(playerPos2D, Vector2.left, 2f);
        if (hit.collider != null && hit.collider.tag != "Player")
        {
            Debug.Log("left is unspawnable." + hit.collider);
            leftSpawnable = false;
        }

        hit = Physics2D.Raycast(playerPos2D, Vector2.right, 2f);
        if (hit.collider != null && hit.collider.tag != "Player")
        {
            Debug.Log("right is unspawnable." + hit.collider);
            rightSpawnable = false;
        }

        Vector2 se = new Vector2(-1, -1);
        hit = Physics2D.Raycast(playerPos2D, se, 2f);
        if (hit.collider != null && hit.collider.tag != "Player")
        {
            Debug.Log("se is unspawnable." + hit.collider);
            southEastSpawnable = false;
        }

        Vector2 sw = new Vector2(1, -1);
        hit = Physics2D.Raycast(playerPos2D, sw, 2f);
        if (hit.collider != null && hit.collider.tag != "Player")
        {
            Debug.Log("sw is unspawnable." + hit.collider);
            southWestSpawnable = false;
        }

        if ((!leftSpawnable && !southEastSpawnable) || (!rightSpawnable && !southWestSpawnable))
        {
            downSpawnable = false;
        }

        if (downSpawnable)
        {
            Debug.Log("Spawning down.");
            spawnWizard(playerDown);
        }
        else
        {
            dm.showDialogue(1);
        }
    }

    private void spawnWizard(Vector3 spawnCoords)
    {
        Instantiate(wizard, spawnCoords, Quaternion.identity);
        //player.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //player.gameObject.GetComponent<Cainos.PixelArtTopDown_Basic.TopDownCharacterController>().setMoveAnim(false);
    }
}
