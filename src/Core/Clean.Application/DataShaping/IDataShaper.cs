using System.Dynamic;

namespace Clean.Application.DataShaping;

public interface IDataShaper<T>
{
    IEnumerable<ExpandoObject> ShapeDatas(IEnumerable<T> entities, string fieldsString);
    ExpandoObject ShapeData(T entity, string fieldsString);
}
