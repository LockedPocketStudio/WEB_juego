using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Historia : MonoBehaviour
{

    public float tText = 0.15f;
    public float tLeft = 0;

    public GameObject EscenaDialogo;
    public GameManager GM;
    public TMP_Text t;
    public Text nombre;
    public Image imagen;
    public Sprite elias;
    public Sprite canv;

    List<string> Introduccion;


    List<string> Sala1;
    public int y = 0;//Sala1

   
    string s1 = "..."; 
    string s2 = "�nnngghhhn�";
    string s3 = "Mi espalda� c�mo duele�";
    string s4 = "Siento que he dormido 3 d�as, no volver� a comer Timbre BurritoTM";

    string c1 = "�Por fin despiertas! Ya era hora, llevo aqu� como mil a�os esperando.";
    string s5="�Qu� llevas cu�nto? Espera un momento, y t� qui�n eres. �D�nde estoy?";
    string c2="Bueno yo tambi�n me alegro de conocerte eh, qu� maleducado�";
    string s6 = "Oye lo siento, pero-";
    string c3 = "Est�s muerto.";
    string s7 = "Qu-";
    string c4 = "�Sorpresa!";
    string s8 = "Espera un m-";
    string c5 ="Siento ser yo quien te de la noticia pero has venido a parar aqu�, as� que �bienvenido!";
    string s9 =  "Bueno este sue�o es raro que flipas, c�mo hago para despertarme� El examen de literatura no se estudia solo �sabes?";
    string c6 = "Ughhh la gente que no sabe de lo que habla es la peor de la que viene a parar aqu�.T� te lo has buscado";
    string s10 = "��AAAAAAGH!! OYE ESO HA DOLIDO";
    string c7 = "Esc�chame bien zoquete, la cosa va as�, t� mueres, vienes aqu� y nosotros� �cuidamos� de t� �por el resto de la eternidad!";
    string s11 = "�Pero qu� dices! si yo solo estaba ech�ndome una siesta despu�s de come";
    string c8 = "Bueno y qu� culpa tengo yo de las cosas cuestionables que ingieres. �Quieres que vuelva a mostrarte un dolor muy real para que te entre en ese peque�o cerebro que tienes?";
    string s12="No, no� pero no puede ser�";
    string s13="��QUE HE MUERTO?! Ni siquiera he llegado a la salida de A Flower�s Dream: The Beginning� �y ahora qu� hago? este sitio no tiene muy buena pinta� �Tengo que quedarme aqu� para siempre? Ohhh� ya puedo sentir c�mo me empiezo a volver loco.";
    string  s14="�T�! vas a torturarme ��es eso?! �Qu� he hecho yo para merecer estar aqu�? Si es por lo de Mateo no iba en serio, �solo brome�bamos";
    string c9 = "Bueno, bueno, primero que todo, tengo nombre, segundo �tranquil�zate! Tampoco es para tanto, no es como si nadie hubiese muerto nunca.";
    string s15 ="ES LA PRIMERA VEZ QUE MUERO YO.";
    string c10 ="Tampoco eres tan importante.";
    string s16 ="T��";
    string c11 = "Yo me llamo Clavis. Digamos que � trabajo aqu�, recibiendo a las pobres almas que vienen a parar a este� curioso reino";
    string s17 = "Escucha, Clavis, tiene que haber una forma de salir de aqu�, esto tiene que ser una especie de prueba, no puedo haber acabado en el infierno, �no tiene ning�n sentido!";
    string c12 = "Mira que eres insistente, si quieres respuestas ve a hablar con el jefe, si es que te atreves.";
    string s18 ="��Si me atrevo�?";
    string c13 ="�Por supuesto! Hacen falta agallas para atravesar este lugar y llegar a �l�";
    string c14 ="Mira, tengo una propuesta para t�. Si est�s tan seguro de que esto es un error, yo puedo llevarte, y ya t� negocias con el jefe, a ver si as� resuelves tus dudas.";
    string c15 ="Para llegar habr�s de pasar las distintas pruebas que yo personalmente me encargar� de poner en tu camino, pero con la condici�n de que cada vez que falles volver�s a empezar, desde el principio";
    string c16 = "�Trato hecho?";
    string s19 ="� �S� s�, claro que trato hecho! ";
    string c17 = "Heheheh� �Genial! Me alegra hacer tratos contigo� �C�mo dec�as que te llamabas?";
    string s20 ="El�as, me llamo El�as. Como el profeta.";
    string c18 ="Mucho gusto Eli, pues como me has caido bien te voy a contar c�mo va a funcionar esto.";
    string s21 ="El�as� mejor ll�mame El�as. ";
    string s22 ="...Eli es nombre de ni�a...";
    string c19 = "� Bueno Eli, te explico:";
    string c20 = "El jefe se encuentra dos plantas por encima de esta. En realidad, preferimos llamarlo anillos en vez de plantas, suena mucho mejor, tiene m�s gancho.";
    string c21 = "Cada anillo est� formado por unas cuantas salas, por las cuales te podr�s mover gracias a mi ayuda y mis llaves. Cuando llegues a la puerta de cada sala yo te la abrir�, para que puedas ir a alguna de las de alrededor.";
    string c22 = "En una de estas salas habr� unas escaleras por las que podr�s subir al siguiente anillo, as� que c�ntrate en llegar hasta all�.";
    string c23 = "Tengo amigos en muchas de estas salas, pero ten cuidado, a veces se ponen un poco� agresivos. Ya te los ir� presentando.";
    string c24 = "Adem�s, tengo algunas sorpresas preparadas en ciertas salas para darle un poco de sabor a este viaje, al fin y al cabo �esta es mi forma de divertirme! Es tu decisi�n cu�nto quieras investigar";
    string c25 = "Cuando hayas superado los dos anillos podr�s hablar con el jefe. �Venga Eli a trabajar, que a�n no es Domingo!";
    string c26 = "No hace falta que lo diga pero no te preocupes por morir, solo doler� un mont�n pero ah� estar� para volver a recibirte HA HA HA. ";

    public bool FinDialogo1 = false;

public List<string> TextoElias;
   public List<string> c;

    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();

        Sala1 = new List<string>();
        TextoElias = new List<string>();
        c= new List<string>();

        Sala1.Add(s1);
        Sala1.Add(s2);
        Sala1.Add(s3);
        Sala1.Add(s4);
        Sala1.Add(c1); Sala1.Add(s5); Sala1.Add(c2); Sala1.Add(s6); Sala1.Add(c3); Sala1.Add(s7); Sala1.Add(c4); Sala1.Add(s8); Sala1.Add(c5); Sala1.Add(s9); Sala1.Add(c6); Sala1.Add(s10); Sala1.Add(c7); Sala1.Add(s11); Sala1.Add(c8); Sala1.Add(s12);
        Sala1.Add(s13); Sala1.Add(s14); Sala1.Add(c9); Sala1.Add(s15); Sala1.Add(c10); Sala1.Add(s16); Sala1.Add(c11); Sala1.Add(s17); Sala1.Add(c12); Sala1.Add(s18); Sala1.Add(c13); Sala1.Add(c14); Sala1.Add(c15); Sala1.Add(c16); Sala1.Add(s19);
        Sala1.Add(c17); Sala1.Add(s20); Sala1.Add(c18); Sala1.Add(s21); Sala1.Add(s22); Sala1.Add(c19); Sala1.Add(c20); Sala1.Add(c21); Sala1.Add(c22); Sala1.Add(c23); Sala1.Add(c24); Sala1.Add(c25); Sala1.Add(c26);


     
        c.Add(c1); c.Add(c1); c.Add(c3); c.Add(c4);  c.Add(c5); c.Add(c6);  c.Add(c7); c.Add(c8);
        c.Add(s13);  c.Add(c9);  c.Add(c10);  c.Add(c11);  c.Add(c12);  c.Add(c13); c.Add(c14); c.Add(c15); c.Add(c16); 
        c.Add(c17);  c.Add(c18);   c.Add(c19); c.Add(c20); c.Add(c21); c.Add(c22); c.Add(c23); c.Add(c24); c.Add(c25); c.Add(c26);

        GM.modoJuego = 3;

    }

    // Update is called once per frame
    void Update()
    {
        if(!FinDialogo1)
        TextoSala1();
    }

    public void TextoSala1()
    {
        if (tLeft > tText)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
            {
                if (Sala1.Count != y)
                {
                    t.text = Sala1[y];
                    //Buscar personaje
                    bool esc = false;
                    for(int i = 0; i < c.Count; i++)
                    {
                        if(Sala1[y] == c[i])
                        {
                            esc = true;
                        }
                    }
                    if (esc)
                    {
                        nombre.text = "CLAVIS";
                        imagen.sprite = canv;
                    }
                    else
                    {
                        nombre.text = "ELIAS";
                        imagen.sprite = elias;
                    }
                    
                    y++;
                    tLeft = 0;
                }

            }

            if (y == Sala1.Count)
            {
                GM.modoJuego = 0;
                FinDialogo1 = true;
                EscenaDialogo.SetActive(false);
            }
        }

        tLeft += Time.deltaTime;
    }
}
