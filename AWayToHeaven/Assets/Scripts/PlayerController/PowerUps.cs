using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : Player
{
    //Define el power up que ha tocado
    public int AleatorioPowerUps;

    //Nivel Del power up
    int velocidadDisparo = 0; //0
    int dobleDisparo = 0; //1
    int Masvida = 0; //2
    int recuperarvida = -1; //3
    int controlsierra = 0;  //4
    int aumentarDañodisparo = 0; //5
    int aumentarAlcance =0;  //6
    int aumentarVelocidadMovimiento = 0;  //7

  public void AumentarVelocidadDisparo(int n)
    {
      
            fireCooldown = 0.5f;
        
    }
    public void DobleDisparo()
    {
        fireCooldownLeft = 0;
    }
    public void MasVida()
    { 
        VidaMaxima++;
    }
    public void RecuperarVida()
    {
        VidaActual = VidaMaxima;
    }
    public void AumentarDañoDisparo()
    {
        bulletDamage++;
    }
    public void AumentarAlcance()
    {
        radius++;
    }
}
