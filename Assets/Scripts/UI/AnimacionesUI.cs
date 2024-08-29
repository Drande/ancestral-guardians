using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionesUI : MonoBehaviour
{
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject InicioGrupo;

    private void Start()
    {
        LeanTween.moveX(logo.GetComponent<RectTransform>(), 0, 1.5f).setDelay(2.5f)
        .setEase(LeanTweenType.easeOutBounce).setOnComplete(BajarAlpha);
    }

    private void BajarAlpha()
    {
        LeanTween.alpha(InicioGrupo.GetComponent<RectTransform>(), 0f, 1f).setDelay(0.5f);
        InicioGrupo.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
