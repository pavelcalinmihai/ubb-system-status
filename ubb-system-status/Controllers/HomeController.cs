using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using ubb_system_status.Models;

namespace ubb_system_status.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        #region URL
        private readonly string ubb = String.Empty;
        private readonly string academicInfo = String.Empty;
        private readonly string platformaAdmitere = String.Empty;
        private readonly string cs = String.Empty;
        private readonly string phys = String.Empty;
        private readonly string chem = String.Empty;
        private readonly string biogeo = String.Empty;
        private readonly string geografie = String.Empty;
        private readonly string law = String.Empty;
        private readonly string litere = String.Empty;
        private readonly string socasis = String.Empty;
        private readonly string psiedu = String.Empty;
        private readonly string econ = String.Empty;
        private readonly string fspac = String.Empty;
        private readonly string euro = String.Empty;
        private readonly string tbs = String.Empty;
        private readonly string sport = String.Empty;
        private readonly string ot = String.Empty;
        private readonly string rt = String.Empty;
        private readonly string gct = String.Empty;
        private readonly string rocateo = String.Empty;
        private readonly string teatruFilm = String.Empty;
        private readonly string eng = String.Empty;
        #endregion

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

            ubb = _configuration.GetSection("UBB")["UBB"].ToString();
            academicInfo = _configuration.GetSection("UBB")["AcademicInfo"].ToString();
            platformaAdmitere = _configuration.GetSection("UBB")["PlatformaAdmitere"].ToString();
            cs = _configuration.GetSection("UBB")["Cs"].ToString();
            phys = _configuration.GetSection("UBB")["Phys"].ToString();
            chem = _configuration.GetSection("UBB")["Chem"].ToString();
            biogeo = _configuration.GetSection("UBB")["Biogeo"].ToString();
            geografie = _configuration.GetSection("UBB")["Geografie"].ToString();
            law = _configuration.GetSection("UBB")["Law"].ToString();
            litere = _configuration.GetSection("UBB")["Litere"].ToString();
            socasis = _configuration.GetSection("UBB")["Socasis"].ToString();
            psiedu = _configuration.GetSection("UBB")["Psiedu"].ToString();
            econ = _configuration.GetSection("UBB")["Econ"].ToString();
            fspac = _configuration.GetSection("UBB")["FSPAC"].ToString();
            euro = _configuration.GetSection("UBB")["Euro"].ToString();
            tbs = _configuration.GetSection("UBB")["Tbs"].ToString();
            sport = _configuration.GetSection("UBB")["Sport"].ToString();
            ot = _configuration.GetSection("UBB")["Ot"].ToString();
            rt = _configuration.GetSection("UBB")["Rt"].ToString();
            gct = _configuration.GetSection("UBB")["Rt"].ToString();
            rocateo = _configuration.GetSection("UBB")["Rocateo"].ToString();
            teatruFilm = _configuration.GetSection("UBB")["TeatruFilm"].ToString();
            eng = _configuration.GetSection("UBB")["Eng"].ToString();

        }

        static readonly HttpClient client = CreateClient();

        private static HttpClient CreateClient()
        {
            var header = new AuthenticationHeaderValue("", "");
            var proxy = "";
            if (!string.IsNullOrWhiteSpace(proxy))
            {
                return new HttpClient(new HttpClientHandler
                {
                    Proxy = new WebProxy(proxy),
                })
                {
                    DefaultRequestHeaders =
            {
                Authorization = header,
            }
                };
            }
            return new HttpClient()
            {
                DefaultRequestHeaders =
            {
                Authorization = header,
            }
            };
        }

        public async Task<IActionResult> Index()
        {
            await CheckStatus(ubb, nameof(ubb).ToUpper());
            await CheckStatus(academicInfo, nameof(academicInfo).ToUpper());
            await CheckStatus(platformaAdmitere, nameof(platformaAdmitere).ToUpper());
            await CheckStatus(cs, nameof(cs).ToUpper());
            await CheckStatus(phys, nameof(phys).ToUpper());
            await CheckStatus(chem, nameof(chem).ToUpper());
            await CheckStatus(biogeo, nameof(biogeo).ToUpper());
            await CheckStatus(geografie, nameof(geografie).ToUpper());
            await CheckStatus(law, nameof(law).ToUpper());
            await CheckStatus(litere, nameof(litere).ToUpper());
            await CheckStatus(socasis, nameof(socasis).ToUpper());
            await CheckStatus(psiedu, nameof(psiedu).ToUpper());
            await CheckStatus(econ, nameof(econ).ToUpper());
            await CheckStatus(euro, nameof(euro).ToUpper());
            await CheckStatus(tbs, nameof(tbs).ToUpper());
            await CheckStatus(fspac, nameof(fspac).ToUpper());
            await CheckStatus(sport, nameof(sport).ToUpper());
            await CheckStatus(ot, nameof(ot).ToUpper());
            await CheckStatus(gct, nameof(gct).ToUpper());
            await CheckStatus(rt, nameof(rt).ToUpper());
            await CheckStatus(rocateo, nameof(rocateo).ToUpper());
            await CheckStatus(teatruFilm, nameof(teatruFilm).ToUpper());
            await CheckStatus(eng, nameof(eng).ToUpper());
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task CheckStatus(string websiteUrl, string name)
        {

            HttpResponseMessage response = new();
            try
            {
                response = await client.GetAsync(websiteUrl);
            }
            catch (Exception e) { }

            if (response.IsSuccessStatusCode)
            {
                ViewData[name] = "available";
            }
            else
            {
                ViewData[name] = "unavailable";
            }
            if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                ViewData[name] = "under-maintance";
            }
        }
    }
}