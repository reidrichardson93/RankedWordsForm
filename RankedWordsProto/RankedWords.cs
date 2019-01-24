using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RankedWordsProto
{
    class RankedWords
    {
        public string[] wordsRanked {get; private set;}
        public int[] wordsCounted {get; private set;}
        private string[] userWords;
        


        public RankedWords(string text){
            string fileTxt = File.ReadAllText("C:\\temp\\Textfiles\\RankedWords.txt");
            wordsRanked = fileTxt.Split();
            wordsCounted = new int[wordsRanked.Length];
            string userText = text;
            char[] splitOn = {' ', '.', '?', '!', '\n'};
            userWords = userText.Split(splitOn, StringSplitOptions.RemoveEmptyEntries);
        }

        public double UserWordCount(){
            return userWords.Length;
        }


        public List<string> CompareWords(){
            List<string> wordMatch = new List<string>();
            for (int i = 0; i < userWords.Length; i++){
                for (int j = 0; j < wordsRanked.Length; j++){
                    if (userWords[i].ToLower() == wordsRanked[j].ToLower()){
                        if (wordsCounted[j] == 0){
                            wordMatch.Add(string.Format("{0} {1}", wordsRanked[j], (j+1)));
                        }
                        wordsCounted[j]++;
                    }
                }
            }
            return wordMatch;
        }

        public List<string> GetWordList(){
            List<string> wordList = new List<string>();
            for (int i = 0; i < wordsCounted.Length; i++){
                if (wordsCounted[i] > 0){
                    string formatted = string.Format("{0} {1}", wordsRanked[i], wordsCounted[i]);
                    wordList.Add(formatted);
                }
            }
            return wordList;
        }

        public double RankedWordsCount(){
            double total = 0;
            for (int i = 0; i < wordsCounted.Length; i++){
                total += wordsCounted[i];
            }
            return total;
        }



    }
}
