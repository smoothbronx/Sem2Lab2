namespace lab2;

public class LongLong
{
    public override int GetHashCode()
    {
        return HashCode.Combine(SeniorPart, JuniorPart);
    }

    public static readonly ulong MaxValue = (ulong)Math.Pow(2, 31) - 1;
    public readonly long SeniorPart;
    public readonly ulong JuniorPart;

    public LongLong(long number)
    {
        JuniorPart = (ulong)number >> 32;
        SeniorPart = number & 0xFFFFFFFF;
    }

    public void Display()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Number: {(long)(JuniorPart << 32) + (SeniorPart & 0xFFFFFFFF)} [{SeniorPart}, {JuniorPart}]";
    }

    private LongLong(long seniorPart, ulong juniorPart)
    {
        JuniorPart = juniorPart;
        SeniorPart = seniorPart;
    }

    public static LongLong operator +(LongLong a, LongLong b)
    {
        var senior = a.SeniorPart + b.SeniorPart;
        var junior = a.JuniorPart + b.JuniorPart;

        if (junior <= MaxValue) return new LongLong(senior, junior);
        return new LongLong(senior + 1, junior - MaxValue + 1);
    }

    public static LongLong operator -(LongLong a, LongLong b)
    {
        var senior = a.SeniorPart - b.SeniorPart;
        if (a.JuniorPart >= b.JuniorPart)
            return new LongLong(senior, a.JuniorPart - b.JuniorPart);
        return new LongLong(senior - 1, a.JuniorPart + MaxValue - b.JuniorPart);
    }

    public static LongLong operator *(LongLong a, LongLong b)
    {
        throw new NotImplementedException("Слишком запарно реализовывать");
    }

    public static LongLong operator /(LongLong a, LongLong b)
    {
        throw new NotImplementedException("Слишком запарно реализовывать");
    }

    public static LongLong operator %(LongLong a, LongLong b)
    {
        throw new NotImplementedException("Слишком запарно реализовывать");
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((LongLong)obj);
    }

    public static bool operator >(LongLong a, LongLong b)
    {
        if (a.SeniorPart > b.SeniorPart)
            return true;
        return a.JuniorPart > b.JuniorPart;
    }

    public static bool operator <(LongLong a, LongLong b)
    {
        if (a.SeniorPart < b.SeniorPart)
            return true;
        return a.JuniorPart < b.JuniorPart;
    }

    public static bool operator <=(LongLong a, LongLong b)
    {
        if (a.SeniorPart <= b.SeniorPart)
            return true;
        return a.JuniorPart <= b.JuniorPart;
    }

    public static bool operator >=(LongLong a, LongLong b)
    {
        if (a.SeniorPart >= b.SeniorPart)
            return true;
        return a.JuniorPart >= b.JuniorPart;
    }

    public static bool operator ==(LongLong a, LongLong b)
    {
        return a.JuniorPart == b.JuniorPart && a.SeniorPart == b.SeniorPart;
    }

    public static bool operator !=(LongLong a, LongLong b)
    {
        return !(a == b);
    }
}