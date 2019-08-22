using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PhotoMechanic : MonoBehaviour
{

    public KeyCode screenCaptureKey = KeyCode.F;
    string folderPath = Directory.GetCurrentDirectory() + "/Screenshots/";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(screenCaptureKey)) {
            Debug.Log("KeyPressed");
            TakeScreenshot();
        }
    }

    public void TakeScreenshot() {

        if (!System.IO.Directory.Exists(folderPath))
            System.IO.Directory.CreateDirectory(folderPath);
       
        var screenshotName =
                                 "Screenshot_" +
                                 System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") +
                                 ".png";
        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, screenshotName));
        Debug.Log(folderPath + screenshotName);
    }

    public void ShowExplorer() {
        System.Diagnostics.Process.Start(folderPath);
    }
}
