namespace wayeal.validate
{
    public class ValidateResult
    {
        public string ErrorTextKey { get; set; }
        public bool Valid { get; set; }

    }

    public interface IValidate
    {
        ValidateResult Validate(object value);
        ValidateResult Validate(string pattern, object value);
    }
}
