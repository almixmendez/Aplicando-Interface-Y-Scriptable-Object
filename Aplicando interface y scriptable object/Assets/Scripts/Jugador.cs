using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] public float playerSpeed = 10f;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] Transform interactionPoint;
    [SerializeField] float interactionRange = 0.5f;
    Vector2 movement;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.R))
        {
            Interaccion();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Atacar();
        }
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + movement * playerSpeed * Time.fixedDeltaTime);
    }

    void Interaccion()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(interactionPoint.position, interactionRange);

        foreach (Collider2D enemy in hitEnemies)
        {
            Enemigo enemyComponent = enemy.GetComponent<Enemigo>();
            if (enemyComponent != null)
            {
                enemyComponent.Accion();
            }
        }
    }

    void Atacar()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(interactionPoint.position, interactionRange);

        foreach (var hitEnemy in hitEnemies)
        {
            if (hitEnemy.GetComponent<IReciboDaño>() != null)
            {
                Debug.Log("Le pegue a " + hitEnemy.name);
                hitEnemy.GetComponent<IReciboDaño>().RecibirDaño(1);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (interactionPoint == null)
            return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRange);
    }
}
