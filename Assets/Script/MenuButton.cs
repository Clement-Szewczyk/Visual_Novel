using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class MenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Image ImageOutline;

    public TMPro.TextMeshProUGUI Text;

    public Color CI;
    public Color CS;

    public void OnPointerEnter()
    {
        ImageOutline.DOKill();
        ImageOutline.DOFade(1, 0.2f);

        Text.DOKill();
        Text.DOColor(CI, 0.2f);
    }

    public void OnPointerExit()
    {
        ImageOutline.DOKill();
        ImageOutline.DOFade(0, 0.1f);

        Text.DOKill();
        Text.DOColor(CS, 0.2f);
    }

}
