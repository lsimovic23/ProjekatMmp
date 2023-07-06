using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{

    int firstValue, secondValue, pom, answer, option1, option2, score;

    public Animator AnimatorBackground, AnimatorSolution;
    public Text FirstNumber, SecondNumber, Sign, Alt1, Alt2, Alt3, AnswerContains;
    public Texture textureSuma, textureSubs, texutreMult, textureDiv, textureLet;
    public Sprite SpriteYes, SpriteNo, SpriteTransp;
    public string pomoc, VarSign;
    public GameObject canvas, Yes_No1, Yes_No2, Yes_No3;
    public Transform Balloon;
    public AudioSource ComAudio;
    public AudioClip Yes, No, Music;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            CalculatorFunction("sum"); //ako s onda sabiranje
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            CalculatorFunction("subs"); //ako r onda oduzmanje
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            CalculatorFunction("mult"); //ako m onda mnozenje
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            CalculatorFunction("div"); //ako d onda deljenje
        }
    }

    public void functionSum()
    {
        pomoc = "sum";
        Output();
    }

    public void functionSub()
    {
        pomoc = "subs";
        Output();
    }

    public void functionMul()
    {
        pomoc = "mult";
        Output();
    }

    public void functionDiv()
    {
        pomoc = "div";
        Output();
    }

    public void functionLet()
    {
        pomoc = "let";
        Output();
    }

    private void Output()
    { 
        AnimatorBackground = GameObject.Find("Background").GetComponent<Animator>();
        AnimatorBackground.Play("Output");
    }

    public void cameraMove()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(24.16f, 0, -10f);
        
        if(pomoc == "sum")
        {
            CalculatorFunction("sum"); GameObject.Find("Background Operation").GetComponent<Renderer>().material.mainTexture = textureSuma;
            canvas.SetActive(true);
        }

        if (pomoc == "subs")
        {
            CalculatorFunction("subs"); GameObject.Find("Background Operation").GetComponent<Renderer>().material.mainTexture = textureSubs;
            canvas.SetActive(true);
        }

        if (pomoc == "mult")
        {
            CalculatorFunction("mult"); GameObject.Find("Background Operation").GetComponent<Renderer>().material.mainTexture = texutreMult;
            canvas.SetActive(true);
        }

        if (pomoc == "div")
        {
            CalculatorFunction("div"); GameObject.Find("Background Operation").GetComponent<Renderer>().material.mainTexture = textureDiv;
            canvas.SetActive(true);
        }

        if (pomoc == "let")
        {
            CalculatorFunction("div"); GameObject.Find("Background Operation").GetComponent<Renderer>().material.mainTexture = textureLet;
            canvas.SetActive(true); 
            ReturnMenu();
        }

    }


    public void CalculatorFunction(string operation)
    {
        ResetValues();

        firstValue = Random.Range(1, 10); //daje 2 rando vrednosi
        secondValue = Random.Range(1, 10);

        if(firstValue - secondValue < 0) //ako je prva manja od druge da ih zamenimo jer npr oduzimanje necemo sa negativnim
        {
            pom = secondValue;
            secondValue = firstValue;
            firstValue = pom;
        }

        if(operation == "sum")
        {
            answer = firstValue + secondValue;
            VarSign = "sum";
        }

        if (operation == "subs")
        {
            answer = firstValue - secondValue;
            VarSign = "subs";
        }

        if (operation == "mult")
        {
            answer = firstValue * secondValue;
            VarSign = "mult";
        }

        if (operation == "div")
        {
            answer = firstValue / secondValue;
            VarSign = "div";
        }

        Debug.Log("1. value: " + firstValue + " 2. value: " + secondValue + " Answer: " + answer); //ispisuje u konzoli sta se desava

        FirstNumber.text = firstValue.ToString();
        SecondNumber.text = secondValue.ToString();
        
        if(VarSign == "sum")
        {
            Sign.text = "+";
        }

        if (VarSign == "subs")
        {
            Sign.text = "-";
        }

        if (VarSign == "mult")
        {
            Sign.text = "*";
        }

        if (VarSign == "div")
        {
            Sign.text = "/";
        }

        //First alternative

        pom = Random.Range(2, 20);
        while (pom == answer)
        {
            pom = Random.Range(2, 20);
        }
        option1 = pom;
        

        //Second alternative

        pom = Random.Range(2, 20);
        while ((pom == answer) || (pom == option1))
        {
            pom = Random.Range(2, 20);
        }
        option2 = pom;

        Debug.Log("Alternative:" + option1 + " - " + option2 + " - " + answer);



        //Ordering the alternatives

        pom = Random.Range(1, 6);
        if (pom == 1)
        {
            Alt1.text = answer.ToString(); Alt2.text = option1.ToString(); Alt3.text = option2.ToString();
        }

        if (pom == 2)
        {
            Alt1.text = answer.ToString(); Alt2.text = option2.ToString(); Alt3.text = option1.ToString();
        }

        if (pom == 3)
        {
            Alt1.text = option1.ToString(); Alt2.text = answer.ToString(); Alt3.text = option2.ToString();
        }

        if (pom == 4)
        {
            Alt1.text = option1.ToString(); Alt2.text = option2.ToString(); ; Alt3.text = answer.ToString();
        }

        if (pom == 5)
        {
            Alt1.text = option2.ToString(); Alt2.text = answer.ToString(); ; Alt3.text = option1.ToString();
        }

        if (pom == 6)
        {
            Alt1.text = option2.ToString(); Alt2.text = option1.ToString(); ; Alt3.text = answer.ToString();
        }
    }


    public void Alt_1_action()
    {
        Debug.Log(" alt 1 ");
        if ( Alt1.text == answer.ToString())
        {
            Yes_No1.GetComponent<Image>().sprite = SpriteYes;
            Find();
        }
        else
        {
            Yes_No1.GetComponent<Image>().sprite = SpriteNo;
            Fail();
        }
    }

    public void Alt_2_action()
    {
        if (Alt2.text == answer.ToString())
        {
            Yes_No2.GetComponent<Image>().sprite = SpriteYes;
            Find();
        }
        else
        {
            Yes_No2.GetComponent<Image>().sprite = SpriteNo;
            Fail();
        }
    }

    public void Alt_3_action()
    {
        if (Alt3.text == answer.ToString())
        {
            Yes_No3.GetComponent<Image>().sprite = SpriteYes;
            Find();
        }
        else
        {
            Yes_No3.GetComponent<Image>().sprite = SpriteNo;
            Fail();
        }
    }

    public void ResetValues()
    {
        Yes_No1.GetComponent<Image>().sprite = SpriteTransp;
        Yes_No2.GetComponent<Image>().sprite = SpriteTransp;
        Yes_No3.GetComponent<Image>().sprite = SpriteTransp;

        AnswerContains.text = "?";
    }

    public void Find()
    {
        AnswerContains.text = answer.ToString();
        score = score + 1;

        AnimatorSolution = GameObject.Find("Solution").GetComponent<Animator>();
        AnimatorSolution.Play("Solution");

        Instantiate(Balloon, new Vector3( 16f + (score-1)*1f, 4f, 0f) , Quaternion.identity);

        ComAudio.clip = Yes;
        ComAudio.Play();
        
        StartCoroutine(NextQuestion());
    }

    IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(2);
        CalculatorFunction(VarSign);
    }

    public void Fail()
    {
        ComAudio.clip = No;
        ComAudio.Play();
    }

    public void ReturnMenu()
    {
        canvas.SetActive(false);
        GameObject.Find("Main Camera").transform.position = new Vector3(0f, 0f, -10f);
        AnimatorBackground = GameObject.Find("Background").GetComponent<Animator>();
        AnimatorBackground.Play("Start");
    }

    
}
