using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopAnimation : MonoBehaviour
{
    public GameObject ShopButton;
    public GameObject TurretPanel;
    public GameObject turretInfo, launcherInfo;

    public void ShopButtonFirstClick()
    {
        Animator anim = ShopButton.GetComponent<Animator>();
        Animator animator = TurretPanel.GetComponent<Animator>();
        if(anim != null)
        {
            bool isOpen = anim.GetBool("firstClick");
            bool Open = animator.GetBool("Click");

            animator.SetBool("Click", !Open);
            anim.SetBool("firstClick", !isOpen);

            if (anim.GetBool("firstClick") == false)
            {
                turretInfo.SetActive(false);
                launcherInfo.SetActive(false);
            }
        }
    }
}
