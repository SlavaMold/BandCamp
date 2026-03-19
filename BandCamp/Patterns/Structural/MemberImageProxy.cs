using System.Drawing;

namespace BandCamp.Patterns.Structural
{
    public interface IMemberImage
    {
        Image GetPhoto();
    }

    public class RealMemberImage : IMemberImage
    {
        private readonly string _path;
        private Image _image;

        public RealMemberImage(string path)
        {
            _path = path;
        }

        public Image GetPhoto()
        {
            if (_image == null)
                _image = Image.FromFile(_path);
            return _image;
        }
    }

    public class MemberImageProxy : IMemberImage
    {
        private readonly string _path;
        private RealMemberImage _real;

        public MemberImageProxy(string path)
        {
            _path = path;
        }

        public Image GetPhoto()
        {
            if (string.IsNullOrEmpty(_path))
                return SystemIcons.Application.ToBitmap();

            if (_real == null)
                _real = new RealMemberImage(_path);

            return _real.GetPhoto();
        }
    }
}