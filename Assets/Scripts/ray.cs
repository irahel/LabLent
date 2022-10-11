using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour
{       
    [SerializeField] private float step;
    [SerializeField] private GameObject ray_inside;
    [SerializeField] private Transform f_r;
    private bool hited = false;

    private BoxCollider2D collider_i;

    private void Start()
    {
        collider_i = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        if (!hited)
        {
            transform.localScale = new Vector3(transform.localScale.x  + step, transform.localScale.y, 1);
        }        
    }
    
    private void end_mov()
    {
        hited = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "collider_l")
        {
            //collision.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            collider_i.enabled = false;

            Invoke("end_mov", 0.01f);
            //end_mov();

            //Debug.Log(collision.contactCount);
            var hit_pos = collision.GetContact(collision.contactCount-1);

            Debug.Log(hit_pos.point);

            Vector3 target = f_r.position;
            var angle = Mathf.Atan2(target.y - hit_pos.point.y, target.x - hit_pos.point.x) * Mathf.Rad2Deg;


            
            Instantiate(ray_inside, new Vector3(
                                          hit_pos.point.x,
                                        transform.position.y, 0), Quaternion.Euler(0, 0, -angle));
        }
        else if (collision.gameObject.tag == "border")
        {
            hited = true;
        }
        
        }

}
