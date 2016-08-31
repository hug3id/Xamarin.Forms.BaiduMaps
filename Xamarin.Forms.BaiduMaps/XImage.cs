using System.IO;

namespace Xamarin.Forms.BaiduMaps
{
    internal enum ImageSource
    {
        File,
        Stream,
        Bundle,
        Resource
    }

    public sealed class XImage
    {
        internal ImageSource Source { get; private set; }
    
        internal string FileName { get; private set; }
        internal Stream Stream { get; private set; }
        internal string BundleName { get; private set; }
        internal string ResourceName { get; private set; }

        private XImage() {}

        public static XImage FromBundle(string bundleName)
        {
            return new XImage {
                Source = ImageSource.Bundle,
                BundleName = bundleName
            };
        }

        public static XImage FromFile(string fileName)
        {
            return new XImage {
                Source = ImageSource.File,
                FileName = fileName
            };
        }

        public static XImage FromResource(string resName)
        {
            return new XImage {
                Source = ImageSource.Resource,
                ResourceName = resName
            };
        }

        public static XImage FromStream(Stream stream) {
            return new XImage {
                Source = ImageSource.Stream,
                Stream = stream
            };
        }
    }
}

