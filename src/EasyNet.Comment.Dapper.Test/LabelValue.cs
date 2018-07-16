
namespace EasyNet.Comment.Dapper.Test
{
    public class LabelValue
    {
        public LabelValue()
        {

        }
        public LabelValue(string label, string value)
        {
            this.label = label;
            this.value = value;
        }

        public string label { get; set; }

        //unique
        public string value { get; set; }
    }
}

