using UnityEngine;
using UnityEngine.UI;
using Management;

public class ManageFront1_2 : Manage
{    
    private Color flashColor = new Color(1f, 0f, 0f, 0.3f); // 번쩍일 때의 컬러값
    private float flashSpeed = 1f;
    public Image flashImage;
    private bool flashing = false;

    private ChangeFileName _changeFileName;
    private int number = 1; // Image1, Image2 ... 의 숫자 
    private GameObject _nextbtn; // next button reference 

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        _changeFileName = GetComponent<ChangeFileName>();
    }

    private void Update()
    {        
        Flash();
    }

    private void ScrollToTop()
    {
        // scroll 맨위로 이동 
        ((RectTransform)GameObject.Find("content").transform).offsetMin = new Vector2(0f, -3572f);
        ((RectTransform)GameObject.Find("content").transform).offsetMax = new Vector2(0f, 0f);
    }

    // img 번쩍임 효과 
    public void Flash()
    {
        if(flashing)
        {
            flashImage.color = flashColor;          
        }
        else
        {
            flashImage.color =
                Color.Lerp(flashImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        flashing = false;
    }

    private void WaitForFlash()
    {
        flashing = true;
        //Debug.Log(flashing);
    }

    // objectName에 해당하는 이미지에 Flash effect 
    private void MakeObjectFlash(string objectName)
    {
        // 이전 오브젝트의 Flash 반복 중지
        CancelInvoke();
        // 이전 오브젝트의 Color alpha값 0으로 (투명하게)
        flashImage.color = Color.clear;
        // 새로운 오브젝트 찾고 
        flashImage = GameObject.Find(objectName).GetComponent<Image>();
        // Flash 반복 
        InvokeRepeating("WaitForFlash", 1f, 1f);

    }

    // 블링크 중인 이미지 누르면 Image1, Image2 ... 로 이미지명 변경 
    public void OnClickImage()
    {
        // Instaniate한 모든 오브젝트들 제거 
        if (objs.Count != 0) DestroySpawnedObj();

        // explorer를 닫았을시, 다시 해당 이미지가 블링크하도록 
        if(_changeFileName.OpenExplorer(number++, "") == false)
        {
            number--;
            return;
        }
        //_changeFileName.OpenExplorer(number++);
        switch(index)
        {
            case 5:
                MakeObjectFlash("Flash2");
                break;
            case 6:
                MakeObjectFlash("Flash3");
                break;

            case 7:
                MakeObjectFlash("Flash4");
                break;

            case 8:
                MakeObjectFlash("Flash5");
                break;

            case 9:
                MakeObjectFlash("Flash6");
                break;

            case 10:
                MakeObjectFlash("Flash7");
                break;

            case 11:
                MakeObjectFlash("Flash8");
                break;

            case 12:               
                _nextbtn.SetActive(true);
                CancelInvoke();
                obj = CreateBox(new Vector2(250f, -300f), new Vector2(700f, 150f),
                    "Now click next button");
                objs.Add(obj);
                obj = CreateOnCanvas("RightArrow", new Vector2(450f, -300f));
                objs.Add(obj);
                // IMAGES 폴더 web 폴더로 복사 
                _changeFileName.CopyDirectory();
                break;

            
        }
        index++;
    }

    // button에 연결 
    public void Front1_2Func()
    {   
        // Instaniate한 모든 오브젝트들 제거 
        if (objs.Count != 0) DestroySpawnedObj();

        switch (index)
        {
            case 0:
                // 대화박스 생성 
                obj = CreateBox(Vector2.zero, new Vector2(1300f, 300f),
                    "Now lets change image of your web");
                // 오브젝트 제거 위해서 objs 리스트에 추가. 다음 버튼 클릭 시 objs에 등록된 모든 객체들 제거됨 
                objs.Add(obj);
                break;

            case 1:
                obj = CreateBox(Vector2.zero, new Vector2(1300f, 300f),
                    "Before that, Put your images in the Assets/IMAGES folder");
                objs.Add(obj);
                break;

            case 2:
                obj = InstantiateUI("MoveImgVideo", "Canvas", false);
                obj.transform.localScale = new Vector3(1f, 1f, 1f);
                objs.Add(obj);
                break;

            case 3:
                obj = CreateBox(Vector2.zero, new Vector2(1000f, 200f),
                    "Now Look at the blinking image");
                objs.Add(obj);
                MakeObjectFlash("Flash1");
                break;

            case 4:
                obj = CreateBox(Vector2.zero, new Vector2(1400f, 200f),
                    "Click the image and select your image to replace it");
                objs.Add(obj);
                // button 비활성화
                _nextbtn = GameObject.Find("NextBtn");
                _nextbtn.SetActive(false);
                break;

            case 13:
                ScrollToTop();
                break;

            case 14:
                obj = CreateBox(Vector2.zero, new Vector2(1400f, 200f),
                    "You have created 'HOME' page of your Web"); objs.Add(obj);
                obj = CreateOnCanvas("UpArrow", new Vector2(260f, 295f)); objs.Add(obj);
                break;

            case 15:
                obj = CreateBox(Vector2.zero, new Vector2(1400f, 200f),
                    "Now click other pages to create other pages"); objs.Add(obj);
                obj = CreateOnCanvas("UpArrow", new Vector2(340f, 295f)); objs.Add(obj);
                obj = CreateOnCanvas("UpArrow", new Vector2(431.5f, 291f)); objs.Add(obj);
                obj = CreateOnCanvas("UpArrow", new Vector2(515f, 291f)); objs.Add(obj);                    
                break;


            case 16:
                // to next scene ... 
                //SetFadeout("fin");
                break;

            // 버튼 비활성 이후에는 이미지 클릭으로 진행 
            default:
                break;


        }
        index++;
    }

}
