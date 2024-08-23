using System;
using System.Collections;
using UnityEngine;

public class ChargedRectangleAttack : RectangleAttack, IChargedAttack {
    [SerializeField] private GameObject damageZone;
    [SerializeField] private float castDuration = 1f;
    [SerializeField] private float cooldown = 5f;
    private bool isReady = true;

    private void Start() {
        damageZone.transform.localScale = new Vector3(size.x, size.y, 1);
    }
    
    private IEnumerator ResetCooldown() {
        isReady = false;
        yield return new WaitForSeconds(cooldown);
        isReady = true;
    }

    public bool IsReady() => isReady;

    public void Charge(Action onCompleted)
    {
        StartCoroutine(ResetCooldown());
        damageZone.GetComponent<IAnimatable>().Animate(castDuration, onCompleted);
    }

    public float GetDuration()
    {
        return castDuration;
    }

    public void Cancel()
    {
        damageZone.GetComponent<IAnimatable>().Stop();
    }
}