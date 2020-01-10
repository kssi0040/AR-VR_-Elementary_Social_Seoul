using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class TextManager : MonoBehaviour
{
    public int currentStage;
    public int count = 0;
    public string text;
    
    [SerializeField]
    int tempInt = 0;

    public RectTransform Link;
    public RectTransform Controller;
    public RectTransform LinkCanvas;
    public RectTransform Typing1Canvas;
    public RectTransform Typing2Canvas;
    public RectTransform OptionCanvas;

    public Transform sphere;
    public Transform CH1_nomal;
    public Transform CH1_Costum;
    public Transform CH2_nomal;
    public Transform CH2_Costum;
    public Transform CH3;
    public Transform Place;

    public Image BackGround;
    public Image PopUp;
    public Image Highlight;
    public Image Book;
    public Image Map;
    public Image sphereIcon;

    public RawImage TextBox;
    public RawImage KingTextBox;
    public RawImage NobleTextBox;

    public Text str;
    public Text PopUpText;
    public Text KingText;
    public Text NobleText;
    
    public Animator CHS;
    public Animator Father;
    public Animator el;
    public Animator King;
    public Animator Noble;
    
    public RectTransform HitTaiko;
    public RectTransform CharacterScroll;
    public RectTransform PopUpScroll;
    public RectTransform NPCScroll;
    public Canvas canvas;

    LinkQuizManager linkQuizManager;


    private void Awake()
    {
        
    }
    // Use this for initialization
    void Start()
    {
        linkQuizManager = FindObjectOfType<LinkQuizManager>();

        LinkCanvas.transform.gameObject.SetActive(false);
        Typing1Canvas.transform.gameObject.SetActive(false);
        Typing2Canvas.transform.gameObject.SetActive(false);
        OptionCanvas.transform.gameObject.SetActive(false);


        Link.transform.gameObject.SetActive(false);
        PopUp.transform.gameObject.SetActive(false);
        PopUpText.transform.gameObject.SetActive(false);
        PopUpScroll.transform.gameObject.SetActive(false);
        
        CH1_nomal.transform.gameObject.SetActive(false);
        CH1_Costum.transform.gameObject.SetActive(false);
        CH2_nomal.transform.gameObject.SetActive(false);
        CH2_Costum.transform.gameObject.SetActive(false);
        CH3.transform.gameObject.SetActive(true);

        CHS.SetTrigger("teachAnim");

        

        text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
        if(text.Contains("###"))
        {
            string temp = text.Replace("###", AppManage.Instance.Name);
            GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
        }
        else
        {
            GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
        }
        if(currentStage==1)
        {
            //Place = GameObject.Find("Place").GetComponent<Transform>();
            Father.transform.gameObject.SetActive(false);
            el.transform.gameObject.SetActive(false);
            King.transform.gameObject.SetActive(false);
            KingText.transform.gameObject.SetActive(false);
            KingTextBox.transform.gameObject.SetActive(false);
            Book.transform.gameObject.SetActive(false);
            Map.transform.gameObject.SetActive(false);
            Place.transform.gameObject.SetActive(false);
            HitTaiko.transform.gameObject.SetActive(false);
            NPCScroll.transform.gameObject.SetActive(false);
        }
        else if(currentStage==2)
        {
            Noble.transform.gameObject.SetActive(false);
            NobleText.transform.gameObject.SetActive(false);
            NobleTextBox.transform.gameObject.SetActive(false);
            NPCScroll.transform.gameObject.SetActive(false);
        }
    }
    AnimatorStateInfo animInfo;
    // Update is called once per frame
    void Update()
    {
        switch (currentStage)
        {
            case 1:
                switch (count)
                {
                    case 0:
                        BackGround.transform.gameObject.SetActive(false);
                        break;
                    case 9:
                        PopUp.transform.gameObject.SetActive(false);
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                switch(count)
                {
                    case 0:
                        BackGround.transform.gameObject.SetActive(false);
                        break;
                    case 3:
                        animInfo = Noble.GetCurrentAnimatorStateInfo(0);
                        if(animInfo.IsName("NPC_Noble_idle"))
                        {
                            if (GameObject.Find("EventMaster").GetComponent<EventManager>().ishit == false)
                            {
                                RectTransform _button = GameObject.Find("EventMaster").GetComponent<EventManager>().button;
                                _button.transform.gameObject.SetActive(true);
                                Text tempText = GameObject.Find("Text").GetComponent<Text>();
                                tempText.text = "양반과 대화하기";
                            }
                        }
                        break;
                    default:
                        break;
                }
                break;
            case 3:
                switch(count)
                {
                    case 0:
                        BackGround.transform.gameObject.SetActive(false);
                        break;
                }
                break;
            case 4:
                switch(count)
                {
                    case 0:
                        BackGround.transform.gameObject.SetActive(false);
                        break;
                }
                break;
            case 5:
                switch(count)
                {
                    case 0:
                        BackGround.transform.gameObject.SetActive(false);
                        break;
                }
                break;
        }
    }
    
    
    public void forwardDown()
    {
        Text tempText;
        
        if (AppManage.Instance.isComplite)
        {
            switch (currentStage)
            {
                case 1:
                    switch (count)
                    {
                        case 0:
                            Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
                            BackGround.transform.gameObject.SetActive(true);
                            BackGround.overrideSprite = Resources.Load<Sprite>("Dim");
                            sphere.transform.gameObject.SetActive(false);
                            sphereIcon.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(false);
                            Place.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 1:
                            BackGround.overrideSprite = Resources.Load<Sprite>("GH_BG");
                            Place.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 2:
                            PopUp.sprite = Resources.Load<Sprite>("Popup_Png");
                            PopUp.transform.gameObject.SetActive(true);
                            GameObject.Find("WebManager").SendMessage("initURL", "http://plaza.seoul.go.kr/gwanghwamun");
                            Link.transform.gameObject.SetActive(true);
                            tempText = GameObject.Find("Text").GetComponent<Text>();
                            tempText.text = "광화문 홈페이지";
                            Map.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 3:
                            PopUp.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            Map.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 5:
                            Book.transform.gameObject.SetActive(true);
                            Book.overrideSprite = Resources.Load<Sprite>("태종실록");
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(false);
                            str.text = string.Empty;
                            count++;
                            break;
                        case 6:
                            Book.overrideSprite = Resources.Load<Sprite>("영조실록");
                            count++;
                            break;
                        case 7:
                            PopUpText.text = string.Empty;
                            Book.transform.gameObject.SetActive(false);
                            Highlight.transform.gameObject.SetActive(true);
                            BackGround.sprite = Resources.Load<Sprite>("GH_BG");
                            PopUp.sprite = Resources.Load<Sprite>("Drum_Take_01");
                            HitTaiko.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 8:
                            break;
                        case 13:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            Father.transform.gameObject.SetActive(false);
                            el.transform.gameObject.SetActive(false);
                            King.transform.gameObject.SetActive(false);
                            CHS.SetTrigger("teachAnim");
                            count++;
                            break;
                        case 14:
                            if (linkQuizManager.OptionClear == false)
                            {
                                str.text = string.Empty;
                                str.transform.gameObject.SetActive(false);
                                TextBox.transform.gameObject.SetActive(false);
                                CharacterScroll.transform.gameObject.SetActive(false);
                                AppManage.Instance.isComplite = true;
                                linkQuizManager.GenerateOptionQuiz(0, tempInt);
                                OptionCanvas.transform.gameObject.SetActive(true);
                                if (AppManage.Instance.Gender == 0)
                                {
                                    CH1_nomal.gameObject.SetActive(false);
                                    CH1_Costum.gameObject.SetActive(false);
                                    CH2_nomal.gameObject.SetActive(true);
                                    CH2_Costum.gameObject.SetActive(false);
                                    CH3.gameObject.SetActive(false);
                                    Father.transform.gameObject.SetActive(false);
                                    el.transform.gameObject.SetActive(false);
                                    King.transform.gameObject.SetActive(false);
                                    CHS.SetTrigger("CH2Anim");
                                }
                                else
                                {
                                    CH1_nomal.gameObject.SetActive(true);
                                    CH1_Costum.gameObject.SetActive(false);
                                    CH2_nomal.gameObject.SetActive(false);
                                    CH2_Costum.gameObject.SetActive(false);
                                    CH3.gameObject.SetActive(false);
                                    Father.transform.gameObject.SetActive(false);
                                    el.transform.gameObject.SetActive(false);
                                    King.transform.gameObject.SetActive(false);
                                    CHS.SetTrigger("CH1Anim");
                                }
                            }
                            else
                            {
                                tempInt++;
                                AppManage.Instance.isComplite = true;
                                linkQuizManager.GenerateOptionQuiz(0, tempInt);
                                linkQuizManager.OptionClear = false;
                            }
                            if (tempInt == 3)
                            {
                                OptionCanvas.transform.gameObject.SetActive(false);
                                tempInt = 0;
                                TextBox.transform.gameObject.SetActive(true);
                                str.transform.gameObject.SetActive(true);
                                CharacterScroll.transform.gameObject.SetActive(true);
                                CH1_nomal.gameObject.SetActive(false);
                                CH1_Costum.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(false);
                                CH2_Costum.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(true);
                                Father.transform.gameObject.SetActive(false);
                                el.transform.gameObject.SetActive(false);
                                King.transform.gameObject.SetActive(false);
                                CHS.SetTrigger("teachAnim");
                                count++;
                            }
                            break;
                        case 16:
                            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                            AppManage.Instance.isComplite = true;
                            GameObject.Find("UIManager").SendMessage("CaptureOn");
                            break;
                        case 19:
                            Highlight.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(true);
                            KingText.transform.gameObject.SetActive(true);
                            KingTextBox.transform.gameObject.SetActive(true);
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 20:
                            SceneManager.LoadScene("Stage1_End");
                            break;
                        default:
                            count++;
                            break;
                           
                    }
                    break;
                case 2:
                    switch (count)
                    {
                        case 0:
                            Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
                            BackGround.transform.gameObject.SetActive(true);
                            sphere.transform.gameObject.SetActive(false);
                            sphereIcon.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 1:
                            str.text = string.Empty;
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            GameObject.Find("WebManager").SendMessage("initURL", "http://hanok.seoul.go.kr/front/kor/exp/expCenter.do?tab=1");
                            Link.transform.gameObject.SetActive(true);
                            tempText = GameObject.Find("Text").GetComponent<Text>();
                            tempText.text = "북촌한옥마을 홈페이지";
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 2:
                            PopUpText.text = string.Empty;
                            PopUp.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            Noble.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 3:
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(true);
                            NobleText.transform.gameObject.SetActive(true);
                            NobleTextBox.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 4:
                            GameObject.Find("EventMaster").GetComponent<EventManager>().ishit = false;
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            NobleTextBox.transform.gameObject.SetActive(false);
                            NobleText.text = string.Empty;
                            NPCScroll.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 5:
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            NobleTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 6:
                            Noble.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            NobleTextBox.transform.gameObject.SetActive(false);
                            NobleText.transform.gameObject.SetActive(false);
                            NobleText.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(true);
                            str.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            CHS.SetTrigger("teachAnim");
                            count++;
                            break;
                        case 7:
                            switch (tempInt)
                            {
                                case 0:
                                    if (linkQuizManager.Typing1Clear==false)
                                    {
                                        str.text = string.Empty;
                                        str.transform.gameObject.SetActive(false);
                                        TextBox.transform.gameObject.SetActive(false);
                                        CharacterScroll.transform.gameObject.SetActive(false);
                                        AppManage.Instance.isComplite = true;
                                        linkQuizManager.GenerateTyping1Quiz(1, tempInt);
                                        Typing1Canvas.transform.gameObject.SetActive(true);
                                        if (AppManage.Instance.Gender == 0)
                                        {
                                            CH1_nomal.gameObject.SetActive(false);
                                            CH1_Costum.gameObject.SetActive(false);
                                            CH2_nomal.gameObject.SetActive(true);
                                            CH2_Costum.gameObject.SetActive(false);
                                            CH3.gameObject.SetActive(false);
                                            CHS.SetTrigger("CH2Anim");
                                        }
                                        else
                                        {
                                            CH1_nomal.gameObject.SetActive(true);
                                            CH1_Costum.gameObject.SetActive(false);
                                            CH2_nomal.gameObject.SetActive(false);
                                            CH2_Costum.gameObject.SetActive(false);
                                            CH3.gameObject.SetActive(false);
                                            CHS.SetTrigger("CH1Anim");
                                        }
                                    }
                                    else
                                    {
                                        tempInt++;
                                        AppManage.Instance.isComplite = true;
                                        linkQuizManager.Typing1Clear = false;
                                        linkQuizManager.GenerateTyping1Quiz(1, tempInt);
                                    }
                                    break;
                                case 1:
                                    if (linkQuizManager.Typing1Clear == true)
                                    {
                                        tempInt++;
                                        linkQuizManager.Typing1Clear = false;
                                        AppManage.Instance.isComplite = true;
                                        linkQuizManager.GenerateOptionQuiz(1, tempInt);
                                        Typing1Canvas.transform.gameObject.SetActive(false);
                                        OptionCanvas.transform.gameObject.SetActive(true);
                                    }
                                    break;
                                case 2:
                                    if(linkQuizManager.OptionClear==true)
                                    {
                                        tempInt++;
                                        linkQuizManager.OptionClear = false;
                                        OptionCanvas.transform.gameObject.SetActive(false);
                                        str.transform.gameObject.SetActive(true);
                                        TextBox.transform.gameObject.SetActive(true);
                                        CharacterScroll.transform.gameObject.SetActive(true);
                                        count++;
                                    }
                                    break;
                            }
                            break;
                        case 9:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            CHS.SetTrigger("teachAnim");
                            count++;
                            break;
                        case 10:
                            if(linkQuizManager.OptionClear==false)
                            {
                                str.text = string.Empty;
                                str.transform.gameObject.SetActive(false);
                                TextBox.transform.gameObject.SetActive(false);
                                CharacterScroll.transform.gameObject.SetActive(false);
                                AppManage.Instance.isComplite = true;
                                linkQuizManager.GenerateOptionQuiz(1, tempInt);
                                OptionCanvas.transform.gameObject.SetActive(true);
                                if (AppManage.Instance.Gender == 0)
                                {
                                    CH1_nomal.gameObject.SetActive(false);
                                    CH1_Costum.gameObject.SetActive(false);
                                    CH2_nomal.gameObject.SetActive(true);
                                    CH2_Costum.gameObject.SetActive(false);
                                    CH3.gameObject.SetActive(false);
                                    CHS.SetTrigger("CH2Anim");
                                }
                                else
                                {
                                    CH1_nomal.gameObject.SetActive(true);
                                    CH1_Costum.gameObject.SetActive(false);
                                    CH2_nomal.gameObject.SetActive(false);
                                    CH2_Costum.gameObject.SetActive(false);
                                    CH3.gameObject.SetActive(false);
                                    CHS.SetTrigger("CH1Anim");
                                }
                            }
                            else
                            {
                                linkQuizManager.OptionClear = false;
                                OptionCanvas.transform.gameObject.SetActive(false);
                                TextBox.transform.gameObject.SetActive(true);
                                str.transform.gameObject.SetActive(true);
                                CharacterScroll.transform.gameObject.SetActive(true);
                                count++;
                            }
                            break;
                        case 11:
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            GameObject.Find("WebManager").SendMessage("initURL", "http://view.asiae.co.kr/news/view.htm?idxno=2018060409554512575");
                            Link.transform.gameObject.SetActive(true);
                            tempText = GameObject.Find("Text").GetComponent<Text>();
                            tempText.text = "기사 링크";
                            count++;
                            break;
                        case 12:
                            PopUpText.text = string.Empty;
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            count++;
                            break;
                        case 14:
                            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                            GameObject.Find("UIManager").SendMessage("CaptureOn");
                            GameObject.Find("CaptureManager").GetComponent<TakeCapture>().TakeShotWithKids(GameObject.Find("CaptureManager").GetComponent<TakeCapture>().Kids, true);
                            AppManage.Instance.isComplite = true;
                            break;
                        default:
                            count++;
                            break;
                    }
                    break;
                case 3:
                    switch(count)
                    {
                        case 0:
                            Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
                            BackGround.transform.gameObject.SetActive(true);
                            sphere.transform.gameObject.SetActive(false);
                            sphereIcon.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(false);
                            str.text = string.Empty;
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            GameObject.Find("WebManager").SendMessage("initURL", "http://www.royalpalace.go.kr/");
                            Link.transform.gameObject.SetActive(true);
                            tempText = GameObject.Find("Text").GetComponent<Text>();
                            tempText.text = "경복궁 홈페이지";
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 1:
                            AppManage.Instance.EndStage(3);
                            break;
                        default:
                            count++;
                            break;
                    }
                    break;
                case 4:
                    switch(count)
                    {
                        case 0:
                            Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
                            BackGround.transform.gameObject.SetActive(true);
                            sphere.transform.gameObject.SetActive(false);
                            sphereIcon.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(false);
                            str.text = string.Empty;
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            GameObject.Find("WebManager").SendMessage("initURL", "https://www.ccourt.go.kr/cckhome/kor/main/index.do");
                            Link.transform.gameObject.SetActive(true);
                            tempText = GameObject.Find("Text").GetComponent<Text>();
                            tempText.text = "헌법재판소 홈페이지";
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 1:
                            PopUpText.text = string.Empty;
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            str.transform.gameObject.SetActive(true);
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            CHS.SetTrigger("teachAnim");
                            count++;
                            break;
                        case 2:
                            if (linkQuizManager.OptionClear == false)
                            {
                                str.text = string.Empty;
                                str.transform.gameObject.SetActive(false);
                                TextBox.transform.gameObject.SetActive(false);
                                CharacterScroll.transform.gameObject.SetActive(false);
                                AppManage.Instance.isComplite = true;
                                linkQuizManager.GenerateOptionQuiz(2, tempInt);
                                OptionCanvas.transform.gameObject.SetActive(true);
                                if (AppManage.Instance.Gender == 0)
                                {
                                    CH1_nomal.gameObject.SetActive(false);
                                    CH1_Costum.gameObject.SetActive(false);
                                    CH2_nomal.gameObject.SetActive(true);
                                    CH2_Costum.gameObject.SetActive(false);
                                    CH3.gameObject.SetActive(false);
                                    CHS.SetTrigger("CH2Anim");
                                }
                                else
                                {
                                    CH1_nomal.gameObject.SetActive(true);
                                    CH1_Costum.gameObject.SetActive(false);
                                    CH2_nomal.gameObject.SetActive(false);
                                    CH2_Costum.gameObject.SetActive(false);
                                    CH3.gameObject.SetActive(false);
                                    CHS.SetTrigger("CH1Anim");
                                }
                            }
                            else
                            {
                                tempInt++;
                                AppManage.Instance.isComplite = true;
                                linkQuizManager.GenerateOptionQuiz(2, tempInt);
                                linkQuizManager.OptionClear = false;
                            }
                            if (tempInt == 3)
                            {
                                AppManage.Instance.EndStage(currentStage);
                            }
                            break;
                        default:
                            count++;
                            break;
                    }
                    break;
                case 5:
                    switch(count)
                    {
                        case 0:
                            Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
                            BackGround.transform.gameObject.SetActive(true);
                            sphere.transform.gameObject.SetActive(false);
                            sphereIcon.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(false);
                            str.text = string.Empty;
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            GameObject.Find("WebManager").SendMessage("initURL", "http://www.president.go.kr/");
                            Link.transform.gameObject.SetActive(true);
                            tempText = GameObject.Find("Text").GetComponent<Text>();
                            tempText.text = "청와대 홈페이지";
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            count++;
                            break;
                        case 1:
                            PopUpText.text = string.Empty;
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            str.transform.gameObject.SetActive(true);
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            CHS.SetTrigger("teachAnim");
                            count++;
                            break;
                        case 2:
                            switch (tempInt)
                            {
                                case 0:
                                    if (linkQuizManager.LinkClear == false)
                                    {
                                        str.text = string.Empty;
                                        str.transform.gameObject.SetActive(false);
                                        TextBox.transform.gameObject.SetActive(false);
                                        CharacterScroll.transform.gameObject.SetActive(false);
                                        AppManage.Instance.isComplite = true;
                                        LinkCanvas.transform.gameObject.SetActive(true);
                                        linkQuizManager.GenerateLinkQuiz(3, tempInt);
                                        if (AppManage.Instance.Gender == 0)
                                        {
                                            CH1_nomal.gameObject.SetActive(false);
                                            CH1_Costum.gameObject.SetActive(false);
                                            CH2_nomal.gameObject.SetActive(true);
                                            CH2_Costum.gameObject.SetActive(false);
                                            CH3.gameObject.SetActive(false);
                                            CHS.SetTrigger("CH2Anim");
                                        }
                                        else
                                        {
                                            CH1_nomal.gameObject.SetActive(true);
                                            CH1_Costum.gameObject.SetActive(false);
                                            CH2_nomal.gameObject.SetActive(false);
                                            CH2_Costum.gameObject.SetActive(false);
                                            CH3.gameObject.SetActive(false);
                                            CHS.SetTrigger("CH1Anim");
                                        }
                                    }
                                    else
                                    {
                                        tempInt++;
                                        str.text = string.Empty;
                                        TextBox.transform.gameObject.SetActive(false);
                                        linkQuizManager.LinkClear = false;
                                        AppManage.Instance.isComplite = true;
                                        linkQuizManager.GenerateTyping2Quiz(3, tempInt);
                                        LinkCanvas.transform.gameObject.SetActive(false);
                                        Typing2Canvas.transform.gameObject.SetActive(true);
                                    }
                                    break;
                                case 1:
                                    if (linkQuizManager.Typing2Clear == true)
                                    {
                                        AppManage.Instance.EndStage(currentStage);
                                    }
                                    break;
                            }
                            
                            break;
                        default:
                            count++;
                            break;
                    }
                    break;
                default:
                    break;
            }
            switch(currentStage)
            {
                case 1:
                    switch(count)
                    {
                        case 6:
                        case 7:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        case 20:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, KingText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, KingText);
                            }
                            break;
                        default:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                    }
                    break;
                case 2:
                    switch(count)
                    {
                        case 2:
                        case 12:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        case 3:
                            break;
                        case 4:
                        case 6:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, NobleText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, NobleText);
                            }
                            break;
                        case 13:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                        default:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                    }
                    break;
                case 3:
                    switch(count)
                    {
                        case 1:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        default:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (count)
                    {
                        case 1:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        default:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                    }
                    break;
                case 5:
                    switch (count)
                    {
                        case 1:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        default:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                    }
                    break;
            }
            switch (currentStage)
            {
                case 1:
                    switch (count)
                    {
                        case 10:
                        case 12:
                        case 16:
                        case 17:
                        case 19:
                            if (AppManage.Instance.Gender == 0)
                            {
                                CH1_nomal.gameObject.SetActive(false);
                                CH1_Costum.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(true);
                                CH2_Costum.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(false);
                                Father.transform.gameObject.SetActive(false);
                                el.transform.gameObject.SetActive(false);
                                King.transform.gameObject.SetActive(false);
                            }
                            else
                            {
                                CH1_nomal.gameObject.SetActive(true);
                                CH1_Costum.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(false);
                                CH2_Costum.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(false);
                                Father.transform.gameObject.SetActive(false);
                                el.transform.gameObject.SetActive(false);
                                King.transform.gameObject.SetActive(false);
                            }
                            break;
                        case 11:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(false);
                            Father.transform.gameObject.SetActive(true);
                            el.transform.gameObject.SetActive(false);
                            King.transform.gameObject.SetActive(false);
                            break;
                        case 13:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(false);
                            Father.transform.gameObject.SetActive(false);
                            el.transform.gameObject.SetActive(true);
                            King.transform.gameObject.SetActive(false);
                            break;
                        case 20:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(false);
                            Father.transform.gameObject.SetActive(false);
                            el.transform.gameObject.SetActive(false);
                            King.transform.gameObject.SetActive(true);
                            break;
                        case 14:
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            Father.transform.gameObject.SetActive(false);
                            el.transform.gameObject.SetActive(false);
                            King.transform.gameObject.SetActive(false);
                            break;
                    }
                    break;
                case 2:
                    switch (count)
                    {
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 8:
                            if (AppManage.Instance.Gender == 0)
                            {
                                CH1_nomal.gameObject.SetActive(false);
                                CH1_Costum.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(true);
                                CH2_Costum.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(false);
                            }
                            else
                            {
                                CH1_nomal.gameObject.SetActive(true);
                                CH1_Costum.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(false);
                                CH2_Costum.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(false);
                            }
                            break;
                        case 7:
                        case 10:
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            Noble.transform.gameObject.SetActive(false);
                            break;
                    }
                    break;
                case 3:
                    CH1_nomal.gameObject.SetActive(false);
                    CH1_Costum.gameObject.SetActive(false);
                    CH2_nomal.gameObject.SetActive(false);
                    CH2_Costum.gameObject.SetActive(false);
                    CH3.gameObject.SetActive(true);
                    break;
                case 4:
                    switch (count)
                    {
                        case 2:
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            break;
                    }
                    break;
                case 5:
                    switch (count)
                    {
                        case 2:
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            break;
                    }
                    break;
                default:
                    break;
            }
            if (Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]] == "*")
            {
                if (AppManage.Instance.Gender == 0)
                {
                    CHS.SetTrigger("CH2Anim");
                }
                else
                {
                    CHS.SetTrigger("CH1Anim");
                }
            }
            else
            {
                if (currentStage == 1)
                {
                    if(count!=14&&count!=11&&count!=13)
                    {
                        CHS.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                    }
                    else if(count==11)
                    {
                        Father.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                    }
                    else if(count==13)
                    {
                        el.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                    }
                }
                else if(currentStage==2)
                {
                    if(count!=7)
                    {
                        CHS.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                    }
                }
                else if(currentStage==4)
                {
                    if(count!=2)
                    {
                        CHS.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                    }
                }
                else if (currentStage == 5)
                {
                    if (count != 2)
                    {
                        CHS.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                    }
                }
                else
                {
                    CHS.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                }
            }
            AppManage.Instance.isComplite = false;
        }
        else
        {
            AppManage.Instance.isClicked = true;
        }
    }

    public void BeforeDown()
    {
        Text tempText;
        if (AppManage.Instance.isComplite)
        {
            if (count > 0)
            {
                count--;
            }
            else
            {
                SceneManager.LoadScene("SelectMap");
            }
            switch (currentStage)
            {
                case 1:
                    switch (count)
                    {
                        case 0:
                            {
                                Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
                                sphere.transform.gameObject.SetActive(true);
                                sphereIcon.transform.gameObject.SetActive(true);
                                BackGround.transform.gameObject.SetActive(false);
                                Controller.transform.gameObject.SetActive(true);
                                Place.transform.gameObject.SetActive(false);
                            }
                            break;
                        case 1:
                            Place.transform.gameObject.SetActive(true);
                            BackGround.overrideSprite = Resources.Load<Sprite>("Dim");
                            break;
                        case 2:
                            PopUp.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            Map.transform.gameObject.SetActive(false);
                            break;
                        case 3:
                            PopUp.overrideSprite = Resources.Load<Sprite>("Popup_Png");
                            PopUp.transform.gameObject.SetActive(true);
                            Map.transform.gameObject.SetActive(true);
                            GameObject.Find("WebManager").SendMessage("initURL", "http://plaza.seoul.go.kr/gwanghwamun");
                            Link.transform.gameObject.SetActive(true);
                            tempText = GameObject.Find("Text").GetComponent<Text>();
                            tempText.text = "광화문 홈페이지";
                            break;
                        case 5:
                            PopUpText.text = string.Empty;
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            Book.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            break;
                        case 6:
                            Book.transform.gameObject.SetActive(true);
                            Book.overrideSprite = Resources.Load<Sprite>("태조실록");
                            break;
                        case 7:
                            Book.transform.gameObject.SetActive(true);
                            TextBox.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            Book.overrideSprite = Resources.Load<Sprite>("영조실록");
                            PopUp.overrideSprite = Resources.Load<Sprite>("Popup_Png");
                            PopUp.transform.gameObject.SetActive(true);
                            HitTaiko.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            if (GameObject.Find("EventMaster").GetComponent<EventManager>().ishit)
                            {
                                GameObject.Find("Next").GetComponent<RectTransform>().transform.gameObject.SetActive(false);
                                GameObject.Find("EventMaster").GetComponent<EventManager>().ishit = false;
                            }
                            str.text = string.Empty;
                            break;
                        case 8:
                            PopUp.transform.gameObject.SetActive(true);
                            HitTaiko.transform.gameObject.SetActive(true);
                            BackGround.overrideSprite = Resources.Load<Sprite>("GH_BG");
                            break;
                        case 13:
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            str.transform.gameObject.SetActive(true);
                            OptionCanvas.transform.gameObject.SetActive(false);
                            tempInt = 0;
                            break;
                        case 19:
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            KingText.transform.gameObject.SetActive(false);
                            KingTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            break;
                    }
                    break;
                case 2:
                    switch (count)
                    {
                        case 0:
                            Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
                            sphere.transform.gameObject.SetActive(true);
                            sphereIcon.transform.gameObject.SetActive(true);
                            BackGround.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(true);
                            break;
                        case 1:
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpText.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            PopUpText.text = string.Empty;
                            break;
                        case 2:
                            Noble.transform.gameObject.SetActive(false);
                            str.text = string.Empty;
                            CharacterScroll.transform.gameObject.SetActive(false);
                            PopUp.overrideSprite = Resources.Load<Sprite>("Popup_Png");
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            PopUpText.transform.gameObject.SetActive(true);
                            GameObject.Find("WebManager").SendMessage("initURL", "http://hanok.seoul.go.kr/front/kor/exp/expCenter.do?tab=1");
                            Link.transform.gameObject.SetActive(true);
                            tempText = GameObject.Find("Text").GetComponent<Text>();
                            tempText.text = "북촌한옥마을 홈페이지";
                            TextBox.transform.gameObject.SetActive(false);
                            GameObject.Find("EventMaster").GetComponent<EventManager>().ishit = false;
                            break;
                        case 3:
                            GameObject.Find("EventMaster").GetComponent<EventManager>().ishit = false;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            Noble.transform.gameObject.SetActive(false);
                            Noble.transform.gameObject.SetActive(true);
                            NobleText.text = string.Empty;
                            NobleText.transform.gameObject.SetActive(false);
                            NobleTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            str.text = string.Empty;
                            break;
                        case 4:
                            str.text = string.Empty;
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            NobleTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            break;
                        case 5:
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            NobleText.text = string.Empty;
                            NobleTextBox.transform.gameObject.SetActive(false);
                            NPCScroll.transform.gameObject.SetActive(false);
                            break;
                        case 6:
                            if (AppManage.Instance.Gender == 0)
                            {
                                CH1_nomal.gameObject.SetActive(false);
                                CH1_Costum.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(true);
                                CH2_Costum.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(false);
                                CHS.SetTrigger("CH2Anim");
                            }
                            else
                            {
                                CH1_nomal.gameObject.SetActive(true);
                                CH1_Costum.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(false);
                                CH2_Costum.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(false);
                                CHS.SetTrigger("CH1Anim");
                            }
                            Noble.transform.gameObject.SetActive(true);
                            OptionCanvas.transform.gameObject.SetActive(false);
                            Typing1Canvas.transform.gameObject.SetActive(false);
                            NobleText.transform.gameObject.SetActive(true);
                            NobleTextBox.transform.gameObject.SetActive(true);
                            NPCScroll.transform.gameObject.SetActive(true);
                            tempInt = 0;
                            break;
                        case 7:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            CHS.SetTrigger("teachAnim");
                            tempInt = 0;
                            break;
                        case 10:
                            linkQuizManager.OptionClear = false;
                            break;
                        case 11:
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpText.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            PopUpText.text = string.Empty;
                            break;
                        case 12:
                            str.text = string.Empty;
                            PopUpScroll.transform.gameObject.SetActive(true);
                            PopUp.transform.gameObject.SetActive(true);
                            GameObject.Find("WebManager").SendMessage("initURL", "http://view.asiae.co.kr/news/view.htm?idxno=2018060409554512575");
                            Link.transform.gameObject.SetActive(true);
                            tempText = GameObject.Find("Text").GetComponent<Text>();
                            tempText.text = "기사 링크";
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            break;
                    }
                    break;
                case 3:
                    switch (count)
                    {
                        case 0:
                            Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
                            sphere.transform.gameObject.SetActive(true);
                            sphereIcon.transform.gameObject.SetActive(true);
                            BackGround.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(true);
                            PopUpText.text = string.Empty;
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpText.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            break;
                    }
                    break;
                case 4:
                    switch (count)
                    {
                        case 0:
                            Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
                            sphere.transform.gameObject.SetActive(true);
                            sphereIcon.transform.gameObject.SetActive(true);
                            BackGround.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(true);
                            PopUpText.text = string.Empty;
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpText.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            break;
                        case 1:
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            TextBox.transform.gameObject.SetActive(false);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            str.text = string.Empty;
                            str.transform.gameObject.SetActive(true);
                            tempInt = 0;
                            linkQuizManager.OptionClear = false;
                            OptionCanvas.transform.gameObject.SetActive(false);
                            break;
                    }
                    break;
                case 5:
                    switch (count)
                    {
                        case 0:
                            Camera.main.transform.rotation = Quaternion.Euler(Vector3.zero);
                            sphere.transform.gameObject.SetActive(true);
                            sphereIcon.transform.gameObject.SetActive(true);
                            BackGround.transform.gameObject.SetActive(false);
                            Controller.transform.gameObject.SetActive(true);
                            PopUpText.text = string.Empty;
                            PopUp.transform.gameObject.SetActive(false);
                            PopUpText.transform.gameObject.SetActive(false);
                            PopUpScroll.transform.gameObject.SetActive(false);
                            Link.transform.gameObject.SetActive(false);
                            TextBox.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(true);
                            break;
                        case 1:
                            PopUp.transform.gameObject.SetActive(true);
                            PopUpScroll.transform.gameObject.SetActive(true);
                            TextBox.transform.gameObject.SetActive(false);
                            str.text = string.Empty;
                            str.transform.gameObject.SetActive(true);
                            CharacterScroll.transform.gameObject.SetActive(false);
                            tempInt = 0;
                            linkQuizManager.LinkClear = false;
                            linkQuizManager.Typing2Clear = false;
                            LinkCanvas.transform.gameObject.SetActive(false);
                            Typing2Canvas.transform.gameObject.SetActive(false);
                            break;

                    }
                    break;
                default:
                    break;
            }
            switch (currentStage)
            {
                case 1:
                    switch (count)
                    {
                        case 6:
                        case 7:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        case 20:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, KingText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, KingText);
                            }
                            break;
                        default:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (count)
                    {
                        case 2:
                        case 12:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        case 3:
                            break;
                        case 4:
                        case 6:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, NobleText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, NobleText);
                            }
                            break;
                        case 13:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                        default:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                    }
                    break;
                case 3:
                    switch (count)
                    {
                        case 1:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        default:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                    }
                    break;
                case 4:
                    switch (count)
                    {
                        case 1:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        default:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                    }
                    break;
                case 5:
                    switch (count)
                    {
                        case 1:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, PopUpText);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, PopUpText);
                            }
                            break;
                        default:
                            text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                            if (text.Contains("###"))
                            {
                                string temp = text.Replace("###", AppManage.Instance.Name);
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                            }
                            else
                            {
                                GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                            }
                            break;
                    }
                    break;
            }
            switch (currentStage)
            {
                case 1:
                    switch (count)
                    {
                        case 10:
                        case 12:
                        case 16:
                        case 17:
                        case 19:
                            if (AppManage.Instance.Gender == 0)
                            {
                                CH1_nomal.gameObject.SetActive(false);
                                CH1_Costum.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(true);
                                CH2_Costum.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(false);
                                Father.transform.gameObject.SetActive(false);
                                el.transform.gameObject.SetActive(false);
                                King.transform.gameObject.SetActive(false);
                            }
                            else
                            {
                                CH1_nomal.gameObject.SetActive(true);
                                CH1_Costum.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(false);
                                CH2_Costum.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(false);
                                Father.transform.gameObject.SetActive(false);
                                el.transform.gameObject.SetActive(false);
                                King.transform.gameObject.SetActive(false);
                            }
                            break;
                        case 11:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(false);
                            Father.transform.gameObject.SetActive(true);
                            el.transform.gameObject.SetActive(false);
                            King.transform.gameObject.SetActive(false);
                            break;
                        case 13:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(false);
                            Father.transform.gameObject.SetActive(false);
                            el.transform.gameObject.SetActive(true);
                            King.transform.gameObject.SetActive(false);
                            break;
                        case 20:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(false);
                            Father.transform.gameObject.SetActive(false);
                            el.transform.gameObject.SetActive(false);
                            King.transform.gameObject.SetActive(true);
                            break;
                        case 14:
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            Father.transform.gameObject.SetActive(false);
                            el.transform.gameObject.SetActive(false);
                            King.transform.gameObject.SetActive(false);
                            break;
                    }
                    break;
                case 2:
                    switch (count)
                    {
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 8:
                            if (AppManage.Instance.Gender == 0)
                            {
                                CH1_nomal.gameObject.SetActive(false);
                                CH1_Costum.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(true);
                                CH2_Costum.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(false);
                            }
                            else
                            {
                                CH1_nomal.gameObject.SetActive(true);
                                CH1_Costum.gameObject.SetActive(false);
                                CH2_nomal.gameObject.SetActive(false);
                                CH2_Costum.gameObject.SetActive(false);
                                CH3.gameObject.SetActive(false);
                            }
                            break;
                        case 7:
                        case 10:
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            Noble.transform.gameObject.SetActive(false);
                            break;
                    }
                    break;
                case 3:
                    CH1_nomal.gameObject.SetActive(false);
                    CH1_Costum.gameObject.SetActive(false);
                    CH2_nomal.gameObject.SetActive(false);
                    CH2_Costum.gameObject.SetActive(false);
                    CH3.gameObject.SetActive(true);
                    break;
                case 4:
                    switch (count)
                    {
                        case 2:
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            break;
                    }
                    break;
                case 5:
                    switch (count)
                    {
                        case 2:
                            break;
                        default:
                            CH1_nomal.gameObject.SetActive(false);
                            CH1_Costum.gameObject.SetActive(false);
                            CH2_nomal.gameObject.SetActive(false);
                            CH2_Costum.gameObject.SetActive(false);
                            CH3.gameObject.SetActive(true);
                            break;
                    }
                    break;
                default:
                    break;
            }
            if (Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]] == "*")
            {
                if (AppManage.Instance.Gender == 0)
                {
                    CHS.SetTrigger("CH2Anim");
                }
                else
                {
                    CHS.SetTrigger("CH1Anim");
                }
            }
            else
            {
                if (currentStage == 1)
                {
                    if (count != 14 && count != 11 && count != 13)
                    {
                        CHS.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                    }
                    else if (count == 11)
                    {
                        Father.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                    }
                    else if (count == 13)
                    {
                        el.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                    }
                }
                else if (currentStage == 2)
                {
                    if (count != 7)
                    {
                        CHS.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                    }
                }
                else if (currentStage == 4)
                {
                    if (count != 2)
                    {
                        CHS.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                    }
                }
                else if (currentStage == 5)
                {
                    if (count != 2)
                    {
                        CHS.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                    }
                }
                else
                {
                    CHS.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                }
            }
            AppManage.Instance.isComplite = false;
        }
        else
        {
            AppManage.Instance.isClicked = true;
        }

    }
    public void ExitCapture()
    {
        if (AppManage.Instance.isComplite)
        {
            if (currentStage == 1)
            {
                GameObject.Find("UIManager").SendMessage("CaptureOff");
                AppManage.Instance.isComplite = false;
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                count++;
                if (AppManage.Instance.Gender == 0)
                {
                    CH1_nomal.gameObject.SetActive(false);
                    CH1_Costum.gameObject.SetActive(false);
                    CH2_nomal.gameObject.SetActive(true);
                    CH2_Costum.gameObject.SetActive(false);
                    CH3.gameObject.SetActive(false);
                }
                else
                {
                    CH1_nomal.gameObject.SetActive(true);
                    CH1_Costum.gameObject.SetActive(false);
                    CH2_nomal.gameObject.SetActive(false);
                    CH2_Costum.gameObject.SetActive(false);
                    CH3.gameObject.SetActive(false);
                }
                str.text = string.Empty;
                text = Text_XML_Reader.Instance.scenario[currentStage].text[Text_XML_Reader.Instance.scenario[currentStage].Num[count]];
                if (text.Contains("###"))
                {
                    string temp = text.Replace("###", AppManage.Instance.Name);
                    GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(temp, str);
                }
                else
                {
                    GameObject.Find("TypingManager").GetComponent<TypingManager>().TypingText(text, str);
                }

                if (Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]] == "*")
                {
                    if (AppManage.Instance.Gender == 0)
                    {
                        CHS.SetTrigger("CH2Anim");
                    }
                    else
                    {
                        CHS.SetTrigger("CH1Anim");
                    }
                }
                else
                {
                    CHS.SetTrigger(Text_XML_Reader.Instance.scenario[currentStage].anim[Text_XML_Reader.Instance.scenario[currentStage].Num[count]]);
                }
            }
            else if (currentStage == 2)
            {
                SceneManager.LoadScene("Stage2_End");
            }
        }
    }
}
