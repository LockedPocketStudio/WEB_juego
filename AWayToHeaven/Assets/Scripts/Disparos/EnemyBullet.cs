using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public int damage { get; set; }
    public Vector2 dir;
    public bool colliding = false;
    public int health { get; set; }
    public Rigidbody2D rb;
    private float LifeTime = 3f;

    GameManager GM;

    void Start()
    {
        dir = dir.normalized;
        rb = GetComponent<Rigidbody2D>();
        GM = GameManager.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.estadoJugador != 1)
        {
            return;
        }


        if (GM.modoJuego == -1)
        {
            return;
        }
        colliding = false;
        float distThisFrame = speed * Time.deltaTime;

        //this.transform.Translate( dir * distThisFrame, Space.World );
        rb.MovePosition(rb.position + dir * distThisFrame);

        LifeTime -= Time.deltaTime;
        if (LifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    protected virtual void OnTriggerEnter2D(Collider2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Player":
                Destroy(gameObject);
                break;
            case "BulletWall":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
