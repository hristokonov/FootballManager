using FM.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FM.Core
{
    public static class  InputValidations
    {
        public const int MIN_NAME = 3;
        public const int MAX_NAME = 30;
        public const int MIN_RATING = 0;
        public const int MAX_RATING = 100;
        public const int MIN_POSITION = 1;
        public const int MAX_POSITION = 4;
        public const int MIN_STADIUM = 0;
        public const int MAX_STADIUM = 200000;
        //public const int MIN_COURSENAME = 3;
        //public const int MAX_COURSENAME = 50;
        //public const int MIN_ASS = 3;
        //public const int MAX_ASS = 50;
        //public const int MIN_PASSWORD = 3;
        //public const int MAX_PASSWORD = 35;
        public static void ValidateLength(int min, int max, string input, string message)
        {
            if (input.Length < min || input.Length > max)
            {
                throw new ArgumentOutOfRangeException("", message);
            }
        }
        public static int ValidateRatingConversion(int min,int max,string ratingForCheck,string message)
        {
            bool isRatingConvertable = int.TryParse(ratingForCheck, out var rating);
            if (!isRatingConvertable)
            {
                throw new RatingCannotBeConvertedException(message);
            }
            if (rating < min || rating > max)
            {
                throw new ArgumentOutOfRangeException("", message);
            }
            
            return rating;
        }


    }
}
