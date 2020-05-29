namespace DanhoLibrary.SQL
{
    public class Column
    {
        public object Value;
        public readonly string Name;
        private readonly int MaxCharacters;
        public readonly bool Nullable;

        public Column(string name, SQLDataTypes type, int maxCharacters, bool nullable)
        {
            Name = name;
            Value = type;
            MaxCharacters = maxCharacters;
            Nullable = nullable;
        }
        public Column(string name, SQLDataTypes type, bool nullable)
        {
            if (type is SQLDataTypes.VARCHAR) MaxCharacters = 50;
            Name = name;
            Value = type;
            Nullable = nullable;
        }

        public override string ToString()
        {
            string result = $"{Name}, ";
            if (Value is SQLDataTypes.VARCHAR) result += $"VARCHAR({MaxCharacters})";
            else result += SQLDataTypes.INT;
            if (!Nullable) result += $", NOT NULL";
            return result;
        }
    }
    public enum SQLDataTypes { INT, VARCHAR }
}
