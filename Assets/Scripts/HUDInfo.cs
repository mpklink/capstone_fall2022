using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDInfo : MonoBehaviour
{
    public Text blockText;
    public Text buildingText;
    public Text floorText;
    public Text shelfRowText;
    public Text shelfColText;

    private GlobalVariables Global;

    // Start is called before the first frame update
    void Start()
    {
        Global = FindObjectOfType<GlobalVariables>();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        ShowInfo();
    }

    void ShowInfo()
    {
        blockText.text = Global.current[0].ToString();
        buildingText.text = Global.current[1].ToString();
        floorText.text = Global.current[2].ToString();
        shelfRowText.text = Global.current[3].ToString();
        shelfColText.text = Global.current[4].ToString();
    }
}
