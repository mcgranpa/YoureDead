using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatManager : MonoBehaviour
{
    [SerializeField] private GameObject[] bats;
    [SerializeField] private bool turnOnBats = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("turn on bats");
            if (turnOnBats) { enableBats(); }
            else { disableBats(); }
        }
    }

    public void enableBats()
    {
        foreach (GameObject go in bats)
        {
            go.SetActive(true);
        }
    }

    public void disableBats()
    {
        foreach (GameObject go in bats)
        {
            go.SetActive(false);
        }
    }

}
