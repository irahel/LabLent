using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite_clicable : MonoBehaviour
{

    [SerializeField] private game controler;

    void OnMouseDown()
    {        
        controler.btn_ON_OFF();
    }
}
