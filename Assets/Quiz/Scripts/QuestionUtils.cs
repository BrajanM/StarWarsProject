using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class QuestionUtils 
{
    string path = Directory.GetCurrentDirectory();
    private static string questionsFileName = "/Quiz/Scripts/questions.csv";

    public static Questions[] LoadQuestionFile()
    {
        string filePath = Application.dataPath+questionsFileName;
        Questions[] results = new Questions[93];
        Encoding enc = Encoding.GetEncoding("utf-8");
        StreamReader questionReader = new StreamReader(filePath, enc);
        if (questionReader != null)
        {
            int line_number = 0;//Jeżleli w pierwszym wierszu są nazwy kolumn to ten wiersz musimy opuścić
            while (!questionReader.EndOfStream)
            {
                var line = questionReader.ReadLine();
                if (line_number > 0)
                {
                    var values = line.Split(';');
                    Questions question = new Questions();
                    question.questionText = values[0].ToString();
                    question.rightOption = values[1].ToString();
                    question.secondOption = values[2].ToString();
                    question.thirdOption = values[3].ToString();
                    question.fourthOption = values[4].ToString();
                    results[line_number-1] = question;
                }
                line_number++;
            }
            questionReader.Close(); 
    return results;
        }
        else
        {
            Debug.LogError("Can't load question file!");

            return null;
        }

    }    
}
