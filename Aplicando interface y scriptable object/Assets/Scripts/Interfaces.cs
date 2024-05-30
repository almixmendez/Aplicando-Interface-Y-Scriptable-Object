using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPresentacion
{
    void Accion();
}

public interface IReciboDaño
{
    void RecibirDaño(int dmg);
}
