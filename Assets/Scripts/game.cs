using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game : MonoBehaviour
{
    private enum lant_state{ON, OFF}
    private lant_state lant_turn;

    [SerializeField] private SpriteRenderer lant_sprite;
    [SerializeField] private Sprite lant_sprite_on, lant_sprite_off;

    private Animator anim_control;

    void Start()
    {
        anim_control = GetComponent<Animator>();

        lant_turn = lant_state.OFF;
        lant_sprite.sprite = lant_sprite_off;
    }

    
    void Update()
    {
        
    }


    public void btn_ON_OFF()
    {
        if(lant_turn == lant_state.OFF)
        {
            lant_turn = lant_state.ON;
            lant_sprite.sprite = lant_sprite_on;
            anim_control.SetTrigger("Active");
        }
        else
        {
            lant_turn = lant_state.OFF;
            lant_sprite.sprite = lant_sprite_off;
            anim_control.SetTrigger("Unactive");
        }
    }

    public void btn_ZOOM()
    {
        anim_control.SetTrigger("Zoom");
    }
    public void btn_UNZOOM()
    {
        anim_control.SetTrigger("UnZoom");
    }

    public void btn_MENU()
    {
        SceneManager.LoadScene(0);
    }

}
