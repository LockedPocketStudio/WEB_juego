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

   //Primera escena s=elias c=clavis
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

    //Segunda escena x= Clavis b= Elías
    string x1 = "Vaya, vaya ... pero si has conseguido llegar hasta la primera escalera. ¡Quién lo diría Emilio!";
    string x2 = "Cómo consiga llegar hasta el jefe me voy a llevar una buena bronca..."; //cambiar color
    string b1 = "Elías ... me llamo Elías";
    string x3 = "¡Eso eso! Es verdad, Eli, disculpa jejeje.";
    string b2 = "... ... Elías";
    string x4 = "Bueno, a lo que iba ¿Qué tal lo estás pasando? Yo lo estoy pasando de maravilla viéndote ... hablar con mis amigos. Son muy divertidos, ¿a que sí?";
    string b3 = "Creo que no tenemos el mismo concepto de divertido...¡¿Por qué no me avisaste de que me iban a disparar?! ¡Este camino es un infierno! ¡Cada vez que entro en una sala me encuentro a tus amiguitos disparándome!";
    string x5 = "Bueno hombre Esteban, tampoco hay que ponerse así. Ya te avisé de que eran un poco raritos. Además, no tiene ninguna gracia si no te lo pongo un poco difícil ¡hay que trabajar duro!";
    string b4 = "¡Que me llamo Elías!";
    string x6 = "¡Venga chaval, mucho ánimo! El siguiente anillo será un poco más difícil, para añadirle emoción";
    string x7 = "Espero que no lo consigas superar..."; //Cambiar color

    public bool FinDialogo2 = false;

    //Tercera escena i=clavis j=elías
    string i1 = "¡Bienvenido al siguiente anillo! Como puedes ver, en este hace un poco más de frío, pero confío en que mis amigos harán que te sientas arropado. Nos vemos después Eliseo";
    string j1 = "...Elías";

    public bool FinDialogo3 = false;

    //Cuarta escena m=clavis o=elias
    string m1 = "¡Anda Enrique! No me esperaba que llegaras hasta aquí, no te voy a mentir...";
    string m2 = "...";
    string m3 = "...";
    string m4 = "Bueno, supongo que entonces puedes subir a hablar con el jefe. Eso sí, déjame adelantarme para avisarle de que tiene visita, no es muy fan de las sorpresas que digamos.";
    string m5 = "Por Dios, espero que no se enfade mucho..."; //Cambiar color
    string o1 = "... No me puedo creer que todavía no se haya aprendido mi nombre";

    public bool FinDialogo4 = false;

    //Quinta escena --- Escena final a=anonimo d=dios e=elias l=clavis
    string a1 = "Clavis...";
    string l1 = "¡No es culpa mía!";
    string a2 = "¡POR SUPUESTO QUE LO ES! ¿UN TRATO CON UN HUMANO?¿EN QUÉ PIENSA ESA CABEZA QUE TE HAN DADO?";
    string l2 = "OYE YO SOLO HAGO MI TRABAJO";
    string a3 = "TU TRABAJO ES TORTURARLOS NO TRAERMELOS.";
    string l3 = "¡Échale la culpa a tus juguetes rotos! Ellos no han sido capaces de mantenerlo a raya. Además, ¿preferías que le dejase ahí lamentándose? Aburridísimo. No pensé que Evar-";
    string e1 = "¡Elías! Me llamo Elías.";
    string e2 = "Y he cumplido mi parte del trato, ahora tengo derecho a una charla con el jefe.";
    string l4 = "Ay Dios...";
    string e3 = "Mire no quiero molestarle demasiado, simplemente quiero pedirle que me sacase de aquí y me mande al Cielo. Claramente ha habido una confusión, exijo saber qué le hace pensar que merezco ser torturado.";
    string a4 = "¿Al Cielo? Mejor te hago yo una pregunta, ¿qué te hace pensar que mereces ir al cielo?";
    string e4 = "Pues... No estoy seguro Señor... ¡Pero desde luego nunca hice nada como para acabar aquí!";
    string a5 = "Ya... ¿y qué es “aquí”?";
    string e5 = "¡El infierno obviamente! Está lleno de monstruos que quieren eliminarme, está oscuro, hace calor y huele que apesta.";
    string a6 = "PffffttJAJAJAJAJAJAJAJAJAJAJAJAJ OYES ESO CLAVIS";
    string l5 = "JAJAJAJJAJAJAJAJAJJAJAA TE LO DIJEE";
    string e6 = "...";
    string e7 = "¿Qué es tan gracioso?";
    string a7 = "Ahhh... Realmente no sabes nada chico. Este lugar donde ahora te encuentras...";
    string a8 = "Esto es el Cielo";
    string e8 = "Desde cuándo Satán reina el cielo a ver.";
    string l6 = "no hace más que liarla...";    //Cambiar color
    string d1 = "Yo soy el mismísimo Dios que tanto adoráis.";
    string d2 = "¿A qué has venido entonces? Si realmente eras un hombre bueno este es tu sitio, ¿de qué te quejas?";
    string e9 = "Oh... Dios";
    string e10 = "D- discúlpeme Señor, no pretendía ofenderos. Perdóneme por favor. E- Es solo que... no me imaginaba el Cielo así... Desde que he llegado no han parado de sucederme cosas malas...";
    string e11 = "Y este lugar no se parece en nada al Paraíso...";
    string l7 = "Deberías cuidar tus palabras Emanuel... hehehe";
    string d3 = "... ¿no se llamaba Elías?";  //cambiar color
    string d4 = "Bueno chico siento decirte que la imagen que tenéis los humanos del Cielo no es real. ¡No sé en qué momento se inventaron semejante chorrada! JAJAJAJA";
    string d5 = "Yo la verdad que dejé de prestaros atención hace bastantes siglos, me parece más entretenido ver cómo os desenvolvéis por aquí.";
    string d6 = "Espero que no estés decepcionado, al fin y al cabo, estás en el Cielo y has conocido al mismísimo Dios.";
    string e12 = "Entonces... ¿fue usted quién me puso tan difícil el camino hasta aquí? ¿ha estado observándome todo este tiempo?";
    string d7 = "¡Así es! Debo decirte que has sido uno de los más valientes que ha aparecido por aquí en mucho tiempo.¡Has dado un espectáculo fantástico!";
    string d8 = "Y ahora, si me disculpas, quiero ver al siguiente que acaba de llegar ¡a ver qué tal se le da el camino a este ancianito!";
    string d9 = "Elías, ¡bienvenido al cielo!";

    public bool FinDialogo5 = false;


    //DIALOGOS OPCIONALES
    //SALA 4_4 DEL ANILLO 1 V=clavis w= elias
    string v1 = "¡Hola Ernesto! ¡Qué bien verte por aquí!";
    string v2 = "Mira te he preparado esta pequeña sala de descanso, que por que veo has tomado el camino largo jajajaj Así que nada, aprovecha y descansas un ratillo, ¡cuando quieras seguimos!";
    string w1 = "Um... Gracias, pero me llamo Elías.";
    string w2 = "Por cierto, tus amigos están siendo un poco ... antipáticos. ¿Podrías decirles que dejaran de dispararme? Por favor.";
    string w3 = "Me defiendo como puedo pero a veces lo ponen realmente difícil.";
    string v3 = "¡Ah sí! Perdona es que Pesadilla está empezando a competir en tiro al plato y tiene que entrenar mucho jajajaj";
    string w4 = "¿Pesadilla?";
    string v4 = "Sí, claro. Ese es el apodo de mi amigo. El que es así pequeñito y va volando por ahí";
    string w5 = "Ya veo ya... Muy apropiado";
    string v5 = "Bueno te dejo descansar tranquilo. Cuando quieras seguir me avisas";

    public bool FinDialogoOp1 = false;

    //SALA 3_2 DEL ANILLO 1 f=clavis g=elias
    string g1 = "¡¿Clavis cuánto queda para la escalera?! ¡No aguanto más!";
    string f1 = "¡Ay Eloy!, tranquilízate...";
    string g2 = "Clavis me llamo Elías... que siempre te equivocas";
    string f2 = "Venga anda, para que se te haga más corto lo que queda voy a dejarte un pequeño regalo en el cofre. Eso sí, más te vale haberte esforzado porque si no el cofre no se abrirá.";
    string g3 = "¡Pero bueno! ¡Claro que me he esforzado! ¿O es que no me ves?";
    string f3 = "Ve a por tu recompensa entonces y sigue cuando estés listo, que ya queda poco para la escalera";

    public bool FinDialogoOp2 = false;

    //SALA 1_3 DEL ANILLO 1 h=clavis k=elías
    string k1 = "¿Qué es esto Clavis? ¿Una sala tranquila? ¡Por fin!";
    string h1 = "Bueno hombre tú también eres un poco exagerado, ¡ni que te estuvieras esforzando tanto!";
    string h2 = "Además no te puedes quejar, que en esta sala te he dejado un regalito. Mira a ver en el cofre anda";

    public bool FinDialogoOp3 = false;

    //SALA 3_1 DEL ANILLO 2 p=clavis q=elias
    string p1 = "¡Cuánto tiempo sin verte Eduardo! ¿Qué tal vas? Ya queda poco, pero esta parte es la más difícil jejejeje";
    string p2 = "y la más divertida para mí";   //cambiar color
    string q1 = "... me tiene que estar vacilando con esto del nombre";   //Cambiar de color
    string q2 = "Clavis, me llamo Elías, ya te lo he dicho varias veces. Si no te importa voy a aprovechar para descansar aquí un poco, que estoy muerto.";
    string p3 = "Sí, muerto sí que estás jajajaj. Bueno pues, mientras descansas, ¿por qué no aprovechas y me cuentas algo de ti? ¿Cuántos años tenías? ¿A qué te dedicabas?";
    string p4 = "... aunque seguro que no tienes nada interesante que contar, pareces un poco pringado jajajaj"; //cambiar color
    string q3 = "¿Qué decías? ¿Sobre mí? Bueno no sé, teng- tenía 18 años y trabajaba en un Timbre Burrito TM , ya sabes, hay que ahorrar para pagar el viaje a Mallorca... A todo esto ¿tú cómo has acabado aquí?";
    string q4 = "A todo esto ¿tú cómo has acabado aquí?";
    string p5 = "Uf Bachillerato, que intenso. Yo morí hace mucho. Cuando llegué aquí le caí bien al jefe y he sido una de sus “personas” de confianza desde entonces. Dice que hay poca gente como yo aquí.";
    string p6 = "por lo visto aquí solo viene gente buena y aburrida"; //cambiar color
    string p7 = "Así que nada, empecé a echarle una mano con tareas importantes, como recibir a los recién llegados como tú. Bueno yo creo que ya has descansado lo suficiente Epicuro ¡A seguir buscando!";

    public bool FinDialogoOp4 = false;

    //SALA 2_1 DEL ANILLO 2 r=clavis t=elias
    string r1 = "Espero que estés contento Eusebio, ya estás muy cerca del final.¡Cualquiera lo diría eh! ¡Esto ya empezaba a parecer un castigo eterno!";
    string r2 = "aunque para castigo eterno el que me va a caer a mí por dejarte llegar hasta aquí";    //cambiar color
    string t1 = "...";
    string t2 = "Gracias Clavis, pero mi nombre es Elías.";

    public bool FinDialogoOp5 = false;

    //SALA 1_3 DEL ANILLO 2 u=clavis z=elías
    string z1 = "Uf menos mal, otra sala tranquila. Ya no podía más.";
    string u1 = "Y además te he dejado un regalo y todo, para que luego digas que no te trato bien eh...";

    public bool FinDialogoOp6 = false;


    public List<string> TextoElias;
    public List<string> c;
    public List<string> TextoAnon;
    public List<string> TextoDios;

    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();

        TextoElias = new List<string>();
        c= new List<string>();
        TextoDios = new List<string>();
        TextoAnon = new List<string>();

        //DIALOGOS OBLIGATORIOS
        //Escena 1
        Sala1 = new List<string>();
        
        Sala1.Add(s1);
        Sala1.Add(s2);
        Sala1.Add(s3);
        Sala1.Add(s4);
        Sala1.Add(c1); Sala1.Add(s5); Sala1.Add(c2); Sala1.Add(s6); Sala1.Add(c3); Sala1.Add(s7); Sala1.Add(c4); Sala1.Add(s8); Sala1.Add(c5); Sala1.Add(s9); Sala1.Add(c6); Sala1.Add(s10); Sala1.Add(c7); Sala1.Add(s11); Sala1.Add(c8); Sala1.Add(s12);
        Sala1.Add(s13); Sala1.Add(s14); Sala1.Add(c9); Sala1.Add(s15); Sala1.Add(c10); Sala1.Add(s16); Sala1.Add(c11); Sala1.Add(s17); Sala1.Add(c12); Sala1.Add(s18); Sala1.Add(c13); Sala1.Add(c14); Sala1.Add(c15); Sala1.Add(c16); Sala1.Add(s19);
        Sala1.Add(c17); Sala1.Add(s20); Sala1.Add(c18); Sala1.Add(s21); Sala1.Add(s22); Sala1.Add(c19); Sala1.Add(c20); Sala1.Add(c21); Sala1.Add(c22); Sala1.Add(c23); Sala1.Add(c24); Sala1.Add(c25); Sala1.Add(c26);
     
        c.Add(c1); c.Add(c2); c.Add(c3); c.Add(c4);  c.Add(c5); c.Add(c6);  c.Add(c7); c.Add(c8);
        c.Add(c9);  c.Add(c10);  c.Add(c11);  c.Add(c12);  c.Add(c13); c.Add(c14); c.Add(c15); c.Add(c16); 
        c.Add(c17);  c.Add(c18);   c.Add(c19); c.Add(c20); c.Add(c21); c.Add(c22); c.Add(c23); c.Add(c24); c.Add(c25); c.Add(c26);

        TextoElias.Add(s1); TextoElias.Add(s2); TextoElias.Add(s3); TextoElias.Add(s4); TextoElias.Add(s5); TextoElias.Add(s6); TextoElias.Add(s7); TextoElias.Add(s8); 
        TextoElias.Add(s9); TextoElias.Add(s10); TextoElias.Add(s11); TextoElias.Add(s12); TextoElias.Add(s13); TextoElias.Add(s14); TextoElias.Add(s15); TextoElias.Add(s16);
        TextoElias.Add(s17); TextoElias.Add(s18); TextoElias.Add(s19); TextoElias.Add(s20); TextoElias.Add(s21); TextoElias.Add(s22);


        Esc2 = new List<string>();  //Escena 2

        Esc2.Add(x1); Esc2.Add(x2); Esc2.Add(b1); Esc2.Add(x3); Esc2.Add(b2); Esc2.Add(x4); Esc2.Add(b3); Esc2.Add(x5); Esc2.Add(b4); Esc2.Add(x6); Esc2.Add(x7);

        c.Add(x1); c.Add(x2); c.Add(x3); c.Add(x4); c.Add(x5); c.Add(x6); c.Add(x7);

        TextoElias.Add(b1); TextoElias.Add(b2); TextoElias.Add(b3); TextoElias.Add(b4); 


        Esc3 = new List<string>();  //Escena 3

        Esc3.Add(i1); Esc3.Add(j1);

        c.Add(i1);
        TextoElias.Add(j1);


        Esc4 = new List<string>();  //Escena 4

        Esc4.Add(m1); Esc4.Add(m2); Esc4.Add(m3); Esc4.Add(m4); Esc4.Add(m5); Esc4.Add(o1);

        c.Add(m1); c.Add(m2); c.Add(m3); c.Add(m4); c.Add(m5);     

        TextoElias.Add(o1);


        Esc5 = new List<string>();  //Escena 5

        Esc5.Add(a1); Esc5.Add(l1); Esc5.Add(a2); Esc5.Add(l2); Esc5.Add(a3); Esc5.Add(l3); Esc5.Add(e1); Esc5.Add(e2); Esc5.Add(l4); Esc5.Add(e3); Esc5.Add(a4);
        Esc5.Add(e4); Esc5.Add(a5); Esc5.Add(e5); Esc5.Add(a6); Esc5.Add(l5); Esc5.Add(e6); Esc5.Add(e7); Esc5.Add(a7); Esc5.Add(a8); Esc5.Add(e8); Esc5.Add(l6);
        Esc5.Add(d1); Esc5.Add(d2); Esc5.Add(e9); Esc5.Add(e10); Esc5.Add(e11); Esc5.Add(l7); Esc5.Add(d3); Esc5.Add(d4); Esc5.Add(d5); Esc5.Add(d6);
        Esc5.Add(e12); Esc5.Add(d7); Esc5.Add(d8); Esc5.Add(d9);

        c.Add(l1); c.Add(l2); c.Add(l3); c.Add(l4); c.Add(l5); c.Add(l6); c.Add(l7);

        TextoElias.Add(e1); TextoElias.Add(e2); TextoElias.Add(e3); TextoElias.Add(e4); TextoElias.Add(e5); TextoElias.Add(e6); TextoElias.Add(e7); TextoElias.Add(e8);
        TextoElias.Add(e9); TextoElias.Add(e10); TextoElias.Add(e11); TextoElias.Add(e12);

        TextoDios.Add(d1); TextoDios.Add(d2); TextoDios.Add(d3); TextoDios.Add(d4); TextoDios.Add(d5); TextoDios.Add(d6); TextoDios.Add(d7); TextoDios.Add(d8);
        TextoDios.Add(d9);

        TextoAnon.Add(a1); TextoAnon.Add(a2); TextoAnon.Add(a3); TextoAnon.Add(a4); TextoAnon.Add(a5); TextoAnon.Add(a6); TextoAnon.Add(a7); TextoAnon.Add(a8);


        //DIÁLOGOS OPCIONALES
        EscOp1 = new List<string>();  //Escena op 1

        EscOp1.Add(v1); EscOp1.Add(v2); EscOp1.Add(w1); EscOp1.Add(w2); EscOp1.Add(w3); EscOp1.Add(v3); EscOp1.Add(w4); EscOp1.Add(v4); EscOp1.Add(w5); EscOp1.Add(v5);

        c.Add(v1); c.Add(v2); c.Add(v3); c.Add(v4); c.Add(v5);

        TextoElias.Add(w1); TextoElias.Add(w2); TextoElias.Add(w3); TextoElias.Add(w4); TextoElias.Add(w5);


        EscOp2 = new List<string>();  //Escena op 2

        EscOp2.Add(g1); EscOp2.Add(f1); EscOp2.Add(g2); EscOp2.Add(f2); EscOp2.Add(g3); EscOp2.Add(f3);

        c.Add(f1); c.Add(f3); c.Add(f3);

        TextoElias.Add(g1); TextoElias.Add(g2); TextoElias.Add(g3);


        EscOp3 = new List<string>();  //Escena op 3

        EscOp3.Add(k1); EscOp3.Add(h1); EscOp3.Add(h2);

        c.Add(h1); c.Add(h2);

        TextoElias.Add(k1);


        EscOp4 = new List<string>();  //Escena op 4

        EscOp4.Add(p1); EscOp4.Add(p2); EscOp4.Add(q1); EscOp4.Add(q2); EscOp4.Add(p3); EscOp4.Add(p4); EscOp4.Add(q3); EscOp4.Add(q4); EscOp4.Add(p5); EscOp4.Add(p6);
        EscOp4.Add(p7);

        c.Add(p1); c.Add(p2); c.Add(p3); c.Add(p4); c.Add(p5); c.Add(p6); c.Add(p7);

        TextoElias.Add(q1); TextoElias.Add(q2); TextoElias.Add(q3); TextoElias.Add(q4);


        EscOp5 = new List<string>();  //Escena op 5

        EscOp5.Add(r1); EscOp5.Add(r2); EscOp5.Add(t1); EscOp5.Add(t2);

        c.Add(r1); c.Add(r2);

        TextoElias.Add(t1); TextoElias.Add(t2);


        EscOp6 = new List<string>();  //Escena op 6

        EscOp6.Add(z1); EscOp6.Add(u1);

        c.Add(u1);

        TextoElias.Add(z1);
        

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
