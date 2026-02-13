using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] GameObject playerModel;

    public void Save(Vector3 playerPosition, Quaternion playerRotation, int score)
    {
        SavePosition savePosition = new SavePosition
        {
            position = playerPosition,
            rotation = playerRotation,
            score = score
        };

        string json = JsonUtility.ToJson(savePosition);
        File.WriteAllText(Application.persistentDataPath + "/save.txt", json);
    }

    // returns the loaded score so the Player script can use it
    public int Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.txt"))
        {
            string loadFile = File.ReadAllText(Application.persistentDataPath + "/save.txt");
            SavePosition savePosition = JsonUtility.FromJson<SavePosition>(loadFile);

            playerModel.transform.position = savePosition.position;
            playerModel.transform.rotation = savePosition.rotation;

            return savePosition.score;
        }
        else
        {
            playerModel.transform.position = Vector3.zero;
            playerModel.transform.rotation = Quaternion.identity;

            return 0;
        }
    }
}

[System.Serializable]
public class SavePosition
{
    public Vector3 position;
    public Quaternion rotation;
    public int score; // ADDED
}
