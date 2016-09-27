using System;

namespace Angular2MultiSPA.Helpers
{
    public static class ImageHelper
    {
        /// <summary>
        /// Convert images from byte array used MS Access/Northwind to a Base64 string, to allow easy display
        /// </summary>
        /// <param name="originalImage">image as a byte array, with offset</param>
        /// <returns>image base 64 encoded string</returns>
        public static string ConvertToBase64(this byte[] originalImage)
        {
            int offset = 78;
            return Convert.ToBase64String(originalImage, offset, originalImage.Length - offset);
        }
    }
}
