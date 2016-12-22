using System.Collections.Generic;

namespace TextAnalysis
{
	static class FrequencyAnalysisTask
	{
		

		public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
		{
            var wordsDictionary = new Dictionary<string,string>();

            var bigramsList = BigBuild(text);// создали лист со всеми биграмами

            var bigramsDict = BigAmount(bigramsList);

            wordsDictionary = SelectTheBest(bigramsDict);

            return wordsDictionary;
		}//основной метод


        public static List<string[]> BigBuild(List<List<string>> text)// возвращает лист всех возможных биграм 
        {

            List<string[]> bigramBuilder = new List<string[]>();

            foreach (var sentence in text)
            {                
                //List<List<string[]>> bigramList = new List<List<string[]>>();

                if (sentence.Count > 2)
                {
                    for (int i = 0; i < sentence.Count - 1; i++)
                    {
                        bigramBuilder.Add(new string[] { sentence[i], sentence[i + 1] });
                    }

                    //bigramList.Add(bigramBuilder);
                }
                else if (sentence.Count == 2)
                {
                    bigramBuilder.Add(new string[] { sentence[0], sentence[1] });
                    //bigramList.Add(list);
                }
            }

            return bigramBuilder;
        }//BigBuild()

        public static Dictionary<string[], int> BigAmount(List<string[]> bigrams)//возвращает словарь, где ключ - это биграма, значение - ее количество в тексте
        {
            var bigramAmount = new Dictionary<string[], int>();

            foreach (var e in bigrams)
            {
                if (!bigramAmount.ContainsKey(e))
                {
                    bigramAmount[e] = 1;
                }
                else
                {
                    bigramAmount[e]++;
                }
            }

            return bigramAmount;
        }// BigAmount()

        public static Dictionary<string, string> SelectTheBest(Dictionary<string[], int> dicton)
        {
            var finalDict = new Dictionary<string, string>();

            foreach (var e in dicton)
            {
                if (!finalDict.ContainsKey(e.Key[0]))
                {
                    var bestBigram = ChoiseMaxBigram(dicton, e.Key);
                    finalDict.Add(bestBigram[0], bestBigram[1]);
                }                
            }
            return finalDict;
        }//SelectTheBest()

        public static string[] ChoiseMaxBigram(Dictionary<string[], int> dicton, string[] bigram)
        {
            foreach (var e in dicton)
            {
                var rank = 0;
                if (e.Key[0] == bigram[0])
                {
                    if (e.Value >= rank)
                    {
                        bigram = e.Key;
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
