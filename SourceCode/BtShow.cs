using UnityEngine;
using UnityEngine.UI;

public class BtShow : MonoBehaviour
{
    void Start()
    {
        ClosAll();
    }
    public Button CloseBt, BTstart;
    public RawImage MaxIm, TeamIm, ElementIm, startIm;
    public void ShowMas()
    {
        CloseBt.enabled = true;
        CloseBt.image.enabled = true;
        MaxIm.enabled = true;
    }
    public void ShowTeam()
    {
        CloseBt.enabled = true;
        CloseBt.image.enabled = true;
        TeamIm.enabled = true;
    }
    public void ShowElemt()
    {
        ElementIm.enabled = true;
        CloseBt.image.enabled = true;
        CloseBt.enabled = true;
    }
    public void ClosAll()
    {
        CloseBt.enabled = false;
        CloseBt.image.enabled = false;
        MaxIm.enabled = false;
        TeamIm.enabled = false;
        ElementIm.enabled = false;
    }
    public void ExGame()
    {
        Application.Quit();
    }
    public void startgame()
    {
        //BTstart.image.enabled = false;
        BTstart.enabled = false;
        startIm.enabled = false;
    }
}
