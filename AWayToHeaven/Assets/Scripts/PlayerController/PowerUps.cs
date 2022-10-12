using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : Player
{
    // Start is called before the first frame update
  public void AumentarVelocidadDisparo()
    {
        fireCooldown = 0.5f;
    }
    public void DobleDisparo()
    {
        fireCooldownLeft = 0;
    }
    public void MasVida()
    { 
        BaseLife++;
    }
    public void RecuperarVida()
    {
        life = BaseLife;
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
