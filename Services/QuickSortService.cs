using numsortAPI.Interfaces;

namespace numsortAPI.Services
{
    public class QuickSortService : ISort
    {
        public double[] SortMyArray(double[] array)
        {
            Sort(array, 0, array.Length - 1);       //start the sorting with the whole array except the last number, which will be the first pivot.

            return array;
        }

        private void Sort(double[] arr, int start, int end)
        {
            int i;                                  //used to determine the start and the end of the partitions that are being sorted.
            if (start < end)                        //to not step over the boundaries of the partitions
            {
                i = Partition(arr, start, end);     //determine the position of the pivotal number

                Sort(arr, start, i - 1);            //recursion starts we start to sort the lower end of the partitions
                Sort(arr, i + 1, end);              //recursion continues and we start to sort the higher end of the partitions
            }
        }

        private int Partition(double[] arr, int start, int end)
        {
            double temp;
            double pivot = arr[end];                //pivot point is always the last number of the array
            int i = start - 1;                      //starting position is always lower than the index of the first element

            for (int j = start; j <= end - 1; j++)  //starting to go over the array
            {
                if (arr[j] < pivot)                 //if the number in the array is lower than the pivot
                {
                    i++;                            //increment the starting position
                    temp = arr[i];                  //save the higher number
                    arr[i] = arr[j];                //interchange the higher number with the lower number, which is placed before the pivot number
                    arr[j] = temp;                  //bring back the saved higher number in the place of the interchanged lower than the pivot number
                }
            }
                                                    //after the comparison of the array is done deal with the pivotal number
            temp = arr[i + 1];                      //save the number that goes first after every number that is lower than the pivotal number
            arr[i + 1] = arr[end];                  //in said number position place the pivotal number
            arr[end] = temp;                        //in the pivot number position place the previously saved number
            return i + 1;                           //return to the sorting method the position of the pivot number
        }
    }
}
