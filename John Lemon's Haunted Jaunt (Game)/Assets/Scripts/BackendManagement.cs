using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;
using static Chroma.Interface.Chroma;
using Chroma.Interface;

public class BackendManagement : MonoBehaviour
{
    public Canvas Canvas;
    public Selectable Nullable;
    #if UNITY_EDITOR
    public Account Account = null;
    #endif

    void Start()
    {
        Canvas.transform.Find("MainMenu[Panel]").transform.Find("Left[Panel]").transform.Find("Interaction[Panel]").transform.Find("Play[Button]").GetComponent<Button>().onClick.AddListener(async () =>
        {

        });
        Canvas.transform.Find("MainMenu[Panel]").transform.Find("Left[Panel]").transform.Find("Interaction[Panel]").transform.Find("Controls[Button]").GetComponent<Button>().onClick.AddListener(() =>
        {

        });
        Canvas.transform.Find("MainMenu[Panel]").transform.Find("Left[Panel]").transform.Find("Interaction[Panel]").transform.Find("Credits[Button]").GetComponent<Button>().onClick.AddListener(() =>
        {
            foreach (Transform Transform in Canvas.transform.Find("MainMenu[Panel]").transform.Find("Overlay[Panel]").transform) { Transform.gameObject.SetActive(false); }
            Canvas.transform.Find("MainMenu[Panel]").transform.Find("Overlay[Panel]").transform.Find("Credits[Panel]").gameObject.SetActive(true);
            Canvas.transform.Find("MainMenu[Panel]").transform.Find("Overlay[Panel]").transform.Find("Credits[Panel]").transform.Find("Credits[ScrollRect]").GetComponent<ScrollRect>().content.GetChild(0).GetComponent<Button>().Select();
        });
        Canvas.transform.Find("MainMenu[Panel]").transform.Find("Left[Panel]").transform.Find("Interaction[Panel]").transform.Find("Settings[Button]").GetComponent<Button>().onClick.AddListener(() =>
        {

        });
        Canvas.transform.Find("MainMenu[Panel]").transform.Find("Left[Panel]").transform.Find("Interaction[Panel]").transform.Find("ReturntoTitleScreen[Button]").GetComponent<Button>().onClick.AddListener(() =>
        {
            foreach (Transform Transform in Canvas.transform) { Transform.gameObject.SetActive(false); }
            Canvas.transform.Find("TitleScreen[Panel]").gameObject.SetActive(true);
            Nullable.Select();
        });
        Canvas.transform.Find("MainMenu[Panel]").transform.Find("Bottom[Panel]").transform.Find("Languages[Button]").GetComponent<Button>().onClick.AddListener(() =>
        {
            foreach (Transform Transform in Canvas.transform.Find("MainMenu[Panel]").transform.Find("Overlay[Panel]").transform) { Transform.gameObject.SetActive(false); }
            Canvas.transform.Find("MainMenu[Panel]").transform.Find("Overlay[Panel]").transform.Find("Languages[Panel]").gameObject.SetActive(true);
            Canvas.transform.Find("MainMenu[Panel]").transform.Find("Overlay[Panel]").transform.Find("Languages[Panel]").transform.Find("Languages[ScrollRect]").GetComponent<ScrollRect>().content.GetChild(0).GetComponent<Button>().Select();
        });
        Canvas.transform.Find("MainMenu[Panel]").transform.Find("Bottom[Panel]").transform.Find("Version[Panel]").transform.Find("Label[Text]").GetComponent<TextMeshProUGUI>().text = "Alpha Version " + Application.version;
        UnityEngine.Events.UnityAction UnityActionAsync = UniTask.UnityAction(async() =>
        {
            Chroma.Interface.Chroma.Initialize();
            IReadOnlyCollection<Account> IReadOnlyCollection = await Chroma.Interface.Chroma.Account.GetAccounts();
            Account = IReadOnlyCollection.FirstOrDefault();
            Texture2D Texture2D new Texture2D(0, 0);
            Texture2D.LoadImage();
            Canvas.transform.Find("MainMenu[Panel]").transform.Find("Bottom[Panel]").transform.Find("Account[Panel]").transform.Find("Profile[Panel]").transform.Find("Mask[Image]").transform.Find("Image[RawImage]").GetComponent<RawImage>().texture = Account.AccountPicture;
        });
        UnityActionAsync.Invoke();
    }

    void Update()
    {
        switch (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            case true:
                switch (Canvas.transform.Find("TitleScreen[Panel]").gameObject.activeSelf)
                {
                    case true:
                        foreach (Transform Transform in Canvas.transform) { Transform.gameObject.SetActive(false); }
                        Canvas.transform.Find("MainMenu[Panel]").gameObject.SetActive(true);
                        Canvas.transform.Find("MainMenu[Panel]").transform.Find("Left[Panel]").transform.Find("Interaction[Panel]").transform.Find("Play[Button]").GetComponent<Button>().Select();
                        break;
                }
                break;
        }
        switch (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            case true:
                switch (Canvas.transform.Find("MainMenu[Panel]").gameObject.activeSelf)
                {
                    case true:
                        switch (Canvas.transform.Find("MainMenu[Panel]").transform.Find("Overlay[Panel]").transform.GetComponentsInChildren<Transform>().Any(
                            x => x.gameObject.transform.parent == Canvas.transform.Find("MainMenu[Panel]").transform.Find("Overlay[Panel]").transform
                            && x.gameObject.activeSelf == true) == false
                        )
                        {
                            case true:
                                foreach (Transform Transform in Canvas.transform) { Transform.gameObject.SetActive(false); }
                                Canvas.transform.Find("TitleScreen[Panel]").gameObject.SetActive(true);
                                Nullable.Select();
                                break;
                            case false:
                                switch (Canvas.transform.Find("MainMenu[Panel]").transform.Find("Overlay[Panel]").transform.Find("Credits[Panel]").gameObject.activeSelf){case true:Canvas.transform.Find("MainMenu[Panel]").transform.Find("Left[Panel]").transform.Find("Interaction[Panel]").transform.Find("Credits[Button]").GetComponent<Button>().Select();break;}
                                switch (Canvas.transform.Find("MainMenu[Panel]").transform.Find("Overlay[Panel]").transform.Find("Languages[Panel]").gameObject.activeSelf){case true:Canvas.transform.Find("MainMenu[Panel]").transform.Find("Bottom[Panel]").transform.Find("Languages[Button]").GetComponent<Button>().Select();break;}
                                foreach (Transform Transform in Canvas.transform.Find("MainMenu[Panel]").transform.Find("Overlay[Panel]").transform) { Transform.gameObject.SetActive(false); }
                                break;
                        }
                        break;
                }
                break;
        }
    }
}
