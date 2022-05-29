using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] AudioClip hitSound;
    [SerializeField] int pointsForEnemy = -10;

    public bool wasCollected = false;
    private bool wasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    //private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !wasCollected)
        {
            Debug.Log("bat bat" + gameObject.name);
            if (gameObject.name.StartsWith("Bat"))
            {
                wasTriggered = true;
            }

            if (wasTriggered)
            {
                wasCollected = true;
                AudioSource.PlayClipAtPoint(hitSound, Camera.main.transform.position);
                Player._instance.playerScore += pointsForEnemy;
                Player._instance.UpdateUI();
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

}
