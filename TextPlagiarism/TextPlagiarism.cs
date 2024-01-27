using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class TextPlagiarism
    {
        #region YOUR CODE IS HERE

        #region FUNCTION#1: Calculate the Value
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given a paragraph and a complete text, find the plagiarism similarity of the give paragraph vs the given text.
        /// Plagiarism similarity = max common subsequence of words between the given paragraph and EACH paragraph in the given text
        /// Comparison is case IN-SENSITIVE (i.e. Cat = CAT = cat = CaT)
        /// Definitions:
        ///     Word: a set of continuous characters seperated by space or tab (Words seperator: ' ' '\t')
        ///     Paragraph in Text: any continuous set of words/chars ended by new line(s) (Paragraphs seperator: '\n' '\r')
        /// </summary>
        /// <param name="paragraph">query paragraph</param>
        /// <param name="text">complete text (consists of 1 or more paragraph(s)</param>
        /// <returns>Plagiarism similarity between the query paragraph and the complete text</returns>
        static public int SolveValue(string paragraph, string text)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            paragraph = paragraph.ToLower();
            text = text.ToLower();
            var paragraphs = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var Sum_Words = 0;
            foreach (var currentParagraph in paragraphs)
            {
                var currentWords = currentParagraph.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var sum = Common_Word(paragraph.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries), currentWords);
                if (sum > Sum_Words)
                {
                    Sum_Words = sum;
                }
            }
            return Sum_Words;
        }
        private static int Common_Word(string[] Pragraph_word, string[] Text_word)
        {
            var P_Length = Pragraph_word.Length;
            var T_Length = Text_word.Length;
            var Dynamic_Array = new int[P_Length + 1, T_Length + 1];
            for (int i = 1; i <= P_Length; i++)
            {
                for (int j = 1; j <= T_Length; j++)
                {
                    if (Pragraph_word[i - 1] == Text_word[j - 1])
                    {
                        Dynamic_Array[i, j] = Dynamic_Array[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        Dynamic_Array[i, j] = Math.Max(Dynamic_Array[i - 1, j], Dynamic_Array[i, j - 1]);
                    }
                }
            }
            return Dynamic_Array[P_Length, T_Length];
        }
        #endregion

        #region FUNCTION#2: Construct the Solution

        //Your Code is Here:
        //==================
        /// <returns>the common subsequence words themselves (if any) or null if no common words </returns>
        static public string[] ConstructSolution(string paragraph, string text)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            var paraghraph_Words = paragraph.ToLower().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var Sum_Words = 0;
            var max_Paragraph = "";
            foreach (var text_in_Paragraph in text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
            {
                var text_Words = text_in_Paragraph.ToLower().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                var sum = Common_Word(paraghraph_Words, text_Words);
                if (sum > Sum_Words)
                {
                    Sum_Words = sum;
                    max_Paragraph = text_in_Paragraph;
                }
            }
            if (Sum_Words == 0)
            {
                return null;
            }
            var max_Words = max_Paragraph.ToLower().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var Dynamic_Pro = new int[paraghraph_Words.Length + 1, max_Words.Length + 1];
            for (int i = 1; i <= paraghraph_Words.Length; i++)
            {
                for (int j = 1; j <= max_Words.Length; j++)
                {
                    if (paraghraph_Words[i - 1] == max_Words[j - 1])
                    {
                        Dynamic_Pro[i, j] = Dynamic_Pro[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        Dynamic_Pro[i, j] = Math.Max(Dynamic_Pro[i - 1, j], Dynamic_Pro[i, j - 1]);
                    }
                }
            }
            var subseq_of_words = new List<string>();
            var P_Length = paraghraph_Words.Length;
            var W_Length = max_Words.Length;
            while (P_Length > 0 && W_Length > 0)
            {
                if (paraghraph_Words[P_Length - 1] == max_Words[W_Length - 1])
                {
                    subseq_of_words.Add(paraghraph_Words[P_Length - 1]);
                    P_Length--;
                    W_Length--;
                }
                else if (Dynamic_Pro[P_Length - 1, W_Length] > Dynamic_Pro[P_Length, W_Length - 1])
                {
                    P_Length--;
                }
                else
                {
                    W_Length--;
                }
            }
            subseq_of_words.Reverse();
            return subseq_of_words.ToArray();
        }

        #endregion

        #endregion
    }
}
