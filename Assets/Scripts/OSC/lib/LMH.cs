
public class LMH
{
    public enum LMHType
    {
        L,
        M,
        H
    }
    public LMHType type;
    public string address;
    public int value;

    public LMH(LMHType type, string address)
    {
        this.type = type;
        this.address = address;
        value = 0;
    }
}