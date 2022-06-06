using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class WallTileManager : MonoBehaviour
{
    public static WallTileManager _instance;

    [SerializeField] Tilemap tileMap;
    [SerializeField] Tile cellTile;


    private void Awake()
    {
        _instance = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("xbullet " + collision.transform.position);
        Vector3Int cell = tileMap.WorldToCell(collision.transform.position);
        Debug.Log("xwall " + cell);
        tileMap.SetTile(cell, null);


    }

    public void WallHit(Vector2 pos)
    {
        Debug.Log("bullet " + pos);
        Vector3Int cell = tileMap.WorldToCell(pos);
        cell.y += 1;
        Debug.Log("wall " + cell);
        tileMap.SetTile(cell, null);

        //Vector3Int cell = new Vector3Int(-10, -9, 0);
        //tileMap.SetTile(cell, cellTile);


    }
}
