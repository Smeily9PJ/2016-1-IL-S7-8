namespace NS.CalviScript
{
    public interface IIdentifierExpr
    {
        T Accept<T>( IVisitor<T> visitor );
    }
}
