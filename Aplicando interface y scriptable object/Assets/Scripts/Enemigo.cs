using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class Enemigo : MonoBehaviour, IPresentacion, IReciboDa�o
{
    [SerializeField] private ScriptableEnemy enemyData;
    private string nombre;
    private int vida;
    private string saludo;

    private void Start()
    {
        nombre = enemyData.nombre;
        vida = enemyData.vida;
        saludo = enemyData.saludo;
    }

    public void Accion ()
    {
        enemyData.PrintData();
    }

    public void RecibirDa�o(int dmg)
    {
        enemyData.vida -= dmg;

        if (enemyData.vida <= 0)
        {
            Debug.Log("El enemigo " + nombre + " muri�!");
        }
    }
}