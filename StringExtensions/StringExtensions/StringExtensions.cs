using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;

namespace StringExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Used as an optional input parameter to the string extension method 'convertPascalOrCamelCaseToWords()'
        /// </summary>
        public enum WordCase
        {
            AllLower = 0,
            AllUpper = 1,
            Title = 2,
            Sentence = 3
        }

        /// <summary>
        /// Convert text from Pascal or Camel Case to words, helpful when parsing enum names to text fit for display in a user interface
        /// </summary>
        /// <param name="input"></param>
        /// <returns>words</returns>
        public static string convertPascalOrCamelCaseToWords(this string input)
        {
            try
            {
                return convertToWords(input);
            }
            catch (Exception ex)
            {
                Exception except = new Exception(string.Format("Exception throw in {0}.{1} -- Inner Exception:\n  {2}", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message), ex);
                throw except;
            }
        }

        /// <summary>
        /// Convert text from Pascal or Camel Case to words in the given case, helpful when parsing enum names to text fit for display in a user interface
        /// </summary>
        /// <param name="input"></param>
        /// <param name="wordCase"></param>
        /// <returns>words</returns>
        public static string convertPascalOrCamelCaseToWords(this string input, WordCase wordCase)
        {
            try
            {
                string output = convertToWords(input);
                switch (wordCase)
                {
                    case WordCase.AllLower:
                        output = output.ToLower();
                        break;
                    case WordCase.AllUpper:
                        output = output.ToUpper();
                        break;
                    case WordCase.Title:
                        output = output.ToTitleCase();
                        break;
                    case WordCase.Sentence:
                        output = output.ToSentenceCase();
                        break;
                    default:
                        break;
                }
                return output;
            }
            catch (Exception ex)
            {
                Exception except = new Exception(string.Format("Exception throw in {0}.{1} -- Inner Exception:\n  {2}", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message), ex);
                throw except;
            }
        }

        /// <summary>
        /// Convert text from Pascal or Camel Case to words, helpful when parsing enum names to text fit for display in a user interface
        /// </summary>
        /// <param name="input"></param>
        /// <returns>words</returns>
        private static string convertToWords(string input)
        {
            try
            {
                string pattern = "(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])";
                return Regex.Replace(input, pattern, " ").RemoveExcessWhiteSpace();
            }
            catch (Exception ex)
            {
                Exception except = new Exception(string.Format("Exception throw in {0}.{1} -- Inner Exception:\n  {2}", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message), ex);
                throw except;
            }
        }

        /// <summary>
        /// String extension method to convert a string to title case
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string input)
        {
            try
            {
                input = input.ToLower();
                return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(input);
            }
            catch (Exception ex)
            {
                Exception except = new Exception(string.Format("Exception throw in {0}.{1} -- Inner Exception:\n  {2}", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message), ex);
                throw except;
            }
        }

        /// <summary>
        /// String extension method to convert a string to sentence case
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ToSentenceCase(this string input)
        {
            try
            {
                string sentence = input.ToLower().TrimStart();
                if (sentence.Length <= 1) return sentence.ToUpper();
                return sentence.Remove(1).ToUpper() + sentence.Substring(1);
            }
            catch (Exception ex)
            {
                Exception except = new Exception(string.Format("Exception throw in {0}.{1} -- Inner Exception:\n  {2}", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message), ex);
                throw except;
            }
        }

        /// <summary>
        /// String extension method to remove excess white space
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveExcessWhiteSpace(this string input)
        {
            try
            {
                return Regex.Replace(input, @"\s+", " ").Trim();
            }
            catch (Exception ex)
            {
                Exception except = new Exception(string.Format("Exception throw in {0}.{1} -- Inner Exception:\n  {2}", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message), ex);
                throw except;
            }
        }

        /// <summary>
        /// String extension method to convert a string to camelCase
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string convertToCamelCase(this string input)
        {
            try
            {
                input.ToTitleCase();
                input = input.Remove(1).ToLower() + input.Substring(1);
                return Regex.Replace(input, @"\s+", string.Empty).Trim();
            }
            catch (Exception ex)
            {
                Exception except = new Exception(string.Format("Exception throw in {0}.{1} -- Inner Exception:\n  {2}", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message), ex);
                throw except;
            }
        }

        /// <summary>
        /// String extension method to convert a string to PascalCase
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string convertToPascalCase(this string input)
        {
            try
            {
                input.ToTitleCase();
                return Regex.Replace(input, @"\s+", string.Empty).Trim();
            }
            catch (Exception ex)
            {
                Exception except = new Exception(string.Format("Exception throw in {0}.{1} -- Inner Exception:\n  {2}", MethodBase.GetCurrentMethod().DeclaringType.FullName, MethodBase.GetCurrentMethod().Name, ex.Message), ex);
                throw except;
            }
        }
    }
}
/*
    Copyright 2016 Matthew Sanaker, matthew@sanaker.com, @msanaker on GitHub
    
    This file is part of 'StringExtensions'.

    'StringExtensions' is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    'StringExtensions' is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with StringExtensions.  If not, see <http://www.gnu.org/licenses/>.
*/
