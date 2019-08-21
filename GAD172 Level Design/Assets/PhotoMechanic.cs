using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PhotoMechanic : MonoBehaviour
{

    public KeyCode screenCaptureKey = KeyCode.F2;
    public string ScreenCapDirectory;
    public string ScreenCapName = "PictureTaken";
    public string fileType = ".png";
    private int count;
    private int ScreenCaps;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        ScreenCaps = 0;
        ScreenCapDirectory = Application.persistentDataPath;
    }

    // Update is called once per frame
    void Update()
    {
        ScreenCaps = (FindScreenCaptures(ScreenCapDirectory, ScreenCapName));
        if (Input.GetKeyDown(screenCaptureKey))
        {
            ScreenCapture.CaptureScreenshot(ScreenCapDirectory + ScreenCapName + (ScreenCaps + 1) + fileType);
            Debug.Log("ScreenCapture Taken!");
            Debug.Log("ScreenCap Location: " + ScreenCapDirectory);
        }
    }
    
    int FindScreenCaptures(string DirectoryPath, string FileName)
    {
        count = 0;
        for (int i = 0; i < Directory.GetFiles(DirectoryPath).Length; i++)
        {
            if (Directory.GetFiles(DirectoryPath)[i].Contains(FileName))
            {
                count += 1;
            }
        }
        return count;
    }

}
