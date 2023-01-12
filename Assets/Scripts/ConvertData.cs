/// <summary>
/// CSVから変換したデータのクラス
/// </summary>
public class ConvertData
{
    string _name;
    string _line;
    string _event;

    public ConvertData(string[] split)
    {
        _name = split[0];
        _line = split[1];
        _event = split[2];
    }

    public string Name { get => _name; }
    public string Line { get => _line; }
    public string Event { get => _event; }
}