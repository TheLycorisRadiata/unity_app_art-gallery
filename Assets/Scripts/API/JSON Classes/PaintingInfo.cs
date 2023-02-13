[System.Serializable]
public class PaintingInfo
{
    public string title, artist, year, description;

    public PaintingInfo(string _title, string _artist, string _year, string _description)
    {
        title = _title;
        artist = _artist;
        year = _year;
        description = _description;
    }
}
