using System.Collections.Generic;
using System.IO;

namespace TextAnalysis
{
	static class FrequencyAnalysisTask
	{
		

		public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
		{                    

            var bigramsList = BigBuild(text);// создали лист со всеми биграмами

            var tempArr = new List<string>();
            foreach (var e in bigramsList)
            {
                tempArr.Add(e[0]  + ' ' + e[1] );
            }

            File.WriteAllLines("bigList.txt", tempArr);

            var bigramsDict = BigAmount(bigramsList);

            var countArr = new List<string>();
            foreach (var e in bigramsDict)
            {
               countArr.Add(e.Key + " - " + e.Value);
            }

            File.WriteAllLines("countList.txt", countArr);

            var wordsDictionary = SelectTheBest(bigramsDict);

            return wordsDictionary;
		}//основной метод


        public static List<string[]> BigBuild(List<List<string>> text)// возвращает лист всех возможных биграм 
        {

            List<string[]> bigramBuilder = new List<string[]>();

            foreach (var sentence in text)
            {   
                if (sentence.Count > 2)
                {
                    for (int i = 0; i < sentence.Count - 1; i++)
                    {
                        bigramBuilder.Add(new string[] { sentence[i], sentence[i + 1] });
                    }
                }
                else if (sentence.Count == 2)
                {
                    bigramBuilder.Add(new string[] { sentence[0], sentence[1] });                   
                }
            }

            return bigramBuilder;
        }//BigBuild()

        public static Dictionary<string, int> BigAmount(List<string[]> bigrams)//возвращает словарь, где ключ - это биграма, значение - ее количество в тексте
        {
            var bigramAmount = new Dictionary<string, int>();

            foreach (var e in bigrams)
            {
                var key = e[0] + " " + e[1];            

                if (!bigramAmount.ContainsKey(key))
                {
                    bigramAmount[key] = 1;                   
                    
                }
                else
                {
                    bigramAmount[key]++;
                }
            }

            return bigramAmount;
        }// BigAmount()

        public static Dictionary<string, string> SelectTheBest(Dictionary<string, int> dicton)
        {
            var finalDict = new Dictionary<string, string>();

            foreach (var e in dicton)
            {
                var key = e.Key.Split(' ');
                if (!finalDict.ContainsKey(key[0]))
                {
                    var bestBigram = ChoiseMaxBigram(dicton, key);
                    finalDict.Add(bestBigram[0], bestBigram[1]);
                }                
            }
            return finalDict;
        }//SelectTheBest()

        public static string[] ChoiseMaxBigram(Dictionary<string, int> dicton, string[] bigram)
        {
            foreach (var e in dicton)
            {
                var key = e.Key.Split(' ');
                var rank = 0;
                if (key[0] == bigram[0])
                {
                    if (e.Value >= rank)
                    {
                        bigram = key;
                        rank = e.Value;
                    }
                        
                }
            }

            return bigram;

        }//ChoiseMaxBigram()
    }
}

        /*
		Постройте по тексту словарь наиболее вероятного продолжения текста.

		Ключи этого словаря — это все слова, с которых начинается хотя бы одна биграмма исходного текста.
		В качестве значения должно быть второе слово самой частой биграммы, начинающейся с ключа.
		Если есть несколько биграмм с одинаковой частотой, то использовать лексикографически первую
		(используйте способ сравнения Ordinal, например с помощью метода string.CompareOrdinal).
		*/
