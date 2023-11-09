using System.Reflection;

namespace FootballTeams.HelperClasses;

public class TeamHelper
{
    public static int CalculateHashCode<T>(T obj)
    {
        if (obj == null)
        {
            return 0;
        }

        int hashCode = 17;
        Type objType = typeof(T);
        PropertyInfo[] properties = objType.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            object value = property.GetValue(obj);
            hashCode = HashCode.Combine(hashCode, value);
        }

        return hashCode;
    }
}
