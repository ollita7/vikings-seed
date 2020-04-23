namespace Viking.Sdk
{
    public class RetornoDataOut
    {
        public RetornoDataOut() => Result = Retorno.Ok;

        public Retorno Result { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
    public enum Retorno
    {
        Ok,
        Error
    }
}