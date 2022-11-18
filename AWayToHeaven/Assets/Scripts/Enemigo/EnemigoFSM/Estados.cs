using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadosEnemigo
{
    public string Descansando;
    public string Acercandose;
    public string Atacando;

    public EstadosEnemigo()
    {
        Descansando = "descansando";
        Acercandose = "acercandose";
        Atacando = "atacando";

    }
}

//se crea una clase especial para enumerar los estados del enemigo especial FSM
public class EstadosEnemigoEspecial
{
    public string Patrullando;
    public string Acercandose;
    public string Atacando;
    public string Escapando;
    public string Curando;

    public EstadosEnemigoEspecial()
    {
        Patrullando = "patrullando";
        Acercandose = "acercandose";
        Atacando = "atacando";
        Escapando = "escapando";
        Curando = "curando";
    }
}
