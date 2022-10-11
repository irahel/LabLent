using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_Collide : MonoBehaviour
{
           
    [SerializeField] private float step;    
    private bool hited = false;
    [SerializeField] private Transform f_r;
    private lupaclick aux_btn;

    
    void Start()
    {
        aux_btn = GameObject.FindGameObjectWithTag("btnzoom").GetComponent<lupaclick>();
        f_r = GameObject.FindGameObjectWithTag("lr").transform;
        
    }

    private void call_btn()
    {
        aux_btn.appear();
    }

    void Update()
    {
        
        //Vector3 target = f_r.position;
        //var angle = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, angle);                
        if (!hited)
        {
            transform.localScale = new Vector3(transform.localScale.x + step, transform.localScale.y, 1);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.tag == "border")
        {
            call_btn();
            hited = true;
        }
    }
}
