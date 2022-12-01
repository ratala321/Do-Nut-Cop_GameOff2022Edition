using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SewerMonsterTrap : MonoBehaviour
{
    [SerializeField] private float intervalForMonsterRedBeforeGoingOut;

    [SerializeField] private float intervalForMonsterStayingOut;

    [SerializeField] private float intervalForMonsterGoingBackToRed;

    private SpriteRenderer sr;

    private BoxCollider2D boxCollider;

    private bool monsterInSewer;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        boxCollider = GetComponent<BoxCollider2D>();

        StartCoroutine(SewerMonsterOut());
    }

    private IEnumerator SewerMonsterOut()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(intervalForMonsterRedBeforeGoingOut);
        boxCollider.enabled = true;
        yield return new WaitForSeconds(intervalForMonsterStayingOut);
        boxCollider.enabled = false;
        sr.color = Color.white;
        yield return new WaitForSeconds(intervalForMonsterGoingBackToRed);
        StartCoroutine(SewerMonsterOut());
    }
}
