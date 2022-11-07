using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RainbowApiAdapter;
using RainbowApiAdapter.Dto;

namespace TestRainbow.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly RainbowApiProvider _provider;

        public DataController(RainbowApiProvider provider)
        {
            _provider = provider;
        }

        [HttpGet]
        [Route("document/{id:long}")]
        public async Task<FileResult> Document(long id)
        {
            var result = await _provider.GetDocument(id);

            if (result == null) return new FileContentResult(null, "text/csv");
            var bytes = await ConvertToByteArray(result);
            return File(bytes, "text/csv", "document" );
        }

        [HttpGet]
        [Route("boxes/{id}")]
        public async Task<FileResult> Boxes(string id)
        {
            var list = await _provider.GetRouteBoxes(id);

            if (list == null) return new FileContentResult(null, "text/csv");
            var bytes = await ConvertToByteArray(list);
            return File(bytes, "text/csv", "boxes");
        }

        private async Task<byte[]> ConvertToByteArray(DocumentListDto.Datum[] data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var row in data)
            {
                sb.AppendLine($"{row.nom_route}, {row.id_hd_route}, {row.id_pos}, {row.id_record}, {row.nom_nakl}, {row.nom_zak}");
            }
            string a = sb.ToString();
            var bytes = Encoding.UTF8.GetBytes(a);
            return bytes;
        }
        private async Task<byte[]> ConvertToByteArray(DocumentDto data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var row in data.data.data2)
            {
                sb.AppendLine($"{row.pos_category_name}, {row.good_qty} , {row.id_pos}, {row.id_good_nakl} ,{row.id_hd_nakl}");
            }
            string a = sb.ToString();
            var bytes = Encoding.UTF8.GetBytes(a);
            return bytes;
        }
    }
}
