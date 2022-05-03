/*
Fill a list of TMP fields with the names obtained from an API
To make the ScrollView content adjust to the contents, use this:
https://unitycoder.com/blog/2016/02/23/ui-scroll-view-automatic-content-height/
Gilberto Echeverria
*/

using UnityEngine;
using TMPro;

public class TMPro_Test : MonoBehaviour
{
    //[SerializeField] TextMeshProUGUI field;
    [SerializeField] GameObject textPrefab;
    [SerializeField] Transform contentTransform;

    public void LoadScores(ScoreList allScores)
    {
        Debug.Log("Trying to load scores");
        for (int i=0; i<allScores.score.Count; i++) {
            Debug.Log("PRINTING RESULTS SCORE");
            // Create new text objects
            GameObject textTMP = Instantiate(textPrefab);
            // Add them to the ScollView content
            textTMP.transform.SetParent(contentTransform);
            // Set the position of each element
            textTMP.GetComponent<RectTransform>().anchoredPosition =
                new Vector2 (0, 1 * i);
            // Extract the text from the argument object
            DBScore score = allScores.score[i];
            TextMeshProUGUI field = textTMP.GetComponent<TextMeshProUGUI>();
            field.text = "---------------------------\n" + "Score: " + score.total_score + " Life left: " + score.lost_life + 
                        " Damage taken: " + score.damage_taken +
                        " Damage inflicted: " + score.damage_inflicted;
            //Debug.Log("ID: " + us.id_users + " | " + us.name + " " + us.surname);
        }
    }
}