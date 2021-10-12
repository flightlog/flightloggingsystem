﻿using System;
using System.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace FLS.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Formats multiple email addresses into comma-separated addresses to add to the email address collection.
        /// </summary>
        /// <param name="emailAddresses"></param>
        /// <returns></returns>
        public static string FormatMultipleEmailAddresses(this string emailAddresses)
        {
            var delimiters = new[] { ',', ';', ' ' };

            var addresses = emailAddresses.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            return string.Join(",", addresses);
        }

        public static string SanitizeFilename(this string filename)
        {
            var regexPattern = string.Format("[{0}]", Regex.Escape(new string(Path.GetInvalidFileNameChars())));
            var regex = new Regex(regexPattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);
            var result = regex.Replace(filename, string.Empty);
            return result;
        }

        public static string SanitizeEmailAddress(this string emailAddress, string separator = ";")
        {
            var regexPattern = string.Format("[{0}]", Regex.Escape(separator));
            var regex = new Regex(regexPattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);
            var result = regex.Replace(emailAddress, string.Empty);
            return result;
        }

        public static MailAddress ToMailAddress(this string emailAddress)
        {
            var mailAddress = new MailAddress(emailAddress);
            return mailAddress;
        }

        public static string ToBase64(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64ToString(this string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static Decimal ToDecimal(this string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0.0m;
            return Convert.ToDecimal(text);
        }
    }
}
