using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_Inside : MonoBehaviour
{
    [SerializeField] private float step;
    [SerializeField] private GameObject ray_collide;
    [SerializeField] private Transform f_r;
    private bool hited = false;
    private bool actived = false;

    BoxCollider2D collider_i;

    [SerializeField] private float adjust_y;
    private void Start()
    {
        collider_i = GetComponent<BoxCollider2D>();

        f_r = GameObject.FindGameObjectWithTag("lr").transform;
    }

    void Update()
    {

        if (!hited)
        {
            transform.localScale = new Vector3(transform.localScale.x + step, transform.localScale.y, 1);
        }
    }
    private void end_mov()
    {
        hited = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "collider_r" && !actived)
        {
            collider_i.enabled = false;

            actived = true;
            hited = true;
            //Invoke("end_mov", 0.0004f);

            //Debug.Log(collision.contactCount);
            var hit_pos = collision.GetContact(collision.contactCount - 1);



            Vector3 target = f_r.position;
            var angle = Mathf.Atan2(target.y - hit_pos.point.y, target.x - hit_pos.point.x) * Mathf.Rad2Deg;
            
            
            Instantiate(ray_collide, new Vector3(
                                          hit_pos.point.x,
                                        hit_pos.point.y + adjust_y, 0), Quaternion.Euler(0, 0, angle));
        }
        else if (collision.gameObject.tag == "border")
        {
            hited = true;
        }
    }
}