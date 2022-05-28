using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Pickups : MonoBehaviour
{
    [SerializeField] AudioClip pickupSound;
    [SerializeField] int pointsForPickup = 10;
    [SerializeField] TextMeshProUGUI youWinText;


    public bool wasCollected = false;
    private bool wasTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
   //private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !wasCollected)
        {
            Debug.Log("door" + gameObject.name);
            if (gameObject.name.StartsWith("keyB"))
            {
                wasTriggered = true;
                Player._instance.blueKeys++;
            }
            else if (gameObject.name.StartsWith("keyY"))
            {
                wasTriggered = true;
                Player._instance.yellowKeys++;
            }
            else if (gameObject.name.StartsWith("keyG"))
            {
                wasTriggered = true;
                Player._instance.greenKeys++;
            }
            else if (gameObject.name.StartsWith("keyR"))
            {
                wasTriggered = true;
                Player._instance.redKeys++;
            }
            else if (gameObject.name.StartsWith("coin"))
            {
                wasTriggered = true;
                Player._instance.coinCount++;
            }
            else if (gameObject.name.StartsWith("Frog"))
            {
                wasTriggered = true;
                Player._instance.frogCount++;
            }
            else if (gameObject.name.StartsWith("lock_blue") && (Player._instance.blueKeys > 0))
            {
                wasTriggered = true;
                Player._instance.blueKeys--;
            }
            else if (gameObject.name.StartsWith("Exit"))
            {
                wasTriggered = true;
                youWinText.text = "YOU ARE ALIVE";
                Player._instance.isActive = false;
                Player._instance.MakeAlive();
            }


            if (wasTriggered)
            {
                wasCollected = true;
                AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
                Player._instance.playerScore += pointsForPickup;
                Player._instance.UpdateUI();
                if (!gameObject.name.StartsWith("Exit"))
                {
                    gameObject.SetActive(false);
                    Destroy(gameObject);
                }
            }
        }
    }
}
