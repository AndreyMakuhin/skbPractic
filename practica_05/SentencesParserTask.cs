/*
		Разбейте файл с текстом на предложения и слова. 
		Считайте, что слова могут состоять только из букв (используйте метод char.IsLetter) или символа апострофа ',
		а предложения разделены одним из следующих символов .!?;:()
		Удалите из файла слова, содержащиеся в массиве StopWords (частые незначащие слова при анализе текстов называют стоп-словами)
		Метод должен возвращать список предложений, где каждое предложение — это список оставшихся слов в нижнем регистре.
		*/
using System.Collections.Generic;
using System.Text;

namespace TextAnalysis
{
	static class SentencesParserTask
	{
		public static readonly string[] StopWords = { "the", "and", "to", "a", "of", "in", "on",
                                                    "at","that", "as", "but", "with", "out",
                                                    "for", "up", "one", "from", "into" };

		
		public static List<List<string>> ParseSentences(string text)
		{
            var razdelitel = new char[] { '.','!','?',';',':','(',')'/*,'\n'*/};// a - b ^ c#d~e   
            var finalList = new List<List<string>>();
                       
            var pArr = text.Split(razdelitel);//Разбивка на предложения          

            foreach (var pr in pArr)//разбивка на слова
            {                
                var words = pr.Split(new char[] {' ', '-', '^', '#', '~', '—', ',', '…' });

                var item = BuildWordList(words);

                if (item != null)
                    finalList.Add(item);
            }            
            
            return finalList;
		}

        static string BuildWord(string w)//построение слова, чтобы выкинуть ненужные знаки
        {
            var wordBuild = new StringBuilder();
            foreach (var c in w)
            {
                if (char.IsLetter(c) || c == '\'')
                {
                    wordBuild.Append(c);
                }
            }

            return wordBuild.ToString().ToLower();
        }

        static bool IsStopper(string word)//Проверка на стоп слова
        {
            foreach (var s in StopWords)
            {
                if (s == word)
                {
                    return true;                   
                }
            }

            return false;
        }

        static List<string> BuildWordList(string[] words)
        {
            var wList = new List<string>();
            

            foreach (var w in words)
            {               
                var word = BuildWord(w);                

                if (word.Length != 0)
                    wList.Add(word);
            }

            if (wList.Count == 0)
                //return null;
                return new List<string>();
            else
            {
                return RemoveStopWords(wList);
            }               
        }

        static List<string> RemoveStopWords(List<string> wordsList)
        {            
            for (int i = 0; i < wordsList.Count; i++)
            {
                if (IsStopper(wordsList[i]) /*&& wordsList.Count > 1*/)
                {
                    wordsList.RemoveAt(i);
                    i = -1;
                }
            }

            return wordsList;
        }

	}
}