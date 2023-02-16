

using AutoMapper;
using Reports.Application.Common.Mapping;
using Reports.Domain;

namespace Reports.Application.Reports.Queries.GetReportList
{
    public class ReportLookUpDto : IMapWith<Report>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Report, ReportLookUpDto>()
                .ForMember(noteDto => noteDto.Id,
                opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Title,
                opt => opt.MapFrom(note => note.Title));
        }
    }
}
