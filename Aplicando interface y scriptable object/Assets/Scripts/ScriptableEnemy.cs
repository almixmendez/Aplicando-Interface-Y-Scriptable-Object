using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")]
public class ScriptableEnemy : ScriptableObject
{
    [SerializeField] public string nombre;
    [SerializeField] public int vida;
    [SerializeField] public string saludo;

    public void PrintData()
    {
        Debug.Log(nombre);
        Debug.Log(vida);
        Debug.Log(saludo);
    }
}
