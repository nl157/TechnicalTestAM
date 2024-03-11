using MessageDecode.Models;
using MessageDecode.Shared;

namespace MessageDecode.UI.Presenter;
/// <summary>
/// Converts result data into a format suitable for the UI
/// </summary>
public interface IMessagePresenter
{
    /// <summary>
    /// Groups the Values of each section to the Descriptions stored in the appsettings.
    /// </summary>
    /// <param name="sections"> List of message segment values</param>
    /// <returns></returns>
    ServiceResult<List<SectionDescription>> Present(List<Section> sections);
}