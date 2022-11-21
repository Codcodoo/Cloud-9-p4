using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyTile : MonoBehaviour
{
    private Tilemap tilemap;
    public string tag;
    public float range=1;
    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
        //tag = tilemap.tag;
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Vector3 pos = Vector3.zero;
    //    if (collision.collider.CompareTag(tag))
    //    {
    //        foreach (ContactPoint2D hit in collision.contacts)
    //        {
    //            pos.x = hit.point.x - 0.01f * hit.normal.x;
    //            pos.y = hit.point.y - 0.01f * hit.normal.y;
    //            tilemap.SetTile(tilemap.WorldToCell(pos), null);
    //            //tilemap.SetColor(tilemap.WorldToCell(pos), Color.grey);
    //            Debug.Log(tilemap.WorldToCell(pos));
    //        }
    //    }
    //}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag(tag))
        {
            Vector3 pos = collision.transform.position;
            //Debug.Log(pos);
            tilemap.SetTile(tilemap.WorldToCell(pos + Vector3.up * range), null);
            tilemap.SetTile(tilemap.WorldToCell(pos + Vector3.right * range), null);
            tilemap.SetTile(tilemap.WorldToCell(pos + Vector3.left * range), null);
            tilemap.SetTile(tilemap.WorldToCell(pos + Vector3.down * range), null);
            tilemap.SetTile(tilemap.WorldToCell(pos + Vector3.up * range + Vector3.left * range), null);
            tilemap.SetTile(tilemap.WorldToCell(pos + Vector3.up * range + Vector3.right * range), null);
            tilemap.SetTile(tilemap.WorldToCell(pos + Vector3.down * range + Vector3.left * range), null);
            tilemap.SetTile(tilemap.WorldToCell(pos + Vector3.down * range + Vector3.right * range), null);

            //Debug.Log(tilemap.WorldToCell(collision.transform.position));
            //if (tilemap.GetTile(tilemap.WorldToCell(pos + Vector3.up)))
            //{
            //    tilemap.SetTile(tilemap.WorldToCell(pos + Vector3.up), null);
            //}
            //else
            //{
            //    Debug.Log("sadf");
            //}
        }
    }
}
