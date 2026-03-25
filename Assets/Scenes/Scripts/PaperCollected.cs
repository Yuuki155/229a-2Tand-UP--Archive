using UnityEngine;

public class PaperCollected : MonoBehaviour
{
    public int paperCount = 0;

    public void AddPaper(int amount)
    {
        paperCount += amount;
        Debug.Log("Papers: " + paperCount);
    }
}
