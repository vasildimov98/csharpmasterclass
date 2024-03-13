namespace CookieRecipe.Enums
{
    public class FileMetadata
    {
        private readonly string _name;
        private readonly FileFormat _format;

        public FileMetadata(string name, FileFormat format)
        {
            this._name = name;
            this._format = format;
        }

        public string FilePath => $"{this._name}.{this._format.GetExtention()}";
    }
}
