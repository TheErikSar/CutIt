using UnityEditor;
using UnityEngine;

namespace AxGrid.Editor
{
    public class Tools : EditorWindow
    {

        [MenuItem("Tools/Take a Screenshot")]
        private static void Screenshot()
        {
            string filename = System.IO.Path.GetFullPath(System.IO.Path.Combine(System.IO.Path.Combine(Application.dataPath, ".."), "ScreenShots"));
            if (!System.IO.Directory.Exists(filename))
            {
                System.IO.Directory.CreateDirectory(filename);
            }

            filename = System.IO.Path.Combine(filename, string.Format("{0}-{1}-{2}-{3}.png", System.DateTime.Now.Year, System.DateTime.Now.Month, System.DateTime.Now.Day, Time.time.ToString().Replace(".", "")));
            ScreenCapture.CaptureScreenshot(filename);
        }

    }
}
