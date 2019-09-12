using System;

namespace ListProject
{
    class List
    {
        public static int?[] list = new int?[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, null };

        #region [Public Methods]
        /// <summary>
        /// Read the value present at a particular index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int? ReadElementFromList(int index)
        {
            try
            {
                if (list != null)
                {
                    return list[index];
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// This method handles the value insertion in the array
        /// </summary>
        /// <param name="valueToWrite"></param>
        /// <param name="indexToWriteAt"></param>
        public static void InsertElementToList(int valueToWrite, int indexToWriteAt)
        {
            // There's no point of insertion if index provided is negative value
            if (indexToWriteAt < 0)
            {
                return;
            }
            if (list != null)
            {
                int indexWhereNewElementCanBeAdded = list.Length;
                // Check whether array is full
                if (isArrayFull())
                {
                    // First store the index from the already full list, 
                    // where new element can be added in new list
                    indexWhereNewElementCanBeAdded = list.Length;

                    // Now call handleArrayFullCondition() method
                    handleArrayFullCondition();
                }
                // Check if we want to write at the end, 
                // even if the index provided is greater than size of the array
                // and array can take value, we will insert value at the end of the array.
                if (indexToWriteAt >= indexWhereNewElementCanBeAdded)
                {
                    list[indexWhereNewElementCanBeAdded] = valueToWrite;
                }
                else
                {
                    // Call the shifting function to accomodate value at the required index
                    accomodateValueInListByShifting(valueToWrite, indexToWriteAt);
                }
            }
            return;
        }

        /// <summary>
        /// Updates a value in the array at a particular index
        /// </summary>
        /// <param name="newValue"></param>
        /// <returns></returns>
        public static string UpdateElementInList(int newValue, int index)
        {
            try
            {
                if (list != null && index < list.Length && list[index] != null)
                {
                    list[index] = newValue;
                    return "Update Successful";
                }
                return "Update filed";
            }
            catch (Exception ex)
            {
                return "Update failed. " + ex.Message;
            }
        }
        #endregion

        #region [Private Methods]
        /// <summary>
        /// Checks if List is full
        /// </summary>
        /// <returns></returns>
        private static bool isArrayFull()
        {
            if (list != null && list[list.Length - 1] != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Return the index of the last element of the array
        /// It returns null if list is null
        /// </summary>
        /// <returns></returns>
        private static int? findLastElementIndexOfList()
        {
            if (list != null)
            {
                int lastElementIndex = 0;
                for (int i = 0; i < list.Length; i++)
                {
                    if (list[i] != null)
                    {
                        lastElementIndex = i;
                    }
                    break;
                }
                return lastElementIndex;
            }
            return null;
        }

        /// <summary>
        /// Create new array, copy old elements in new array. 
        /// Now set the old array as the new one (ex- list = newList)
        /// After the scope of the method is over,
        /// the memory of the array created inside the method will be free.
        /// </summary>
        private static void handleArrayFullCondition()
        {
            if (list != null)
            {
                // Create new array of twice the size of old
                int?[] newList = new int?[2 * (list.Length)];

                // Copy elements
                for (int i = 0; i < list.Length; i++)
                {
                    newList[i] = list[i];
                }

                // Set old list as new
                // The memory of new will be released after scope of method is over
                list = newList;
            }
        }

        /// <summary>
        /// This method accomodates vlues in an array based on the index provided
        /// It has a precondition that list is not null 
        /// And we are not talking about inserting value at the end
        /// </summary>
        /// <param name="valueToWrite"></param>
        /// <param name="indexToAccomodateAt"></param>
        private static void accomodateValueInListByShifting(int? valueToWrite, int indexToAccomodateAt)
        {
            int? temp;
            do
            {
                temp = list[indexToAccomodateAt];
                list[indexToAccomodateAt] = valueToWrite;
                valueToWrite = temp;
                indexToAccomodateAt++;
            } while (temp != null);
        }
        #endregion
    }
}
