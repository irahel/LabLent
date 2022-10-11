using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public enum SELEC_OPTION { BICONVEX, BICONVAC}
    public SELEC_OPTION selection;

    [SerializeField] private Image Painel;
    [SerializeField] private Image Painel_child;

    [SerializeField] private Sprite pnl_biconvex, pnl_biconvac, img_biconvex, img_biconvac;
    [SerializeField] private Animator anim_control;

    private void Start()
    {
        selection = SELEC_OPTION.BICONVEX;
        Painel.sprite = pnl_biconvex;
        Painel_child.sprite = img_biconvex;
        anim_control.SetTrigger("change");
    }

    public void btn_arrows()
    {
        if(selection == SELEC_OPTION.BICONVEX)
        {
            anim_control.SetTrigger("change");
            selection = SELEC_OPTION.BICONVAC;
            Painel.sprite = pnl_biconvac;
            Painel_child.sprite = img_biconvac;
        }
        else
        {
            anim_control.SetTrigger("change");
            selection = SELEC_OPTION.BICONVEX;
            Painel.sprite = pnl_biconvex;
            Painel_child.sprite = img_biconvex;
        }
    }

    public void btn_play()
    {
        if (selection == SELEC_OPTION.BICONVEX)     biconvex();       
        else                                        biconvac();

        
    }

    private void biconvex()
    {
        SceneManager.LoadScene(1);
    }

    private void biconvac()
    {
        SceneManager.LoadScene(2);
    }
}
