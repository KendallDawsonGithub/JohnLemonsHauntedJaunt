using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.EventSystems;

public class BackendManagement : MonoBehaviour
{
    public Canvas Canvas;
    public Selectable Nullable;

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
                            x =>  x.gameObject.transform.parent == Canvas.transform.Find("MainMenu[Panel]").transform.Find("Overlay[Panel]").transform
                            && x.gameObject.activeSelf == true) == false
                        )
                        {
                            case true:
                                foreach (Transform Transform in Canvas.transform) { Transform.gameObject.SetActive(false); }
                                Canvas.transform.Find("TitleScreen[Panel]").gameObject.SetActive(true);
                                Nullable.Select();
                                break;
                            case false:
                                switch ()
                                {
                                    case true:
                                    break;
                                }
                                foreach (Transform Transform in Canvas.transform.Find("MainMenu[Panel]").transform.Find("Overlay[Panel]").transform) { Transform.gameObject.SetActive(false); }
                                Canvas.transform.Find("MainMenu[Panel]").transform.Find("Bottom[Panel]").transform.Find("Languages[Button]").GetComponent<Button>().Select();
                                break;
                        }
                        break;
                }
                break;
        }
    }
}
