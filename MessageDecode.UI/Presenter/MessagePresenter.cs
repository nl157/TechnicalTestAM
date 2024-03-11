
using MessageDecode.Models;
using MessageDecode.Shared;
using MessageDecode.UI.Properties.Options;
using Microsoft.Extensions.Options;

namespace MessageDecode.UI.Presenter;

public class MessagePresenter : IMessagePresenter
{
    private readonly IOptions<DescriptionOptions> _descriptionOptions;

    public MessagePresenter(IOptions<DescriptionOptions> descriptionOptions)
    {
        _descriptionOptions = descriptionOptions;
    }


    public ServiceResult<List<SectionDescription>> Present(List<Section> sections)
    {
        if (sections == null || sections.Count != _descriptionOptions.Value.Description!.Count)
        {
            return new ServiceResult<List<SectionDescription>>(new Exception("Error when presenting Sections"));
        }

        return new ServiceResult<List<SectionDescription>>(sections.Zip(_descriptionOptions.Value.Description, (sectionDescription, value) =>
        {
            return new SectionDescription()
            {
                Description = value,
                Value = sectionDescription.Value!.ToString()!
            };
        }).ToList());
    }
}
