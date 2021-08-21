using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public GameObject damagePanel;
    public int damage = 10;

    private Animator animator;
    private bool isReady = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
	 this.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime);
         this.transform.Rotate(new Vector3(0, Random.Range(-90, 90), 0) * Time.deltaTime);

        if (Vector3.Distance(transform.position, player.transform.position) <= 2 && isReady)
        {
            StartCoroutine(Attack());
        }

        if (GetComponent<Health>().health <= 0)
        {
            animator.SetBool("dead", true);
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") && isReady)
    //    {
    //        StartCoroutine(Attack());
    //    }
    //}

    IEnumerator Attack()
    {
        isReady = false;

        animator.SetBool("playerInRange", true);
        damagePanel.SetActive(true);

        player.GetComponent<Player>().health -= damage;

        yield return new WaitForSeconds(0.5f);

        animator.SetBool("playerInRange", false);
        damagePanel.SetActive(false);

        isReady = true;
    }
}

