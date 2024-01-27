Description
  Given a paragraph and a complete text, it’s required to calculate the plagiarism similarity of the
  given paragraph vs the given text. The Plagiarism similarity is defined as the max common
  subsequence of words between the given paragraph and EACH paragraph in the given text.
  Comparison is case IN-SENSITIVE (i.e. Cat = CAT = cat = CaT)

Definitions:
  1. Word: a set of continuous characters separated by space or tab (Words separator: ' ' or '\t')
  2. Paragraph in Text: any continuous set of words/chars ended by new line(s) (Paragraphs separator: '\n' or '\r')
  3. A subsequence of a given sequence is just the given sequence with some elements (possibly none) left out.

Requirements:
  Implement TWO functions,
    1. First function: return the value of the plagiarism similarity.
    2. Second function: return the subsequence (if any) or null.
   
Function:
  First Function:
    int SolveValue(string paragraph, string text)
    <returns>Plagiarism similarity between the query paragraph and the complete text

  Second Function:
    string[] ConstructSolution(string paragraph, string text)
    <returns>the common subsequence words themselves (if any) or null if no common words

Example
  paragraph = hello world how are you
  text = hello are you world how
  Plagiarism Similarity = 3
  Subsequence = hello are you
  paragraph = DP is a careful brute force and a complete D&C with overlapped subproblems
  text =
  Greedy has two conditions: optimal substructure and safe greedy choice
  DP has two conditions: optimal substructure (i.e. D&C) and overlapped subproblems
  Plagiarism Similarity = 3
  Subsequence = DP and overlapped (matched with 2nd paragraph)
  paragraph = Algorithms Analysis and Design
  text =
  ANALYSIS & DESIGN of ALGORITHMS
  System analysis and design
  Numerical Analysis
  Data Structures
  S/W DESIGN
  Plagiarism Similarity = 3
  Subsequence = analysis and design (matched with 2nd paragraph)
