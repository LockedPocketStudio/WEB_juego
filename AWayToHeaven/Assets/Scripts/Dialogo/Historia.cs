using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Historia : MonoBehaviour
{
    public Button PasarTexto;
    bool puedePasar = false;


    public float tText = 0.15f;
    public float tLeft = 0;

    public GameObject EscenaDialogo;
    public GameManager GM;
    public TMP_Text t;
    public Text nombre;
    public Image imagen;
    public Sprite elias;
    public Sprite canv;
    public Sprite anom;
    public Sprite dios;

    List<string> Introduccion;

    //DIÁLOGOS OBLIGATORIOS
    List<string> Sala1;
    List<string> Esc2;  //Escena 2
    List<string> Esc3;  //Escena 3
    List<string> Esc4;  //Escena 4
    List<string> Esc5;  //Escena 5

    public int y = 0;//Sala1

    //DIÁLOGOS OPCIONALES
    List<string> EscOp1;  //Escena op 1
    List<string> EscOp2;  //Escena op 2
    List<string> EscOp3;  //Escena op 3
    List<string> EscOp4;  //Escena op 4
    List<string> EscOp5;  //Escena op 5
    List<string> EscOp6;  //Escena op 6

    //DIALOGOS OBLIGATORIOS
    #region D1
    //Primera escena s=elias c=clavis
    public string s1 = "...";
    string s2 = "...nnngghhhn...";
    string s3 = "Mi espalda... cómo duele...";
    string s4 = "Siento que he dormido 3 días, no volveré a comer Timbre BurritoTM";

    string c1 = "¡Por fin despiertas! Ya era hora, llevo aquí como mil años esperando.";
    string s5 = "¿Que llevas cuánto? Espera un momento, ¡¿y tú quién eres?! ¿Dónde estoy?";
    string c2 = "Bueno yo también me alegro de conocerte eh, qué maleducado...";
    string s6 = "Oye, lo siento, pero-";
    string c3 = "Estás muerto.";
    string s7 = "Qu-";
    string c4 = "¡Sorpresa!";
    string s8 = "Espera un m-";
    string c5 = "Siento ser yo quien te de la noticia, pero has venido a parar aquí, así que ¡bienvenido!";
    string s9 = "Bueno este sueño es raro que flipas, a ver cómo hago para despertarme… El examen de literatura no se estudia solo ¿sabes?";
    string c6 = "Ughhh la gente que no sabe de lo que habla es la peor de la que viene a parar aquí. Tú te lo has buscado.";
    string s10 = "¡¡AAAAAAGH!! OYE ESO HA DOLIDO.";
    string c7 = "Escúchame bien zoquete, la cosa va así: tú mueres, vienes aquí y nosotros… “cuidamos” de ti ¡por el resto de la eternidad!";
    string s11 = "¡Pero qué dices! si yo solo estaba echándome una siesta después de comer.";
    string c8 = "Bueno y qué culpa tengo yo de las cosas cuestionables que ingieres.";
    string c9 = "¿Quieres que vuelva a mostrarte un dolor muy real para que te entre en ese pequeño cerebro que tienes?";
    
    string s12 = "No, no… pero no puede ser…";
    string s13 = "¡¿QUE HE MUERTO?! Ni siquiera he llegado a la salida de A Flower’s Dream: The Beginning… ";
    string s14 = "¿Y ahora qué hago? este sitio no tiene muy buena pinta… ¿Tengo que quedarme aquí para siempre?";
    string s15 = "Ohhh… ya puedo sentir cómo me empiezo a volver loco.";
    string s17 = "¡Tú! vas a torturarme ¡¿es eso?! ¿Qué he hecho yo para merecer estar aquí?";
    string s18 = "Si es por lo de Mateo… no iba en serio, ¡solo bromeábamos!";
    string c10 = "Bueno, bueno, primero que todo, tengo nombre, segundo ¡tranquilízate!";
    string c11 = "Tampoco es para tanto, no es como si nadie hubiese muerto nunca.";
    string s19 = "ES LA PRIMERA VEZ QUE MUERO YO.";
    string c12 = "Tampoco eres tan importante.";
    string s20 = "Tú…";
    string c13 = "Yo me llamo Clavis. Digamos que… trabajo aquí, recibiendo a las pobres almas que vienen a parar a este… curioso reino.";
    string s21 = "Escucha, Clavis, tiene que haber una forma de salir de aquí, esto tiene que ser una especie de prueba, no puedo haber acabado en el infierno,";
    string s22 = "¡no tiene ningún sentido!";
    string c14 = "Mira que eres insistente, si quieres respuestas ve a hablar con el jefe, si es que te atreves.";
    string s23 = "...";
    string s24 = "¿Si me atrevo?";
    string c15 = "¡Por supuesto! Hacen falta agallas para atravesar este lugar y llegar a él…";
    string c16 = "Mira, tengo una propuesta para ti:";
    string c17 = "Si estás tan seguro de que esto es un error, yo puedo llevarte, y ya tú negocias con el jefe, a ver si así resuelves tus dudas.";
    string c18 = "Para llegar habrás de pasar las distintas pruebas que yo personalmente me encargaré de poner en tu camino,";
    string c19 = "pero con la condición de que cada vez que falles volverás a empezar, desde el principio.";
    string c20 = "¿Trato hecho?";
    string s25 = "...";
    string s26 = "¡Sí sí, claro que trato hecho!";
    string c21 = "Heheheh… ¡Genial! Me alegra hacer tratos contigo… ¿Cómo decías que te llamabas?";
    string s27 = "Elías, me llamo Elías. Como el profeta.";
    string c22 = "Mucho gusto Eli, pues como me has caído bien te voy a contar cómo va a funcionar esto.";
    string s28 = "Elías… mejor llámame Elías.";
    string s29 = "… … Eli es nombre de niña";
    string c23 = "...";
    string c24 = "Bueno Eli, te explico:";
    string c25 = "El jefe se encuentra dos plantas por encima de esta.";
    string c26 = "En realidad, preferimos llamarlo anillos en vez de plantas, suena mucho mejor, tiene más gancho.";
    string c27 = "Cada anillo está formado por unas cuantas salas, por las cuales te podrás mover gracias a mi ayuda y mis llaves.";
    string c28 = "Cuando llegues a la puerta de cada sala yo te la abriré, para que puedas ir a alguna de las de alrededor.";
    string c29 = "En una de estas salas habrá unas escaleras por las que podrás subir al siguiente anillo, así que céntrate en llegar hasta allí.";
    string c30 = "Tengo amigos en muchas de estas salas, pero ten cuidado, a veces se ponen un poco… agresivos. Ya te los iré presentando.";
    string c31 = "Además, tengo algunas sorpresas preparadas en ciertas salas para darle un poco de sabor a este viaje, al fin y al cabo ¡esta es mi forma de divertirme!";
    string c32 = "Es tu decisión cuánto quieras investigar.";
    string c33 = "Cuando hayas superado los dos anillos podrás hablar con el jefe. ¡Venga Eli a trabajar, que aún no es Domingo!";
    string c34 = "No hace falta que lo diga, pero no te preocupes por morir, solo dolerá un montón, pero ahí estaré para volver a recibirte HA HA HA.";
    string c35 = "¡Ah! ¡Casi se me olvidaba! Te voy a dar una pequeña ayudita para hacer esto más divertido.";
    string c36 = "¿Ves que tus manos ahora están verdes? Pues prueba a acercarte a alguno de mis amigos, a ver qué pasa…";

    public static bool FinDialogo1 = false;
    public bool IniciarD1 = false;
    #endregion

    #region D2
    //Segunda escena x= Clavis b= Elías
    public string x1 = "Vaya, vaya… pero si has conseguido llegar hasta la primera escalera. ¡Quién lo diría Emilio!";
    string x2 = "Cómo consiga llegar hasta el jefe me voy a llevar una buena bronca..."; //cambiar color
    string b1 = "Elías ... me llamo Elías";
    string x3 = "¡Eso, eso! Es verdad, Eli, disculpa jejeje.";
    string b2 = "... ... Elías";
    string x4 = "Bueno, a lo que iba ¿Qué tal lo estás pasando? Yo lo estoy pasando de maravilla viéndote ... hablar con mis amigos. Son muy divertidos, ¿a que sí?";
    string b3 = "Creo que no tenemos el mismo concepto de divertido…";
    string b4 = "¡¿Por qué no me avisaste de que me iban a disparar?! ¡Este camino es un infierno!";
    string b5 = "¡Cada vez que entro en una sala me encuentro a tus amiguitos disparándome!";
    string x5 = "Bueno hombre Esteban, tampoco hay que ponerse así. Ya te avisé de que eran un poco raritos.";
    string x6 = "Además, no tiene ninguna gracia si no te lo pongo un poco difícil ¡hay que trabajar duro!";
    string b6 = "¡Que me llamo Elías!";
    string x7 = "¡Venga chaval, mucho ánimo! El siguiente anillo será un poco más difícil, para añadirle emoción";
    string x8 = "Espero que no lo consigas superar..."; //Cambiar color
    
    public bool IniDialogo2 = false;
    public static bool FinDialogo2 = false;
    #endregion

    #region D3
    //Tercera escena i=clavis j=elías
    public string i1 = "¡Bienvenido al siguiente anillo! Como puedes ver, en este hace un poco más de frío, pero confío en que mis amigos harán que te sientas arropado.";
    string i2 = "Nos vemos después Eliseo";
    string j1 = "...Elías";

    public static bool FinDialogo3 = false;
    public bool D3 = false;
    public int di3 = 1;
    #endregion

    #region D4
    //Cuarta escena m=clavis o=elias
    public string m1 = "¡Anda Enrique! No me esperaba que llegaras hasta aquí, no te voy a mentir...";
    string m2 = "...";
    string m3 = "...";
    string m4 = "Bueno, supongo que entonces puedes subir a hablar con el jefe.";
    string m5 = "Eso sí, déjame adelantarme para avisarle de que tiene visita, no es muy fan de las sorpresas que digamos.";
    string m6 = "Por Dios, espero que no se enfade mucho..."; //Cambiar color
    string o1 = "...";
    string o2 = "No me puedo creer que todavía no se haya aprendido mi nombre";

    public static bool FinDialogo4 = false;
    public bool D4 = false;
    int di4 = 1;

    #endregion

    #region finalR
    //Quinta escena --- Escena final a=anonimo d=dios e=elias l=clavis
    public string a1 = "Clavis...";
    string l1 = "¡No es culpa mía!";
    string a2 = "¡POR SUPUESTO QUE LO ES! ¿UN TRATO CON UN HUMANO?¿EN QUÉ PIENSA ESA CABEZA QUE TE HAN DADO?";
    string l2 = "OYE YO SOLO HAGO MI TRABAJO";
    string a3 = "TU TRABAJO ES TORTURARLOS NO TRAERMELOS.";
    string l3 = "¡Échales la culpa a tus juguetes rotos! Ellos no han sido capaces de mantenerlo a raya.";
    string l4 = "Además, ¿preferías que le dejase ahí lamentándose? Aburridísimo. No pensé que Evar-";
    string e1 = "¡Elías! Me llamo Elías.";
    string e2 = "Y he cumplido mi parte del trato, ahora tengo derecho a una charla con el jefe.";
    string l5 = "Ay Dios...";
    string e3 = "Mire no quiero molestarle demasiado, simplemente quiero pedirle que me sacase de aquí y me mande al Cielo.";
    string e4 = "Claramente ha habido una confusión, exijo saber qué le hace pensar que merezco ser torturado.";
    string a4 = "¿Al Cielo? Mejor te hago yo una pregunta, ¿qué te hace pensar que mereces ir al cielo?";
    string e5 = "Pues... No estoy seguro Señor... ¡Pero desde luego nunca hice nada como para acabar aquí!";
    string a5 = "Ya... ¿y qué es “aquí”?";
    string e6 = "¡El infierno obviamente! Está lleno de monstruos que quieren eliminarme, está oscuro, hace calor y huele que apesta.";
    string a6 = "PffffttJAJAJAJAJAJAJAJAJAJAJAJAJ OYES ESO CLAVIS";
    string l6 = "JAJAJAJJAJAJAJAJAJJAJAA TE LO DIJEE";
    string e7 = "...";
    string e8 = "¿Qué es tan gracioso?";
    string a7 = "Ahhh... Realmente no sabes nada chico. Este lugar donde ahora te encuentras...";
    string a8 = "Esto es el Cielo";
    string e9 = "Desde cuándo Satán reina el cielo a ver.";
    string l7 = "no hace más que liarla...";    //Cambiar color
    string d1 = "Yo soy el mismísimo Dios que tanto adoráis.";
    string d2 = "¿A qué has venido entonces? Si realmente eras un hombre bueno este es tu sitio, ¿de qué te quejas?";
    string e10 = "Oh... Dios";
    string e11 = "D- discúlpeme Señor, no pretendía ofenderos. Perdóneme por favor. E- Es solo que... no me imaginaba el Cielo así...";
    string e12 = "Desde que he llegado no han parado de sucederme cosas malas... Y este lugar no se parece en nada al Paraíso...";
    string l8 = "Deberías cuidar tus palabras Emanuel... hehehe";
    string d3 = "... ¿no se llamaba Elías?";  //cambiar color
    string d4 = "Bueno chico siento decirte que la imagen que tenéis los humanos del Cielo no es real. ¡No sé en qué momento se inventaron semejante chorrada! JAJAJAJA";
    string d5 = "Yo la verdad que dejé de prestaros atención hace bastantes siglos, me parece más entretenido ver cómo os desenvolvéis por aquí.";
    string d6 = "Espero que no estés decepcionado, al fin y al cabo, estás en el Cielo y has conocido al mismísimo Dios.";
    string e13 = "Entonces… ¿fue usted quién me puso tan difícil el camino hasta aquí? ¿ha estado observándome todo este tiempo?";
    string d7 = "¡Así es! Debo decirte que has sido uno de los más valientes que ha aparecido por aquí en mucho tiempo. ¡Has dado un espectáculo fantástico!";
    string d8 = "Y ahora, si me disculpas, quiero ver al siguiente que acaba de llegar ¡a ver qué tal se le da el camino a este ancianito!";
    string d9 = "Elías, ¡bienvenido al cielo!";

    public bool FinDialogo5 = false;
    public bool FIN = false;
    public int fn = 1;

    #endregion
    //DIALOGOS OPCIONALES
    #region Op1
    int op1 = 1;
    //SALA 4_4 DEL ANILLO 1 V=clavis w= elias
    public string v1 = "¡Hola Ernesto! ¡Qué bien verte por aquí!";
    string v2 = "Mira te he preparado esta pequeña sala de descanso, que por que veo has tomado el camino largo jajajaj";
    string v3 = "Así que nada, aprovecha y descansas un ratillo, ¡cuando quieras seguimos!";
    string w1 = "Um... Gracias, pero me llamo Elías.";
    string w2 = "Por cierto, tus amigos están siendo un poco … antipáticos. ¿Podrías decirles que dejaran de dispararme? Por favor.";
    string w3 = "Me defiendo como puedo, pero a veces lo ponen realmente difícil.";
    string v4 = "¡Ah sí! Perdona es que Pesadilla está empezando a competir en tiro al plato y tiene que entrenar mucho jajajaj";
    string w4 = "¿Pesadilla?";
    string v5 = "Sí, claro. Ese es el apodo de mi amigo. El que es así pequeñito y va volando por ahí.";
    string w5 = "Ya veo ya... Muy apropiado.";
    string v6 = "Bueno te dejo descansar tranquilo. Cuando quieras seguir me avisas.";

   public static bool FinDialogoOp1 = false;
    public  bool inicio4_4 = false;
    #endregion

    #region Op2
    //SALA 3_2 DEL ANILLO 1 f=clavis g=elias
    public string g1 = "¡¿Clavis cuánto queda para la escalera?! ¡No aguanto más!";
    string f1 = "¡Ay Eloy!, tranquilízate...";
    string g2 = "Clavis me llamo Elías... que siempre te equivocas";
    string f2 = "Venga anda, para que se te haga más corto lo que queda voy a dejarte un pequeño regalo en el cofre.";
    string f3 = "Eso sí, más te vale haberte esforzado porque si no el cofre no se abrirá.";
    string g3 = "¡Pero bueno! ¡Claro que me he esforzado! ¿O es que no me ves?";
    string f4 = "Ve a por tu recompensa entonces y sigue cuando estés listo, que ya queda poco para la escalera";

    public static bool FinDialogoOp2 = false;
    public bool IniOp2 = false;
    int Op2 = 1;

    #endregion

    #region Op3
    //SALA 1_3 DEL ANILLO 1 h=clavis k=elías
    public string k1 = "¿Qué es esto Clavis? ¿Una sala tranquila? ¡Por fin!";
    string h1 = "Bueno hombre tú también eres un poco exagerado, ¡ni que te estuvieras esforzando tanto!";
    string h2 = "Además, no te puedes quejar, que en esta sala te he dejado un regalito. Mira a ver en el cofre anda…";

    public static bool FinDialogoOp3 = false;
    public bool Op3 = false;
    public int op3 = 0;
    #endregion

    #region Op4
    //SALA 3_1 DEL ANILLO 2 p=clavis q=elias
   public string p1 = "¡Cuánto tiempo sin verte Eduardo! ¿Qué tal vas? Ya queda poco, pero esta parte es la más difícil jejejeje";
    string p2 = "y la más divertida para mí";   //cambiar color
    string q1 = "... me tiene que estar vacilando con esto del nombre";   //Cambiar de color
    string q2 = "Clavis, me llamo Elías, ya te lo he dicho varias veces. Si no te importa voy a aprovechar para descansar aquí un poco, que estoy muerto.";
    string p3 = "Sí, muerto sí que estás jajajaj.";
    string p4 = "Bueno pues, mientras descansas, ¿por qué no aprovechas y me cuentas algo de ti? ¿Cuántos años tenías? ¿A qué te dedicabas?";
    string p5 = "… aunque seguro que no tienes nada interesante que contar, pareces un poco pringado jajajaj"; //cambiar color
    string q3 = "¿Qué decías? ¿Sobre mí?";
    string q4 = "Bueno no sé, teng- tenía 26 años y trabajaba en un Timbre Burrito TM, ya sabes, hay que ahorrar para pagar el viaje a Mallorca…";
    string q5 = "A todo esto ¿tú cómo has acabado aquí?";
    string p6 = "Uf Bachillerato, que intenso.";
    string p7 = "Yo morí hace mucho. Cuando llegué aquí le caí bien al jefe y he sido una de sus “personas” de confianza desde entonces. Dice que hay poca gente como yo aquí...";
    string p8 = "... por lo visto aquí solo viene gente buena y aburrida";
    string p9 = "Así que nada, empecé a echarle una mano con tareas importantes, como recibir a los recién llegados como tú. Me gusta este trabajo. ";
    string p10 = "Bueno yo creo que ya has descansado lo suficiente Epicuro ¡A seguir buscando!";

    public bool FinDialogoOp4 = false;
    public bool OP4;
    public int op4 = 1;

    #endregion

    //SALA 2_1 DEL ANILLO 2 r=clavis t=elias
    public string r1 = "Espero que estés contento Eusebio, ya estás muy cerca del final. ¡Cualquiera lo diría eh! ¡Esto ya empezaba a parecer un castigo eterno!";
    string r2 = "aunque para castigo eterno el que me va a caer a mí por dejarte llegar hasta aquí...";    //cambiar color
    string t1 = "...";
    string t2 = "Gracias Clavis, pero mi nombre es Elías.";

    public bool FinDialogoOp5 = false;
    public bool OP5 = false;
    public int op5 = 1;

    #region Op6
    //SALA 1_3 DEL ANILLO 2 u=clavis z=elías
   public string z1 = "Uf menos mal, otra sala tranquila. Ya no podía más.";
    string u1 = "Y además te he dejado un regalo y todo, para que luego digas que no te trato bien eh...";

    public bool FinDialogoOp6 = false;
    public bool OP6 = false;
    public int op6 = 1;
    #endregion

    public List<string> TextoElias;
    public List<string> c;
    public List<string> TextoAnon;
    public List<string> TextoDios;

    int x = 1;
    void Start()
    {
        PasarTexto.onClick.AddListener(() => puedePasar = true);
        GM = GameManager.FindObjectOfType<GameManager>();

        TextoElias = new List<string>();
        c = new List<string>();
        TextoDios = new List<string>();
        TextoAnon = new List<string>();
        EscenaDialogo.SetActive(false);

        //DIALOGOS OBLIGATORIOS
        //Escena 1
        #region Escena1
        Sala1 = new List<string>();

        Sala1.Add(s1);
        Sala1.Add(s2);
        Sala1.Add(s3);
        Sala1.Add(s4);
        Sala1.Add(c1); Sala1.Add(s5); Sala1.Add(c2); Sala1.Add(s6); Sala1.Add(c3); Sala1.Add(s7); Sala1.Add(c4); Sala1.Add(s8); Sala1.Add(c5); Sala1.Add(s9); Sala1.Add(c6); Sala1.Add(s10); Sala1.Add(c7); Sala1.Add(s11); Sala1.Add(c8); 
        Sala1.Add(c9); 
        Sala1.Add(s12); Sala1.Add(s13); Sala1.Add(s14); Sala1.Add(s15); Sala1.Add(s17); Sala1.Add(s18);
        
        Sala1.Add(c10); Sala1.Add(c11); Sala1.Add(s19); Sala1.Add(c12); Sala1.Add(s20); 
        Sala1.Add(c13); Sala1.Add(s21); Sala1.Add(s22); Sala1.Add(c14); Sala1.Add(s23); Sala1.Add(s24); Sala1.Add(c15); Sala1.Add(c16); Sala1.Add(c17); Sala1.Add(c18); Sala1.Add(c19); Sala1.Add(c20); 
        Sala1.Add(s25); Sala1.Add(s26); Sala1.Add(c21); Sala1.Add(s27);
        Sala1.Add(c22); Sala1.Add(s28); Sala1.Add(s29); Sala1.Add(c23); Sala1.Add(c24); Sala1.Add(c25); Sala1.Add(c26); Sala1.Add(c27); Sala1.Add(c28); Sala1.Add(c29); Sala1.Add(c30);
        Sala1.Add(c31); Sala1.Add(c32); Sala1.Add(c33); Sala1.Add(c34); Sala1.Add(c35); Sala1.Add(c36);


        

        c.Add(c1); c.Add(c2); c.Add(c3); c.Add(c4); c.Add(c5); c.Add(c6); c.Add(c7); c.Add(c8);
        c.Add(c9); c.Add(c10); c.Add(c11); c.Add(c12); c.Add(c13); c.Add(c14); c.Add(c15); c.Add(c16);
        c.Add(c17); c.Add(c18); c.Add(c19); c.Add(c20); c.Add(c21); c.Add(c22); c.Add(c23); c.Add(c24); c.Add(c25); c.Add(c26); c.Add(c27); c.Add(c28);
        c.Add(c29); c.Add(c30); c.Add(c31); c.Add(c32); c.Add(c33); c.Add(c34); c.Add(c35); c.Add(c36);

        TextoElias.Add(s1); TextoElias.Add(s2); TextoElias.Add(s3); TextoElias.Add(s4); TextoElias.Add(s5); TextoElias.Add(s6); TextoElias.Add(s7); TextoElias.Add(s8);
        TextoElias.Add(s9); TextoElias.Add(s10); TextoElias.Add(s11); TextoElias.Add(s12); TextoElias.Add(s13); TextoElias.Add(s14); TextoElias.Add(s15); //TextoElias.Add(s16);
        TextoElias.Add(s17); TextoElias.Add(s18); TextoElias.Add(s19); TextoElias.Add(s20); TextoElias.Add(s21); TextoElias.Add(s22); TextoElias.Add(s23); 
        TextoElias.Add(s24); TextoElias.Add(s25); TextoElias.Add(s26); TextoElias.Add(s27); TextoElias.Add(s28); TextoElias.Add(s29);

        #endregion

        #region Escena2
        Esc2 = new List<string>();  //Escena 2

        Esc2.Add(x1); Esc2.Add(x2); Esc2.Add(b1); Esc2.Add(x3); Esc2.Add(b2); Esc2.Add(x4); Esc2.Add(b3); Esc2.Add(b4); Esc2.Add(b5);
        Esc2.Add(x5); Esc2.Add(x6); Esc2.Add(b6); Esc2.Add(x7); Esc2.Add(x8);

        c.Add(x1); c.Add(x2); c.Add(x3); c.Add(x4); c.Add(x5); c.Add(x6); c.Add(x7); c.Add(x8);

        TextoElias.Add(b1); TextoElias.Add(b2); TextoElias.Add(b3); TextoElias.Add(b4); TextoElias.Add(b5); TextoElias.Add(b6);
        #endregion

        #region Escena3
        Esc3 = new List<string>();  //Escena 3

        Esc3.Add(i1); Esc3.Add(i2); Esc3.Add(j1);

        c.Add(i1); c.Add(i2);
        TextoElias.Add(j1);
        #endregion

        #region Escena4
        Esc4 = new List<string>();  //Escena 4

        Esc4.Add(m1); Esc4.Add(m2); Esc4.Add(m3); Esc4.Add(m4); Esc4.Add(m5); Esc4.Add(m6); Esc4.Add(o1); Esc4.Add(o2);

        c.Add(m1); c.Add(m2); c.Add(m3); c.Add(m4); c.Add(m5); c.Add(m6);

        TextoElias.Add(o1); TextoElias.Add(o2);
        #endregion

        #region RFinal
        Esc5 = new List<string>();  //Escena 5

        Esc5.Add(a1); Esc5.Add(l1); Esc5.Add(a2); Esc5.Add(l2); Esc5.Add(a3); Esc5.Add(l3); Esc5.Add(l4); Esc5.Add(e1); Esc5.Add(e2); Esc5.Add(l5); Esc5.Add(e3); Esc5.Add(e4); Esc5.Add(a4);
        Esc5.Add(e5); Esc5.Add(a5); Esc5.Add(e6); Esc5.Add(a6); Esc5.Add(l6); Esc5.Add(e7); Esc5.Add(e8); Esc5.Add(a7); Esc5.Add(a8); Esc5.Add(e9); Esc5.Add(l7);
        Esc5.Add(d1); Esc5.Add(d2); Esc5.Add(e10); Esc5.Add(e11); Esc5.Add(e12); Esc5.Add(l8); Esc5.Add(d3); Esc5.Add(d4); Esc5.Add(d5); Esc5.Add(d6);
        Esc5.Add(e13); Esc5.Add(d7); Esc5.Add(d8); Esc5.Add(d9);

        c.Add(l1); c.Add(l2); c.Add(l3); c.Add(l4); c.Add(l5); c.Add(l6); c.Add(l7); c.Add(l8);

        TextoElias.Add(e1); TextoElias.Add(e2); TextoElias.Add(e3); TextoElias.Add(e4); TextoElias.Add(e5); TextoElias.Add(e6); TextoElias.Add(e7); TextoElias.Add(e8);
        TextoElias.Add(e9); TextoElias.Add(e10); TextoElias.Add(e11); TextoElias.Add(e12); TextoElias.Add(e13);

        TextoDios.Add(d1); TextoDios.Add(d2); TextoDios.Add(d3); TextoDios.Add(d4); TextoDios.Add(d5); TextoDios.Add(d6); TextoDios.Add(d7); TextoDios.Add(d8);
        TextoDios.Add(d9);

        TextoAnon.Add(a1); TextoAnon.Add(a2); TextoAnon.Add(a3); TextoAnon.Add(a4); TextoAnon.Add(a5); TextoAnon.Add(a6); TextoAnon.Add(a7); TextoAnon.Add(a8);
        #endregion

        //DIÁLOGOS OPCIONALES
        #region DialogoOP1
        EscOp1 = new List<string>();  //Escena op 1

        EscOp1.Add(v1); EscOp1.Add(v2); EscOp1.Add(v3); EscOp1.Add(w1); EscOp1.Add(w2); EscOp1.Add(w3); EscOp1.Add(v4); EscOp1.Add(w4); EscOp1.Add(v5); EscOp1.Add(w5); EscOp1.Add(v6);

        c.Add(v1); c.Add(v2); c.Add(v3); c.Add(v4); c.Add(v5); c.Add(v6);

        TextoElias.Add(w1); TextoElias.Add(w2); TextoElias.Add(w3); TextoElias.Add(w4); TextoElias.Add(w5);
        #endregion

        #region DialogoOP2
        EscOp2 = new List<string>();  //Escena op 2

        EscOp2.Add(g1); EscOp2.Add(f1); EscOp2.Add(g2); EscOp2.Add(f2); EscOp2.Add(f3); EscOp2.Add(g3); EscOp2.Add(f4);

        c.Add(f1); c.Add(f2); c.Add(f3); c.Add(f4);

        TextoElias.Add(g1); TextoElias.Add(g2); TextoElias.Add(g3);
        #endregion

        #region DiaologoOP3
        EscOp3 = new List<string>();  //Escena op 3

        EscOp3.Add(k1); EscOp3.Add(h1); EscOp3.Add(h2);

        c.Add(h1); c.Add(h2);

        TextoElias.Add(k1);

        #endregion

        #region DialogoOP4
        EscOp4 = new List<string>();  //Escena op 4

        EscOp4.Add(p1); EscOp4.Add(p2); EscOp4.Add(q1); EscOp4.Add(q2); EscOp4.Add(p3); EscOp4.Add(p4); EscOp4.Add(p5); EscOp4.Add(q3); EscOp4.Add(q4);
        EscOp4.Add(q5); EscOp4.Add(p6); EscOp4.Add(p7); EscOp4.Add(p8); EscOp4.Add(p9); EscOp4.Add(p10);

        c.Add(p1); c.Add(p2); c.Add(p3); c.Add(p4); c.Add(p5); c.Add(p6); c.Add(p7); c.Add(p8); c.Add(p9); c.Add(p10);

        TextoElias.Add(q1); TextoElias.Add(q2); TextoElias.Add(q3); TextoElias.Add(q4); TextoElias.Add(q5);
        #endregion

        EscOp5 = new List<string>();  //Escena op 5

        EscOp5.Add(r1); EscOp5.Add(r2); EscOp5.Add(t1); EscOp5.Add(t2);

        c.Add(r1); c.Add(r2);

        TextoElias.Add(t1); TextoElias.Add(t2);

        #region DialogoOP6
        EscOp6 = new List<string>();  //Escena op 6

        EscOp6.Add(z1); EscOp6.Add(u1);

        c.Add(u1);

        TextoElias.Add(z1);

        #endregion


    }

    // Update is called once per frame
    void Update()
    {
        if ( IniciarD1 &&!FinDialogo1)
        {
            EscenaDialogo.SetActive(true);
            TextoSala1();
            GM.modoJuego = 3;
            if (FinDialogo1)
            {
                GM.modoJuego = 0;
            }
        }
       
        if (IniDialogo2 == true && !FinDialogo2)
        {
            EscenaDialogo.SetActive(true);
            Texto3_3();
            GM.modoJuego = 3;
            if (FinDialogo2)
            {
                GM.modoJuego = 0;
            }
        }
        if (inicio4_4 && !FinDialogoOp1)
        {
            EscenaDialogo.SetActive(true);
            Op1();
            GM.modoJuego = 3;
            if (FinDialogoOp1)
            {
                GM.modoJuego = 0;
            }
        }
        if (IniOp2 && !FinDialogoOp2)
        {
            EscenaDialogo.SetActive(true);
            OpT2();
            GM.modoJuego = 3;
            if (FinDialogoOp2)
            {
                GM.modoJuego = 0;
            }
        }
        if (Op3 && !FinDialogoOp3)
        {
            EscenaDialogo.SetActive(true);
            OpT3();
            GM.modoJuego = 3;
            if (FinDialogoOp3)
            {
                GM.modoJuego = 0;
            }
        }
        if(D3 && !FinDialogo3)
        {
            EscenaDialogo.SetActive(true);
            S2D1();
            GM.modoJuego = 3;
            if (FinDialogo3)
            {
                GM.modoJuego = 0;
            }
        }
        if (D4 && !FinDialogo4)
        {
            EscenaDialogo.SetActive(true);
            S2D2();
            GM.modoJuego = 3;
            if (FinDialogo4)
            {
                GM.modoJuego = 0;
            }
        }
        if(OP4 && !FinDialogoOp4)
        {
            EscenaDialogo.SetActive(true);
            OPT4();
            GM.modoJuego = 3;
            if (FinDialogoOp4)
            {
                GM.modoJuego = 0;
            }
        }

        if (OP6 && !FinDialogoOp6)
        {
            EscenaDialogo.SetActive(true);
            OPT6();
            GM.modoJuego = 3;
            if (FinDialogoOp6)
            {
                GM.modoJuego = 0;
            }
        }
        if (OP5 && !FinDialogoOp5)
        {
            EscenaDialogo.SetActive(true);
            OPT5();
            GM.modoJuego = 3;
            if (FinDialogoOp5)
            {
                GM.modoJuego = 0;
            }
        }
        if (FIN && !FinDialogo5)
        {
            EscenaDialogo.SetActive(true);
            TFinal();
            GM.modoJuego = 3;
            if (FinDialogo5)
            {
                GM.modoJuego = 0;
            }
        }
        if (FinDialogo5)
        {
            SceneManager.LoadScene(12);
        }


    }

    public void TextoSala1()
    {
        if (tLeft > tText)
        {
            if (puedePasar)
            {
                if (Sala1.Count != y)
                {
                    t.text = Sala1[y];
                    //Buscar personaje
                    bool esc = false;
                    for (int i = 0; i < c.Count; i++)
                    {
                        if (Sala1[y] == c[i])
                        {
                            esc = true;
                        }
                    }
                    if (esc)
                    {
                        nombre.text = "Clavis";
                        imagen.sprite = canv;
                    }
                    else
                    {
                        nombre.text = "Elias";
                        imagen.sprite = elias;
                    }

                    y++;
                    tLeft = 0;
                }
                else if (y == Sala1.Count)
                {
                    GM.modoJuego = 0;
                    FinDialogo1 = true;
                    EscenaDialogo.SetActive(false);
                }
            }

          
        }

        tLeft += Time.deltaTime;
        puedePasar = false;
    }

    public void Texto3_3(){

        if (tLeft > tText)
        {
            if (puedePasar)
            {
                if (Esc2.Count != x)
                {
                    t.text = Esc2[x];
                    //Buscar personaje
                    bool esc = false;
                    for (int i = 0; i < c.Count; i++)
                    {
                        if (Esc2[x] == c[i])
                        {
                            esc = true;
                        }
                    }
                    if (esc)
                    {
                        nombre.text = "Clavis";
                        imagen.sprite = canv;
                    }
                    else
                    {
                        nombre.text = "Elias";
                        imagen.sprite = elias;
                    }

                    x++;
                    tLeft = 0;
                }
                else if (x == Esc2.Count)
                {
                    GM.modoJuego = 0;
                    FinDialogo2 = true;
                    EscenaDialogo.SetActive(false);
                }


            }

          
        }

        tLeft += Time.deltaTime; puedePasar = false;
    }

    public void Op1()
    {
        if (tLeft > tText)
        {
            if (puedePasar)
            {
                if (EscOp1.Count != op1)
                {
                    t.text = EscOp1[op1];
                    //Buscar personaje
                    bool esc = false;
                    for (int i = 0; i < c.Count; i++)
                    {
                        if (EscOp1[op1] == c[i])
                        {
                            esc = true;
                        }
                    }
                    if (esc)
                    {
                        nombre.text = "Clavis";
                        imagen.sprite = canv;
                    }
                    else
                    {
                        nombre.text = "Elias";
                        imagen.sprite = elias;
                    }

                    op1++;
                    tLeft = 0;
                }

                else if (op1 == EscOp1.Count)
                {
                    GM.modoJuego = 0;
                    FinDialogoOp1 = true;
                    EscenaDialogo.SetActive(false);
                }

            }

         
        }

        tLeft += Time.deltaTime; puedePasar = false;
    }

    public void OpT2()
    {
        if (tLeft > tText)
        {
            if (puedePasar)
            {
                if (EscOp2.Count != Op2)
                {
                    t.text = EscOp2[Op2];
                    //Buscar personaje
                    bool esc = false;
                    for (int i = 0; i < c.Count; i++)
                    {
                        if (EscOp2[Op2] == c[i])
                        {
                            esc = true;
                        }
                    }
                    if (esc)
                    {
                        nombre.text = "Clavis";
                        imagen.sprite = canv;
                    }
                    else
                    {
                        nombre.text = "Elias";
                        imagen.sprite = elias;
                    }

                    Op2++;
                    tLeft = 0;
                }

                else if (Op2 == EscOp2.Count)
                {
                    GM.modoJuego = 0;
                    FinDialogoOp2 = true;
                    EscenaDialogo.SetActive(false);
                }

            }

           
        }

        tLeft += Time.deltaTime; puedePasar = false;
    }

    public void OpT3()
    {
        if (tLeft > tText)
        {
            if (puedePasar)
            {
                if (EscOp3.Count != op3)
                {
                    t.text = EscOp3[op3];
                    //Buscar personaje
                    bool esc = false;
                    for (int i = 0; i < c.Count; i++)
                    {
                        if (EscOp3[op3] == c[i])
                        {
                            esc = true;
                        }
                    }
                    if (esc)
                    {
                        nombre.text = "Clavis";
                        imagen.sprite = canv;
                    }
                    else
                    {
                        nombre.text = "Elias";
                        imagen.sprite = elias;
                    }

                    op3++;
                    tLeft = 0;
                }
               else if (op3 == EscOp3.Count)
                {
                    GM.modoJuego = 0;
                    FinDialogoOp3 = true;
                    EscenaDialogo.SetActive(false);
                }

            }

           
        }

        tLeft += Time.deltaTime; puedePasar = false;
    }

    public void S2D1()
    {
        if (tLeft > tText)
        {
            if (puedePasar)
            {
                if (Esc3.Count != di3)
                {
                    t.text = Esc3[di3];
                    //Buscar personaje
                    bool esc = false;
                    for (int i = 0; i < c.Count; i++)
                    {
                        if (Esc3[di3] == c[i])
                        {
                            esc = true;
                        }
                    }
                    if (esc)
                    {
                        nombre.text = "Clavis";
                        imagen.sprite = canv;
                    }
                    else
                    {
                        nombre.text = "Elias";
                        imagen.sprite = elias;
                    }

                    di3++;
                    tLeft = 0;
                }

                else if (di3 == Esc3.Count)
                {
                    GM.modoJuego = 0;
                    FinDialogo3 = true;
                    EscenaDialogo.SetActive(false);
                }

            }

         
        }

        tLeft += Time.deltaTime; puedePasar = false;
    }

    public void S2D2()
    {
        if (tLeft > tText)
        {
            if (puedePasar)
            {
                if (Esc4.Count != di4)
                {
                    t.text = Esc4[di4];
                    //Buscar personaje
                    bool esc = false;
                    for (int i = 0; i < c.Count; i++)
                    {
                        if (Esc4[di4] == c[i])
                        {
                            esc = true;
                        }
                    }
                    if (esc)
                    {
                        nombre.text = "Clavis";
                        imagen.sprite = canv;
                    }
                    else
                    {
                        nombre.text = "Elias";
                        imagen.sprite = elias;
                    }

                    di4++;
                    tLeft = 0;
                }
                else if (di4 == Esc4.Count)
                {
                    GM.modoJuego = 0;
                    FinDialogo4 = true;
                    EscenaDialogo.SetActive(false);
                }
            }

         
        }

        tLeft += Time.deltaTime; puedePasar = false;
    }

    public void OPT4()
    {
        if (tLeft > tText)
        {
            if (puedePasar)
            {
                if (EscOp4.Count != op4)
                {
                    t.text = EscOp4[op4];
                    //Buscar personaje
                    bool esc = false;
                    for (int i = 0; i < c.Count; i++)
                    {
                        if (EscOp4[op4] == c[i])
                        {
                            esc = true;
                        }
                    }
                    if (esc)
                    {
                        nombre.text = "Clavis";
                        imagen.sprite = canv;
                    }
                    else
                    {
                        nombre.text = "Elias";
                        imagen.sprite = elias;
                    }

                    op4++;
                    tLeft = 0;
                }
                else if (op4 == EscOp4.Count)
                {
                    GM.modoJuego = 0;
                    FinDialogoOp4= true;
                    EscenaDialogo.SetActive(false);
                }
            }


        }

        tLeft += Time.deltaTime; puedePasar = false;
    }

    public void OPT5()
    {
        if (tLeft > tText)
        {
            if (puedePasar)
            {
                if (EscOp5.Count != op5)
                {
                    t.text = EscOp5[op5];
                    //Buscar personaje
                    bool esc = false;
                    for (int i = 0; i < c.Count; i++)
                    {
                        if (EscOp5[op5] == c[i])
                        {
                            esc = true;
                        }
                    }
                    if (esc)
                    {
                        nombre.text = "Clavis";
                        imagen.sprite = canv;
                    }
                    else
                    {
                        nombre.text = "Elias";
                        imagen.sprite = elias;
                    }

                    op5++;
                    tLeft = 0;
                }
                else if (op5 == EscOp5.Count)
                {
                    GM.modoJuego = 0;
                    FinDialogoOp5 = true;
                    EscenaDialogo.SetActive(false);
                }
            }


        }

        tLeft += Time.deltaTime; puedePasar = false;
    }

    public void OPT6()
    {
        if (tLeft > tText)
        {
            if (puedePasar)
            {
                if (EscOp6.Count != op6)
                {
                    t.text = EscOp6[op6];
                    //Buscar personaje
                    bool esc = false;
                    for (int i = 0; i < c.Count; i++)
                    {
                        if (EscOp6[op6] == c[i])
                        {
                            esc = true;
                        }
                    }
                    if (esc)
                    {
                        nombre.text = "Clavis";
                        imagen.sprite = canv;
                    }
                    else
                    {
                        nombre.text = "Elias";
                        imagen.sprite = elias;
                    }

                    op6++;
                    tLeft = 0;
                }
                else if (op6 == EscOp6.Count)
                {
                    GM.modoJuego = 0;
                    FinDialogoOp6 = true;
                    EscenaDialogo.SetActive(false);
                }
            }


        }

        tLeft += Time.deltaTime; puedePasar = false;
    }

    public void TFinal()
    {
        if (tLeft > tText)
        {
            if (puedePasar)
            {
                if (Esc5.Count != fn)
                {
                    t.text = Esc5[fn];
                    //Buscar personaje
                    bool esc = false;
                    bool esD = false;
                    bool esAnon = false;
                    for (int i = 0; i < c.Count; i++)
                    {
                        if (Esc5[fn] == c[i])
                        {
                            esc = true;
                        }
                    }
                    for (int i = 0; i < TextoDios.Count; i++)
                    {
                        if (Esc5[fn] == TextoDios[i])
                        {
                            esD = true;
                        }
                    }
                    for (int i = 0; i < TextoAnon.Count; i++)
                    {
                        if (Esc5[fn] == TextoAnon[i])
                        {
                            esAnon = true;
                        }
                    }

                    if (esc)
                    {
                        nombre.text = "Clavis";
                        imagen.sprite = canv;
                    }
                    else if(esD)
                    {
                        nombre.text = "DIOS";
                        imagen.sprite = dios;
                    }
                    else if (esAnon)
                    {
                        nombre.text = "??";
                        imagen.sprite = anom;
                    }
                    else
                    {
                        nombre.text = "Elias";
                        imagen.sprite = elias;
                    }

                    fn++;
                    tLeft = 0;
                }
                else if (fn == Esc5.Count)
                {
                    GM.modoJuego = 0;
                    FinDialogo5 = true;
                    EscenaDialogo.SetActive(false);
                }
            }


        }

        tLeft += Time.deltaTime; puedePasar = false;
    }
}

