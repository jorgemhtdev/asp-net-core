namespace ASP.NET_Core_Backend.TagHelpers
{
    using Microsoft.AspNetCore.Razor.TagHelpers;

    [HtmlTargetElement(Attributes = nameof(Active))]
    public class ActiveTagHelper : TagHelper
    {
        public bool Active { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!Active)
            {
                output.SuppressOutput();
            }
        }
    }
}
