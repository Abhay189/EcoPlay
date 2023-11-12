using UnityEngine;

public class BinSwitcher : MonoBehaviour
{
    public GameObject[] bins;
    private int currentIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SwitchBin(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SwitchBin(-1);
        }
    }

    void SwitchBin(int direction)
    {
        // Calculate the new index
        int newIndex = (currentIndex + direction + bins.Length) % bins.Length;

        // Get the position of the current and new bins
        Vector3 currentPosition = bins[currentIndex].transform.localPosition;
        Vector3 newPosition = bins[newIndex].transform.localPosition;

        // Swap the positions
        bins[currentIndex].transform.localPosition = newPosition;
        bins[newIndex].transform.localPosition = currentPosition;

        // Update the currentIndex
        currentIndex = newIndex;

        // Perform any other necessary actions
        Debug.Log("Switched to Bin " + (currentIndex + 1));
    }
}
