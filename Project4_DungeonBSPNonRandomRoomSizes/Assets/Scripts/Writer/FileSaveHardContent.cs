using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileSaveHardContent : MonoBehaviour
{
  private void Start()
  {
    System.Text.StringBuilder contentBuilder = new System.Text.StringBuilder();
    contentBuilder.AppendLine("E E E E E E E E");
    contentBuilder.AppendLine("E F F E E F F E");
    contentBuilder.AppendLine("E F F E E F F E");
    contentBuilder.AppendLine("E F F C C F F E");
    contentBuilder.AppendLine("E F F E E F F E");
    contentBuilder.AppendLine("E F F E E F F E");

    string content = contentBuilder.ToString();

    File.WriteAllText("Cache:\\temp\\sample.bspd", content);

  }

}
