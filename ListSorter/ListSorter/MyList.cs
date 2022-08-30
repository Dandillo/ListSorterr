namespace ListSorter.Models
{
	public class MyList
    {
        public string[] Data { get; set; }
        public MyList(string tempTxt)
        {
            Data = tempTxt.Split(';');
        }

        private static void MergeSort(string[] arrayStrings)
        {
            if (arrayStrings.Length < 2)
            {
                return;
            }
            int middle = arrayStrings.Length / 2;
            string[] left = new string[middle];
            string[] right = new string[arrayStrings.Length - middle];

            for (var i = 0; i < middle; i++)
            {
                left[i] = arrayStrings[i];
            }
            for (var i = middle; i < arrayStrings.Length; i++)
            {
                right[i-middle] = arrayStrings[i];
            }
            MergeSort(left);
            MergeSort(right);
            Merge(arrayStrings, left, right);

        }

        private static void Merge(string[] result, string[] firstArray, string[] secondArray)
        {
            var firstArrayMinInd = 0;
            var secondArrayMinInd = 0;
            var resultArrayMinInd = 0;
            while (firstArrayMinInd < firstArray.Length && secondArrayMinInd < secondArray.Length)
            {
                if (string.Compare(firstArray[firstArrayMinInd], secondArray[secondArrayMinInd], StringComparison.Ordinal) <= 0)
                {
                    result[resultArrayMinInd] = firstArray[firstArrayMinInd];
                    firstArrayMinInd++;
                }
                else
                {
                    result[resultArrayMinInd] = secondArray[secondArrayMinInd];
                    secondArrayMinInd++;

                }
                resultArrayMinInd++;
            }

            while (firstArrayMinInd < firstArray.Length)
            {
                result[resultArrayMinInd] = firstArray[firstArrayMinInd];
                firstArrayMinInd++;
                resultArrayMinInd++;

            }

            while (secondArrayMinInd < secondArray.Length)
            {
                result[resultArrayMinInd] = secondArray[secondArrayMinInd];
                secondArrayMinInd++;
                resultArrayMinInd++;

            }
        }
        public void Sort(string selectedOpt)
        {
            if(selectedOpt == "asc")
                MergeSort(Data);
            else if (selectedOpt == "desc")
            {
                MergeSort(Data);
                Data = Data.Reverse().ToArray();
            }
            else if (selectedOpt == "reverse")
            {
                Data = Data.Reverse().ToArray();
            }

        }
    }
}
