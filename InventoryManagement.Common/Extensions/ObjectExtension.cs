using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Common.Extensions
{
    public static class ObjectExtension
    {
        private static List<string> ImageContentTypes = new List<string> { "image/jpeg", "image/png", "image/jpg" };

        private static List<string> PdfContentTypes = new List<string> { "application/pdf" };

        private static List<string> BarCodeFileContentTypes = new List<string> { "text/csv", "application/vnd.ms-excel" };
        private static List<string> VoucherCodeFileContentTypes = new List<string> { "text/csv", "application/vnd.ms-excel" };

        public static void ThrowIfNull<T>(this T @object, string paramName)
        {
            if (@object == null)
            {
                throw new BusinessValidationException($"Parameter {paramName} cannot be null.");
            }
        }

        public static void ThrowIfNullOrEmpty(this string @object, string paramName)
        {
            if (string.IsNullOrEmpty(@object) || string.IsNullOrWhiteSpace(@object))
            {
                throw new BusinessValidationException($"Parameter {paramName} cannot be null.");
            }
        }

        public static void ThrowIfEmpty(this Guid @object, string paramName)
        {
            if (Guid.Empty == @object)
            {
                throw new BusinessValidationException($"Parameter {paramName} cannot be empty.");
            }
        }

        public static void ThrowIfNullOrEmpty(this Guid? @object, string paramName)
        {
            ThrowIfNull(@object, paramName);
            ThrowIfEmpty(@object.Value, paramName);
        }

        public static void ValidateImageContentType(this IEnumerable<string> listOfInputContentType)
        {
            if (listOfInputContentType.Any(contentType => !ImageContentTypes.Contains(contentType)))
            {
                throw new BusinessValidationException("Invalid file content type");
            }
        }

        public static void ValidateImageContentType(this string InputContentType)
        {
            if (!ImageContentTypes.Contains(InputContentType))
            {
                throw new BusinessValidationException("Invalid file content type");
            }
        }

        public static void ValidateFileContentType(this string InputContentType)
        {
            PdfContentTypes.AddRange(ImageContentTypes);
            if (!PdfContentTypes.Contains(InputContentType))
                throw new BusinessValidationException("Invalid file content type");
        }

        [Obsolete]
        public static void ThrowIfListEmpty<T>(this IEnumerable<T> list, string paramName)
        {
            list.ThrowIfNullOrEmpty(nameof(list));
        }

        public static void ThrowIfNullOrEmpty<T>(this IEnumerable<T> list, string paramName)
        {
            list.ThrowIfNull(nameof(list));
            if (!list.Any())
            {
                throw new BusinessValidationException($"Parameter {paramName} cannot be empty.");
            }
        }

        [Obsolete]
        public static bool ListIsNullOrEmpty<T>(this IEnumerable<T> @list)
        {
            return IsNullOrEmpty(list);
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> @list)
        {
            return @list == null || !@list.Any();
        }

        public static bool IsNullOrEmpty(this Guid? @object)
        {
            return (@object == null || Guid.Empty == @object);
        }

        public static bool IsNull<T>(this T @object)
        {
            return @object == null;
        }

        public static bool IsEmpty(this Guid @object)
        {
            return (Guid.Empty == @object);
        }

        public static bool IsNullOrEmpty(this string @object)
        {
            return string.IsNullOrWhiteSpace(@object);
        }

        public static string ToLowerString(this Guid guid)
        {
            return guid == Guid.Empty ? "" : guid.ToString().ToLower();
        }

        public static string ToLowerString(this Guid? guid)
        {
            return !guid.HasValue ? null : guid.Value.ToLowerString();
        }
    }
}