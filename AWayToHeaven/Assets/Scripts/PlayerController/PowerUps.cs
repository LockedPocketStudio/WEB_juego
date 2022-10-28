using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PowerUps : Player
{
    /*
    //Define el power up que ha tocado
    public int AleatorioPowerUps;

    //Nivel Del power up
   public static int velocidadDisparo = 0; //0
    public static int dobleDisparo = 0; //1
    public static int Masvida = 0; //2
    public static int recuperarvida = -1; //3
    public static int controlsierra = 0;  //4
    public static int aumentarDañodisparo = 0; //5
    public static int aumentarAlcance =0;  //6
    public static int aumentarVelocidadMovimiento = 0;  //7
    public static int[] Powers ={ 0, 0, 0, 0, 0, 0, 0, 0 };




    public void AumentarVelocidadDisparo(int n)
    {
        switch (n)
        {
            case 1:
                fireCooldown = 0.65f;
                break;
            case 2:
                fireCooldown = 0.55f;
                break;
            case 3:
                fireCooldown = 0.45f;
                break;
            case 4:
                fireCooldown = 0.25f;
                break;
        }
            
        
    }
    public  void DobleDisparo(int n)
    {
        fireCooldownLeft = 0;
    }
    public void MasVida(int n)
    { 
        VidaMaxima++;
    }
    public void RecuperarVida()
    {
        VidaActual = VidaMaxima;
    }
    public void AumentarDañoDisparo(int n)
    {
        bulletDamage++;
    }
    public void AumentarAlcance(int n)
    {
        radius++;
    }
    public void ControlSierra(int n)
    {

    }
    public void AumentarVelocidadMovimiento(int n)
    {

    }

    public  void GetPower()
    { 
        int random = (int)Random.Range(0, 7);

        if(random != 3)
        {
            while (Powers[random] == 4)
            {
                random = (int)Random.Range(0, 7);
            }
            Powers[random]++;
        }

        switch (random)
        {
            case 0:
                AumentarVelocidadDisparo(Powers[random]);
                break;
            case 1:
                DobleDisparo(Powers[random]);
                break;
            case 2:
                MasVida(Powers[random]);
                break;
            case 3:
                RecuperarVida();
                break;
            case 4:
                ControlSierra(Powers[random]);
                break;
            case 5:
                AumentarDañoDisparo(Powers[random]);
                break;
            case 6:
                AumentarAlcance(Powers[random]);
                break;
            case 7:
                AumentarVelocidadMovimiento(Powers[random]);
                break;
        }
    } */
}
