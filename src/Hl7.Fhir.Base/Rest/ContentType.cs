﻿#nullable enable

/* 
 * Copyright (c) 2014, Firely (info@fire.ly) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-net-sdk/master/LICENSE
 */

using Hl7.Fhir.Utility;
using System;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Hl7.Fhir.Rest
{
    /// <summary>
    /// The supported formats for Fhir Resources
    /// </summary>
    public enum ResourceFormat
    {
        Xml = 1,
        Json = 2,
        Unknown = 3
    }

    public static class ContentType
    {
        public const string FORM_URL_ENCODED = "application/x-www-form-urlencoded";
        public const string JSON_CONTENT_HEADER = "application/fhir+json";  // The formal FHIR mime type (still to be registered).

        public static readonly string[] JSON_CONTENT_HEADERS = new string[]
            { JSON_CONTENT_HEADER,
                "text/json",
                "application/json",
                "application/json+fhir" }; // for backward compatability/tolerance

        public const string XML_CONTENT_HEADER = "application/fhir+xml";   // The formal FHIR mime type (still to be registered).

        public static readonly string[] XML_CONTENT_HEADERS = new string[]
            { XML_CONTENT_HEADER,
                "text/xml",
                "text/xml+fhir", // for backward compatability / tolerance
                "application/xml",
                "application/xml+fhir" }; // for backward compatability / tolerance

        public const string FORMAT_PARAM_XML = "xml";
        public const string FORMAT_PARAM_JSON = "json";

        public const string VERSION_CONTENT_HEADER_NAME = "fhirVersion";

        [Obsolete("Use VERSION_CONTENT_HEADER_NAME instead.")]
        public const string VERSION_CONTENT_HEADER = "fhirVersion=";

        public static string DecompressionMethodHeaderValue(DecompressionMethods method) =>
            method.ToString().ToLowerInvariant();

        /// <summary>
        /// Converts a format string to a ResourceFormat
        /// </summary>
        /// <param name="format">A format string, as used by the _format Url parameter</param>
        /// <returns>The Resource format or the special value Unknow if the format was unrecognized</returns>
        public static ResourceFormat GetResourceFormatFromFormatParam(string? format)
        {
            if (string.IsNullOrEmpty(format)) return ResourceFormat.Unknown;

            var f = format!.ToLowerInvariant().Replace(" ", "+"); // spaces on the are decoded from the +, so convert them back

            if (f == FORMAT_PARAM_JSON || JSON_CONTENT_HEADERS.Contains(f))
                return ResourceFormat.Json;
            else if (f == FORMAT_PARAM_XML || XML_CONTENT_HEADERS.Contains(f))
                return ResourceFormat.Xml;
            else
                return ResourceFormat.Unknown;
        }


        /// <summary>
        /// Converts a content type to a ResourceFormat
        /// </summary>
        /// <param name="contentType">The content type, as it appears on e.g. a Http Content-Type header</param>
        /// <returns></returns>
        public static ResourceFormat GetResourceFormatFromContentType(string? contentType)
        {
            if (string.IsNullOrEmpty(contentType)) return ResourceFormat.Unknown;

            var f = GetMediaTypeFromHeaderValue(contentType!);

            if (JSON_CONTENT_HEADERS.Contains(f))
                return ResourceFormat.Json;
            else if (XML_CONTENT_HEADERS.Contains(f))
                return ResourceFormat.Xml;
            else
                return ResourceFormat.Unknown;
        }

        /// <summary>
        /// Creates a string for use in a Content-Type header, given the serialization format and the fhir version in use.
        /// </summary>
        /// <param name="format">Whether the body is xml or json.</param>
        /// <param name="fhirVersion">Optional. The version of FHIR to add to the header.</param>
        public static string BuildContentType(ResourceFormat format, string? fhirVersion = default) =>
            BuildMediaType(format, fhirVersion).ToString();

        /// <summary>
        /// Creates a <see cref="MediaTypeHeaderValue"/> for use in a Content-Type header, 
        /// given the serialization format and the fhir version in use.
        /// </summary>
        /// <param name="format">Whether the body is xml or json.</param>
        /// <param name="fhirVersion">Optional. The version of FHIR to add to the header.</param>
        /// <exception cref="ArgumentException">Unsupported serialization.</exception>
        public static MediaTypeHeaderValue BuildMediaType(ResourceFormat format, string? fhirVersion = default)
        {
            var contentType = format switch
            {
                ResourceFormat.Json => JSON_CONTENT_HEADER,
                ResourceFormat.Xml => XML_CONTENT_HEADER,
                _ => throw new ArgumentException("Cannot determine content type for data format " + format),
            };

            var result = new MediaTypeHeaderValue(contentType)
            {
                CharSet = Encoding.UTF8.WebName
            };

            if (fhirVersion is not null && SemVersion.TryParse(fhirVersion, out var version))
            {
                var majorMinor = version.Major + "." + version.Minor;
                result.Parameters.Add(new(VERSION_CONTENT_HEADER_NAME, majorMinor));
            }

            return result;
        }

        /// <summary>
        /// Returns the string to use for the _format parameter in a FHIR REST url, given the desired serialization.
        /// </summary>
        /// <param name="format"></param>
        /// <exception cref="ArgumentException">Unsupported serialization.</exception>
        public static string BuildFormatParam(ResourceFormat format) =>
            format switch
            {
                ResourceFormat.Json => FORMAT_PARAM_JSON,
                ResourceFormat.Xml => FORMAT_PARAM_XML,
                _ => throw new ArgumentException("Cannot determine content type for data format " + format)
            };

        /// <summary>
        /// Checks whether a given content type is valid as a content type for resource data
        /// </summary>
        /// <param name="contentType">The content type, as it appears on e.g. a Http Content-Type header</param>
        /// <returns></returns>
        public static bool IsValidResourceContentType(string contentType)
        {
            var f = ContentType.GetMediaTypeFromHeaderValue(contentType);

            return JSON_CONTENT_HEADERS.Contains(f) || XML_CONTENT_HEADERS.Contains(f);
        }

        /// <summary>
        /// Checks whether a given format parameter is a valid as a content type for resource data
        /// </summary>
        /// <param name="paramValue">The content type, as it appears on the URL parameter</param>
        /// <returns></returns>
        public static bool IsValidFormatParam(string paramValue)
        {
            return GetResourceFormatFromFormatParam(paramValue) != ResourceFormat.Unknown;
        }


        public static string GetMediaTypeFromHeaderValue(string mediaHeaderValue)
        {
            try
            {
                var ct = new System.Net.Mime.ContentType(mediaHeaderValue);
                return ct.MediaType.ToLowerInvariant();
            }
            catch (System.FormatException)
            {
                return mediaHeaderValue;
            }
        }

        public static string? GetCharSetFromHeaderValue(string mediaHeaderValue) =>
            new System.Net.Mime.ContentType(mediaHeaderValue).CharSet;
    }
}

#nullable restore