/*### 문제 1. 세이브 파일 관리자

`Application.persistentDataPath` 아래의 세이브 폴더를 탐색하여 저장된 파일 정보를 출력하고, 특정 파일을 복사/삭제할 수 있는 스크립트를 작성하시오.

**요구사항**

1. **세이브 폴더 준비**: `SaveData` 폴더를 만들고, `File.WriteAllText`로 테스트용 파일 3개를 생성할 것
   - `save1.txt`, `save2.txt`, `save3.txt` (내용은 자유)
2. **파일 목록 출력**: `Directory.GetFiles`로 폴더 내 모든 파일을 조회하고, 각 파일의 이름과 확장자를 출력할 것
3. **파일 복사**: `save1.txt`를 `save1_backup.txt`로 복사할 것 (`File.Copy`)
4. **파일 삭제**: `save3.txt`를 삭제할 것 (`File.Delete`)
5. **최종 확인**: 작업 후 파일 목록을 다시 출력하여 결과를 확인할 것

**예상 출력**

```
=== 세이브 파일 목록 ===
- save1.txt (.txt)
- save2.txt (.txt)
- save3.txt (.txt)
save1.txt → save1_backup.txt 복사 완료
save3.txt 삭제 완료
=== 작업 후 파일 목록 ===
- save1.txt (.txt)
- save1_backup.txt (.txt)
- save2.txt (.txt)
```*/

using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    string saveDir;
    string save1Path;
    string save2Path;
    string save3Path;
    string copyPath;

    string saveData1;
    string saveData2;
    string saveData3;

    private void Start()
    {
        saveDir = Path.Combine(Application.persistentDataPath, "SaveData");
        save1Path = Path.Combine(Application.persistentDataPath, "SaveData", "save1.txt");
        save2Path = Path.Combine(Application.persistentDataPath, "SaveData", "save2.txt");
        save3Path = Path.Combine(Application.persistentDataPath, "SaveData", "save3.txt");
        copyPath = Path.Combine(Application.persistentDataPath, "SaveData", "save1_backup.txt");

        saveData1 = "save-01";
        saveData2 = "save-02";
        saveData3 = "save-03";
    }

    private void Update()
    {      
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
                Debug.Log($"폴더 생성: {saveDir}");
            }
            else
            {
                Debug.Log("폴더가 이미 존재함");
            }

            File.WriteAllText(save1Path, saveData1);
            Debug.Log("save1 완료");

            File.WriteAllText(save2Path, saveData2);
            Debug.Log("save2 완료");

            File.WriteAllText(save3Path, saveData3);
            Debug.Log("save3 완료");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("=== 세이브 파일 목록 ===");
            string[] files = Directory.GetFiles(saveDir);
            foreach (string file in files)
            {
                Debug.Log($"- {Path.GetFileName(file)} ({Path.GetExtension(file)})");
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!File.Exists(copyPath))
            {
                File.Copy(save1Path, copyPath);
                Debug.Log($"{save1Path} → {copyPath} 복사 완료");
            }
            else
            {
                Debug.Log($"카피 파일 이미 존재함");
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (File.Exists(save3Path))
            {
                File.Delete(save3Path);
                Debug.Log($"{save3Path} 삭제 완료");
            }
            else
            {
                Debug.Log("save3 이미 삭제됨");
            }
        }

        if (Input.GetKeyDown (KeyCode.R))
        {
            Debug.Log("=== 작업 후 파일 목록 ===");
            string[] files = Directory.GetFiles(saveDir);
            foreach (string file in files)
            {
                Debug.Log($"- {Path.GetFileName(file)} ({Path.GetExtension(file)})");
            }
        }
    }
}
