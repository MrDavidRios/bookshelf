using System;
using UnityEngine;

namespace Utils
{
    public static class LinkProcessing
    {
        public static string FormatLink(string unformattedLink)
        {
            string formattedUrl = unformattedLink.Trim().Replace(" ", "");

            // Add https:// if no protocol is specified
            if (!formattedUrl.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && 
                !formattedUrl.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                formattedUrl = "https://" + formattedUrl;
            }

            // Validate the URL format
            if (Uri.TryCreate(formattedUrl, UriKind.Absolute, out Uri uriResult) && 
                (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps) &&
                !string.IsNullOrWhiteSpace(uriResult.Host) &&
                uriResult.Host.Contains("."))
            {
                return formattedUrl;
            }

            // Handle invalid URL
            Debug.LogWarning("Invalid URL format: " + formattedUrl);
            return unformattedLink;
        }
    }
}